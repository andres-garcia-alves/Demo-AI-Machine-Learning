using Microsoft.ML;
using Image_Classification_Entities;

namespace Image_Classification_WinForms
{
    internal class PredictionEngine
    {
        static readonly string modelPath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "models", "image-classification-model.zip");
        static readonly string modelMissingMessage = "Model file missing. Train the model first using Image-Classification-Console.";

        static PredictionEngine<ImageData, ImagePrediction>? predictionEngine = null;

        public static PredictionEngine<ImageData, ImagePrediction> GetInstance()
        {
            try
            {
                if (predictionEngine == null)
                {
                    // load trained model
                    var context = new MLContext();
                    var model = context.Model.Load(modelPath, out _);

                    // create a PredictionEngine based con current model
                    predictionEngine = context.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);
                }

                return predictionEngine;
            }
            catch (FileNotFoundException) { MessageBox.Show(modelMissingMessage, "Model Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); throw; }
            catch (Exception) { throw; }
        }
    }
}
