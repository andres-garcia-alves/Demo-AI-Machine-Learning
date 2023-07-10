using Microsoft.ML.Data;

namespace Values_Prediction_ByHand_Console.Entities
{
    internal class HousingDataOutput : HousingData
    {
        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"Score")]
        public float Score { get; set; }
    }
}
