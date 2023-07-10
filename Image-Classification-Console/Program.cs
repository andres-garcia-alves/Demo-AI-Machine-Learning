using Microsoft.ML;
using Image_Classification_Console;

var assetsPath = Path.Combine(Environment.CurrentDirectory, "assets");

var context = new MLContext();

// model training & evaluation
var modelTrainning = new ModelTrainning(assetsPath);

var model = modelTrainning.GenerateModel(context, true);
modelTrainning.EvaluateModel(context, model);

// model comsumption
var modelConsumer = new ModelConsumer(assetsPath);

modelConsumer.ClassifySingleImage(context, model);
