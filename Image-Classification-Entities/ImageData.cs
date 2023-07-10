using Microsoft.ML.Data;

namespace Image_Classification_Entities
{
    public class ImageData
    {
        [LoadColumn(0)]
        public string? ImagePath { get; set; }

        [LoadColumn(1)]
        public string? Label { get; set; }

        public ImageData() { }

        public ImageData(string? imagePath, string? label)
        {
            this.ImagePath = imagePath;
            this.Label = label;
        }
    }
}
