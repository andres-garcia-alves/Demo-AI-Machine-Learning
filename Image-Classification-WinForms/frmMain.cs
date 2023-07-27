using System.ComponentModel;
using Image_Classification_Entities;

namespace Image_Classification_WinForms
{
    public partial class frmMain : Form
    {
        string SelectedFileName = String.Empty;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null) { return; }
            var dropData = e.Data.GetData(DataFormats.FileDrop) as string[] ?? Array.Empty<string>();

            this.SelectedFileName = dropData.First();
            this.picBox.ImageLocation = this.SelectedFileName;
            this.btnPredict.Enabled = true;
            this.lblPrediction.Visible = false;
            this.lblDragDropMessage.Visible = false;
        }

        private void picBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null) { return; }

            this.SelectedFileName = String.Empty;
            this.btnPredict.Enabled = false;

            MessageBox.Show("The file could not be recognized.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK) { return; }

            this.SelectedFileName = this.openFileDialog.FileName;
            this.picBox.ImageLocation = this.SelectedFileName;
            this.btnPredict.Enabled = true;
            this.lblPrediction.Visible = false;
            this.lblDragDropMessage.Visible = false;
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            if (this.SelectedFileName == String.Empty) { return; }
            Cursor = Cursors.WaitCursor;

            // predict image label
            var imageData = new ImageData(this.SelectedFileName, null);
            var prediction = PredictionEngine.GetInstance().Predict(imageData);

            // show results
            var predictionConfidence = prediction.Score?.Max() * 100;
            this.lblPrediction.Text = $"Prediction: {prediction.PredictedLabelValue?.ToUpper()} image (confidence {predictionConfidence?.ToString("0.00")}%).";
            this.lblPrediction.Visible = true;

            Cursor = Cursors.Default;
        }
    }
}