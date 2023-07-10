using Microsoft.ML;
using Microsoft.ML.Data;
using System.IO.Compression;
using Image_Classification_Entities;
using Image_Classification_Console.Entities;

namespace Image_Classification_Console
{
    internal class ModelTrainning
    {
        readonly string assetsPath;
        readonly string inceptionFile;

        public ModelTrainning(string assetsPath)
        {
            this.assetsPath = assetsPath;
            this.inceptionFile = Path.Combine(assetsPath, "inception-model", "tensorflow-inception.pb");

            this.UnzipInceptionModel();
        }

        public void UnzipInceptionModel()
        {
            if (File.Exists(this.inceptionFile)) { return; }

            string zipFile = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "models", "tensorflow-inception-model.zip");
            string outputFolder = Path.Combine(assetsPath, "inception-model");

            ZipFile.ExtractToDirectory(zipFile, outputFolder);
        }

        public ITransformer GenerateModel(MLContext context, bool saveGeneratedModel = true)
        {
            string imagesFolder = Path.Combine(assetsPath, "images");
            string trainTagsTsv = Path.Combine(assetsPath, "train-tags.tsv");

            // model pipeline
            IEstimator<ITransformer> pipeline = context.Transforms.LoadImages(outputColumnName: "input", imageFolder: imagesFolder, inputColumnName: nameof(ImageData.ImagePath))
            .Append(context.Transforms.ResizeImages(outputColumnName: "input", imageWidth: InceptionSettings.ImageWidth, imageHeight: InceptionSettings.ImageHeight, inputColumnName: "input"))
            .Append(context.Transforms.ExtractPixels(outputColumnName: "input", interleavePixelColors: InceptionSettings.ChannelsLast, offsetImage: InceptionSettings.Mean))
            .Append(context.Model.LoadTensorFlowModel(inceptionFile)
            .ScoreTensorFlowModel(outputColumnNames: new[] { "softmax2_pre_activation" }, inputColumnNames: new[] { "input" }, addBatchDimensionInput: true))

            .Append(context.Transforms.Conversion.MapValueToKey(outputColumnName: "LabelKey", inputColumnName: "Label"))
            .Append(context.MulticlassClassification.Trainers.LbfgsMaximumEntropy(labelColumnName: "LabelKey", featureColumnName: "softmax2_pre_activation"))
            .Append(context.Transforms.Conversion.MapKeyToValue(outputColumnName: "PredictedLabelValue", inputColumnName: "PredictedLabel"))
            .AppendCacheCheckpoint(context);

            // load data
            IDataView trainingData = context.Data.LoadFromTextFile<ImageData>(path: trainTagsTsv, hasHeader: false);

            // model trainning
            ITransformer model = pipeline.Fit(trainingData);

            // model save
            if (saveGeneratedModel)
            {
                string modelPath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "models", "image-classification-model.zip");
                context.Model.Save(model, trainingData.Schema, modelPath);
            }

            return model;
        }

        public void EvaluateModel(MLContext context, ITransformer model)
        {
            var testTagsTsv = Path.Combine(assetsPath, "test-tags.tsv");

            // load data
            IDataView testData = context.Data.LoadFromTextFile<ImageData>(path: testTagsTsv, hasHeader: false);

            // model metrics
            IDataView predictions = model.Transform(testData);
            MulticlassClassificationMetrics metrics = context.MulticlassClassification.Evaluate(predictions, labelColumnName: "LabelKey", predictedLabelColumnName: "PredictedLabel");

            Console.WriteLine($"LogLoss is: { metrics.LogLoss }");
            Console.WriteLine($"PerClassLogLoss is: { String.Join(" , ", metrics.PerClassLogLoss.Select(c => c.ToString())) }");

            // model testing
            IEnumerable<ImagePrediction> imagePredictionData = context.Data.CreateEnumerable<ImagePrediction>(predictions, true);

            Console.WriteLine("");
            Console.WriteLine("Model testing:");
            foreach (ImagePrediction prediction in imagePredictionData)
                Console.WriteLine($"Image '{ Path.GetFileName(prediction.ImagePath) }' predicted as: '{ prediction.PredictedLabelValue }' with score: { prediction.Score?.Max() }.");
        }
    }
}
