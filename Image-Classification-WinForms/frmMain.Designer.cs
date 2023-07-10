namespace Image_Classification_WinForms
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picBox = new PictureBox();
            btnSelectImage = new Button();
            btnPredict = new Button();
            lblPrediction = new Label();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            SuspendLayout();
            // 
            // picBox
            // 
            picBox.Location = new Point(50, 52);
            picBox.Name = "picBox";
            picBox.Size = new Size(764, 430);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            picBox.LoadCompleted += picBox_LoadCompleted;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(50, 18);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(100, 23);
            btnSelectImage.TabIndex = 1;
            btnSelectImage.Text = "&Select Image";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // btnPredict
            // 
            btnPredict.Enabled = false;
            btnPredict.Location = new Point(156, 18);
            btnPredict.Name = "btnPredict";
            btnPredict.Size = new Size(100, 23);
            btnPredict.TabIndex = 2;
            btnPredict.Text = "&Predict";
            btnPredict.UseVisualStyleBackColor = true;
            btnPredict.Click += btnPredict_Click;
            // 
            // lblPrediction
            // 
            lblPrediction.AutoSize = true;
            lblPrediction.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrediction.Location = new Point(50, 498);
            lblPrediction.Name = "lblPrediction";
            lblPrediction.Size = new Size(67, 15);
            lblPrediction.TabIndex = 3;
            lblPrediction.Text = "Prediction:";
            lblPrediction.Visible = false;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Images|*.jpg; *.png";
            // 
            // frmMain
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 537);
            Controls.Add(lblPrediction);
            Controls.Add(btnPredict);
            Controls.Add(btnSelectImage);
            Controls.Add(picBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMain";
            Text = "Image Classification";
            DragDrop += frmMain_DragDrop;
            DragEnter += frmMain_DragEnter;
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBox;
        private Button btnSelectImage;
        private Button btnPredict;
        private Label lblPrediction;
        private OpenFileDialog openFileDialog;
    }
}