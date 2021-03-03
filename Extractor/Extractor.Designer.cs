namespace Extractor
{
    partial class Extractor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxVideo = new System.Windows.Forms.CheckBox();
            this.textBoxXefFolder = new System.Windows.Forms.TextBox();
            this.buttonXefBrowser = new System.Windows.Forms.Button();
            this.textBoxSaveFolder = new System.Windows.Forms.TextBox();
            this.buttonFileSaved = new System.Windows.Forms.Button();
            this.buttonStartExtract = new System.Windows.Forms.Button();
            this.checkBoxSkeleton = new System.Windows.Forms.CheckBox();
            this.checkBoxDepth = new System.Windows.Forms.CheckBox();
            this.radioButton30fps = new System.Windows.Forms.RadioButton();
            this.radioButton60fps = new System.Windows.Forms.RadioButton();
            this.allModalityCheck = new System.Windows.Forms.CheckBox();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.SettingBox = new System.Windows.Forms.GroupBox();
            this.checkBoxAudio = new System.Windows.Forms.CheckBox();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.objectNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xefExtractBox = new System.Windows.Forms.GroupBox();
            this.processingBar = new System.Windows.Forms.ProgressBar();
            this.SettingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            this.xefExtractBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxVideo
            // 
            this.checkBoxVideo.AutoSize = true;
            this.checkBoxVideo.Location = new System.Drawing.Point(11, 22);
            this.checkBoxVideo.Name = "checkBoxVideo";
            this.checkBoxVideo.Size = new System.Drawing.Size(61, 21);
            this.checkBoxVideo.TabIndex = 0;
            this.checkBoxVideo.Text = "Video";
            this.checkBoxVideo.UseVisualStyleBackColor = true;
            // 
            // textBoxXefFolder
            // 
            this.textBoxXefFolder.Location = new System.Drawing.Point(5, 55);
            this.textBoxXefFolder.Name = "textBoxXefFolder";
            this.textBoxXefFolder.Size = new System.Drawing.Size(194, 23);
            this.textBoxXefFolder.TabIndex = 1;
            // 
            // buttonXefBrowser
            // 
            this.buttonXefBrowser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonXefBrowser.Location = new System.Drawing.Point(208, 55);
            this.buttonXefBrowser.Name = "buttonXefBrowser";
            this.buttonXefBrowser.Size = new System.Drawing.Size(62, 24);
            this.buttonXefBrowser.TabIndex = 2;
            this.buttonXefBrowser.Text = "XefFile";
            this.buttonXefBrowser.UseVisualStyleBackColor = true;
            this.buttonXefBrowser.Click += new System.EventHandler(this.buttonXefBrowser_Click);
            // 
            // textBoxSaveFolder
            // 
            this.textBoxSaveFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSaveFolder.Location = new System.Drawing.Point(5, 93);
            this.textBoxSaveFolder.Name = "textBoxSaveFolder";
            this.textBoxSaveFolder.Size = new System.Drawing.Size(195, 23);
            this.textBoxSaveFolder.TabIndex = 1;
            // 
            // buttonFileSaved
            // 
            this.buttonFileSaved.Location = new System.Drawing.Point(208, 93);
            this.buttonFileSaved.Name = "buttonFileSaved";
            this.buttonFileSaved.Size = new System.Drawing.Size(62, 23);
            this.buttonFileSaved.TabIndex = 2;
            this.buttonFileSaved.Text = "Save";
            this.buttonFileSaved.UseVisualStyleBackColor = true;
            this.buttonFileSaved.Click += new System.EventHandler(this.buttonFileSaved_Click);
            // 
            // buttonStartExtract
            // 
            this.buttonStartExtract.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStartExtract.Location = new System.Drawing.Point(71, 129);
            this.buttonStartExtract.Name = "buttonStartExtract";
            this.buttonStartExtract.Size = new System.Drawing.Size(104, 42);
            this.buttonStartExtract.TabIndex = 2;
            this.buttonStartExtract.Text = "XefExtract";
            this.buttonStartExtract.UseVisualStyleBackColor = true;
            this.buttonStartExtract.Click += new System.EventHandler(this.buttonStartExtract_Click);
            // 
            // checkBoxSkeleton
            // 
            this.checkBoxSkeleton.AutoSize = true;
            this.checkBoxSkeleton.Location = new System.Drawing.Point(11, 101);
            this.checkBoxSkeleton.Name = "checkBoxSkeleton";
            this.checkBoxSkeleton.Size = new System.Drawing.Size(77, 21);
            this.checkBoxSkeleton.TabIndex = 0;
            this.checkBoxSkeleton.Text = "Skeleton";
            this.checkBoxSkeleton.UseVisualStyleBackColor = true;
            // 
            // checkBoxDepth
            // 
            this.checkBoxDepth.AutoSize = true;
            this.checkBoxDepth.Location = new System.Drawing.Point(11, 129);
            this.checkBoxDepth.Name = "checkBoxDepth";
            this.checkBoxDepth.Size = new System.Drawing.Size(62, 21);
            this.checkBoxDepth.TabIndex = 0;
            this.checkBoxDepth.Text = "Depth";
            this.checkBoxDepth.UseVisualStyleBackColor = true;
            // 
            // radioButton30fps
            // 
            this.radioButton30fps.AutoSize = true;
            this.radioButton30fps.Checked = true;
            this.radioButton30fps.Location = new System.Drawing.Point(30, 49);
            this.radioButton30fps.Name = "radioButton30fps";
            this.radioButton30fps.Size = new System.Drawing.Size(58, 21);
            this.radioButton30fps.TabIndex = 3;
            this.radioButton30fps.TabStop = true;
            this.radioButton30fps.Text = "30fps";
            this.radioButton30fps.UseVisualStyleBackColor = true;
            // 
            // radioButton60fps
            // 
            this.radioButton60fps.AutoSize = true;
            this.radioButton60fps.Location = new System.Drawing.Point(103, 49);
            this.radioButton60fps.Name = "radioButton60fps";
            this.radioButton60fps.Size = new System.Drawing.Size(58, 21);
            this.radioButton60fps.TabIndex = 3;
            this.radioButton60fps.Text = "60fps";
            this.radioButton60fps.UseVisualStyleBackColor = true;
            // 
            // allModalityCheck
            // 
            this.allModalityCheck.AutoSize = true;
            this.allModalityCheck.Location = new System.Drawing.Point(11, 156);
            this.allModalityCheck.Name = "allModalityCheck";
            this.allModalityCheck.Size = new System.Drawing.Size(96, 21);
            this.allModalityCheck.TabIndex = 0;
            this.allModalityCheck.Text = "All Modality";
            this.allModalityCheck.UseVisualStyleBackColor = true;
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Location = new System.Drawing.Point(497, 36);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(446, 106);
            this.richTextBoxMessage.TabIndex = 4;
            this.richTextBoxMessage.Text = "";
            // 
            // SettingBox
            // 
            this.SettingBox.Controls.Add(this.checkBoxAudio);
            this.SettingBox.Controls.Add(this.radioButton60fps);
            this.SettingBox.Controls.Add(this.radioButton30fps);
            this.SettingBox.Controls.Add(this.allModalityCheck);
            this.SettingBox.Controls.Add(this.checkBoxDepth);
            this.SettingBox.Controls.Add(this.checkBoxSkeleton);
            this.SettingBox.Controls.Add(this.checkBoxVideo);
            this.SettingBox.Location = new System.Drawing.Point(496, 173);
            this.SettingBox.Name = "SettingBox";
            this.SettingBox.Size = new System.Drawing.Size(167, 183);
            this.SettingBox.TabIndex = 5;
            this.SettingBox.TabStop = false;
            this.SettingBox.Text = "Setting";
            // 
            // checkBoxAudio
            // 
            this.checkBoxAudio.AutoSize = true;
            this.checkBoxAudio.Location = new System.Drawing.Point(11, 74);
            this.checkBoxAudio.Name = "checkBoxAudio";
            this.checkBoxAudio.Size = new System.Drawing.Size(61, 21);
            this.checkBoxAudio.TabIndex = 0;
            this.checkBoxAudio.Text = "Audio";
            this.checkBoxAudio.UseVisualStyleBackColor = true;
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.Location = new System.Drawing.Point(10, 36);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(480, 320);
            this.pictureBoxVideo.TabIndex = 6;
            this.pictureBoxVideo.TabStop = false;
            // 
            // objectNumber
            // 
            this.objectNumber.Location = new System.Drawing.Point(71, 22);
            this.objectNumber.Name = "objectNumber";
            this.objectNumber.Size = new System.Drawing.Size(104, 23);
            this.objectNumber.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "No. ";
            // 
            // xefExtractBox
            // 
            this.xefExtractBox.Controls.Add(this.objectNumber);
            this.xefExtractBox.Controls.Add(this.label1);
            this.xefExtractBox.Controls.Add(this.textBoxXefFolder);
            this.xefExtractBox.Controls.Add(this.buttonXefBrowser);
            this.xefExtractBox.Controls.Add(this.buttonStartExtract);
            this.xefExtractBox.Controls.Add(this.textBoxSaveFolder);
            this.xefExtractBox.Controls.Add(this.buttonFileSaved);
            this.xefExtractBox.Location = new System.Drawing.Point(669, 181);
            this.xefExtractBox.Name = "xefExtractBox";
            this.xefExtractBox.Size = new System.Drawing.Size(274, 175);
            this.xefExtractBox.TabIndex = 0;
            this.xefExtractBox.TabStop = false;
            this.xefExtractBox.Text = "Extractor";
            // 
            // processingBar
            // 
            this.processingBar.BackColor = System.Drawing.Color.Gray;
            this.processingBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.processingBar.Location = new System.Drawing.Point(496, 153);
            this.processingBar.Name = "processingBar";
            this.processingBar.Size = new System.Drawing.Size(447, 14);
            this.processingBar.TabIndex = 7;
            // 
            // Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.processingBar);
            this.Controls.Add(this.xefExtractBox);
            this.Controls.Add(this.pictureBoxVideo);
            this.Controls.Add(this.SettingBox);
            this.Controls.Add(this.richTextBoxMessage);
            this.MaximizeBox = false;
            this.Name = "Extractor";
            this.Text = "XefExtract";
            this.SettingBox.ResumeLayout(false);
            this.SettingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            this.xefExtractBox.ResumeLayout(false);
            this.xefExtractBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxVideo;
        private System.Windows.Forms.TextBox textBoxXefFolder;
        private System.Windows.Forms.Button buttonXefBrowser;
        private System.Windows.Forms.TextBox textBoxSaveFolder;
        private System.Windows.Forms.Button buttonFileSaved;
        private System.Windows.Forms.Button buttonStartExtract;
        private System.Windows.Forms.CheckBox checkBoxSkeleton;
        private System.Windows.Forms.CheckBox checkBoxDepth;
        private System.Windows.Forms.RadioButton radioButton30fps;
        private System.Windows.Forms.RadioButton radioButton60fps;
        private System.Windows.Forms.CheckBox allModalityCheck;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.GroupBox SettingBox;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.CheckBox checkBoxAudio;
        private System.Windows.Forms.TextBox objectNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox xefExtractBox;
        //private System.Windows.Forms.ProgressBar extractingBar;
        private System.Windows.Forms.ProgressBar processingBar;
    }
}