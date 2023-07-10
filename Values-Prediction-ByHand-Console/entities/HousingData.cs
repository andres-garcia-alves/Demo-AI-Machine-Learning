using Microsoft.ML.Data;

namespace Values_Prediction_ByHand_Console.Entities
{
    internal class HousingData
    {
        [LoadColumn(0)]
        public float Longitude { get; set; }

        [LoadColumn(1)]
        public float Latitude { get; set; }

        [LoadColumn(2)]
        public float HousingMedianAge { get; set; }

        [LoadColumn(3)]
        public float TotalRooms { get; set; }

        [LoadColumn(4)]
        public float TotalBedrooms { get; set; }

        [LoadColumn(5)]
        public float Population { get; set; }

        [LoadColumn(6)]
        public float Households { get; set; }

        [LoadColumn(7)]
        public float MedianIncome { get; set; }

        [LoadColumn(8), ColumnName("Label")]
        public float MedianHouseValue { get; set; }

        [LoadColumn(9)]
        public string? OceanProximity { get; set; }


        public HousingData() { }

        public HousingData(float longitude, float latitude, float housingMedianAge, float totalRooms, float totalBedrooms, float population, float households, float medianIncome, float medianHouseValue, string? oceanProximity)
        {
            Longitude = longitude;
            Latitude = latitude;
            HousingMedianAge = housingMedianAge;
            TotalRooms = totalRooms;
            TotalBedrooms = totalBedrooms;
            Population = population;
            Households = households;
            MedianIncome = medianIncome;
            MedianHouseValue = medianHouseValue;
            OceanProximity = oceanProximity;
        }
    }
}
