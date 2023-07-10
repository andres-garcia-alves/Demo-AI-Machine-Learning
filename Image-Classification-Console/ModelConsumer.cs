using Microsoft.ML;
using Image_Classification_Entities;

namespace Image_Classification_Console
{
    internal class ModelConsumer
    {
        readonly string _imagesFolder;

        public ModelConsumer(string assetsPath)
        {
            _imagesFolder = Path.Combine(assetsPath, "images");
        }

        public void ClassifySingleImage(MLContext context, ITransformer model)
        {
            var predictor = context.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);

            var fileNames = Directory.GetFiles(_imagesFolder);
            var imageData = new ImageData() { ImagePath = Path.Combine(_imagesFolder, fileNames.First()) };
            var prediction = predictor.Predict(imageData);

            Console.WriteLine($"Image '{ Path.GetFileName(imageData.ImagePath) }' predicted as '{ prediction.PredictedLabelValue }' with score: { prediction.Score?.Max() }.");
        }
    }
}
