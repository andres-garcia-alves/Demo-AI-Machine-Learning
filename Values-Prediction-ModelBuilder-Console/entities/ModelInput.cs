using Microsoft.ML.Data;

namespace Values_Prediction_ModelBuilder_Console.Entities
{
    public class ModelInput
    {
        [ColumnName(@"longitude")]
        public float Longitude { get; set; }

        [ColumnName(@"latitude")]
        public float Latitude { get; set; }

        [ColumnName(@"housing_median_age")]
        public float Housing_median_age { get; set; }

        [ColumnName(@"total_rooms")]
        public float Total_rooms { get; set; }

        [ColumnName(@"total_bedrooms")]
        public float Total_bedrooms { get; set; }

        [ColumnName(@"population")]
        public float Population { get; set; }

        [ColumnName(@"households")]
        public float Households { get; set; }

        [ColumnName(@"median_income")]
        public float Median_income { get; set; }

        [ColumnName(@"median_house_value")]
        public float Median_house_value { get; set; }

        [ColumnName(@"ocean_proximity")]
        public string Ocean_proximity { get; set; }

    }
}
