using Microsoft.ML;
using Values_Prediction_ByHand_Console.Entities;

Console.WriteLine("Trying ML model by hand...");

var context = new MLContext();

// load CSV
var data = context.Data.LoadFromTextFile<HousingData>("./housing.csv", hasHeader: true, separatorChar: ',');

// split data 80/20
var trainTestSplit = context.Data.TrainTestSplit(data, testFraction: 0.2);

var features = trainTestSplit.TrainSet.Schema
    .Select(col => col.Name)
    .Where(colName => colName != "Label" && colName != "OceanProximity")
    .ToArray();

// transformation pipeline
var pipeline = context.Transforms.Concatenate("Features", features)
    .Append(context.Transforms.Text.FeaturizeText("Text", "OceanProximity"))
    .Append(context.Transforms.Concatenate("Feature", "Features", "Text"))
    .Append(context.Regression.Trainers.LbfgsPoissonRegression());

// lineal regression
var model = pipeline.Fit(trainTestSplit.TrainSet);

// check against test-set and evaluate accuracy
var predictions = model.Transform(trainTestSplit.TestSet);
var metrics = context.Regression.Evaluate(predictions);
Console.WriteLine($"Accuracy R^2 - {metrics.RSquared}");

// trying the model for some particular data...
Console.WriteLine();
Console.WriteLine($"Trying the model for some particular data...");

var example01 = new HousingData(-122.23f, 37.88f, 41.0f, 880.0f, 129.0f, 322.0f, 126.0f, 8.3252f, 452600.0f, "NEAR BAY");
var example02 = new HousingData(-122.22f, 37.86f, 21.0f, 7099.0f, 1106.0f, 2401.0f, 1138.0f, 8.3014f, 358500.0f, "NEAR BAY");

var predictionEngine = context.Model.CreatePredictionEngine<HousingData, HousingDataOutput>(model);
HousingDataOutput prediction01 = predictionEngine.Predict(example01);
HousingDataOutput prediction02 = predictionEngine.Predict(example02);

Console.WriteLine($"Case 01 - Predicted value: ${prediction01.Score}, Actual Value: ${example01.MedianHouseValue}.");
Console.WriteLine($"Case 02 - Predicted value: ${prediction02.Score}, Actual Value: ${example02.MedianHouseValue}.");
