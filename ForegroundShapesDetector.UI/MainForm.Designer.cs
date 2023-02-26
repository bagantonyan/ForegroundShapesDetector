namespace ForegroundShapesDetector.UI
{
    partial class MainForm
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
            this.ShapesCount = new System.Windows.Forms.NumericUpDown();
            this.GenerateShapes = new System.Windows.Forms.Button();
            this.ClearPanel = new System.Windows.Forms.Button();
            this.FindSync = new System.Windows.Forms.Button();
            this.FindAsync = new System.Windows.Forms.Button();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FindShapesCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.FindShapesSquare = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxShapeSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.MinShapeSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ShapesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindShapesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindShapesSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxShapeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinShapeSize)).BeginInit();
            this.SuspendLayout();
            // 
            // ShapesCount
            // 
            this.ShapesCount.Location = new System.Drawing.Point(76, 124);
            this.ShapesCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ShapesCount.Name = "ShapesCount";
            this.ShapesCount.Size = new System.Drawing.Size(113, 27);
            this.ShapesCount.TabIndex = 1;
            this.ShapesCount.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // GenerateShapes
            // 
            this.GenerateShapes.Location = new System.Drawing.Point(50, 168);
            this.GenerateShapes.Name = "GenerateShapes";
            this.GenerateShapes.Size = new System.Drawing.Size(94, 29);
            this.GenerateShapes.TabIndex = 2;
            this.GenerateShapes.Text = "Generate";
            this.GenerateShapes.UseVisualStyleBackColor = true;
            this.GenerateShapes.Click += new System.EventHandler(this.GenerateShapes_Click);
            // 
            // ClearPanel
            // 
            this.ClearPanel.Location = new System.Drawing.Point(50, 203);
            this.ClearPanel.Name = "ClearPanel";
            this.ClearPanel.Size = new System.Drawing.Size(94, 29);
            this.ClearPanel.TabIndex = 3;
            this.ClearPanel.Text = "Clear";
            this.ClearPanel.UseVisualStyleBackColor = true;
            this.ClearPanel.Click += new System.EventHandler(this.ClearPanel_Click);
            // 
            // FindSync
            // 
            this.FindSync.Location = new System.Drawing.Point(50, 420);
            this.FindSync.Name = "FindSync";
            this.FindSync.Size = new System.Drawing.Size(94, 29);
            this.FindSync.TabIndex = 4;
            this.FindSync.Text = "Find Sync";
            this.FindSync.UseVisualStyleBackColor = true;
            this.FindSync.Click += new System.EventHandler(this.FindSync_Click);
            // 
            // FindAsync
            // 
            this.FindAsync.Location = new System.Drawing.Point(50, 455);
            this.FindAsync.Name = "FindAsync";
            this.FindAsync.Size = new System.Drawing.Size(94, 29);
            this.FindAsync.TabIndex = 5;
            this.FindAsync.Text = "Find Async";
            this.FindAsync.UseVisualStyleBackColor = true;
            this.FindAsync.Click += new System.EventHandler(this.FindAsync_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.BackColor = System.Drawing.Color.White;
            this.PictureBox.Location = new System.Drawing.Point(195, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1011, 734);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 6;
            this.PictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Count:";
            // 
            // FindShapesCount
            // 
            this.FindShapesCount.Location = new System.Drawing.Point(69, 333);
            this.FindShapesCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.FindShapesCount.Name = "FindShapesCount";
            this.FindShapesCount.Size = new System.Drawing.Size(120, 27);
            this.FindShapesCount.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Square:";
            // 
            // FindShapesSquare
            // 
            this.FindShapesSquare.Location = new System.Drawing.Point(69, 372);
            this.FindShapesSquare.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.FindShapesSquare.Name = "FindShapesSquare";
            this.FindShapesSquare.Size = new System.Drawing.Size(120, 27);
            this.FindShapesSquare.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "MaxSize:";
            // 
            // MaxShapeSize
            // 
            this.MaxShapeSize.Location = new System.Drawing.Point(76, 84);
            this.MaxShapeSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MaxShapeSize.Name = "MaxShapeSize";
            this.MaxShapeSize.Size = new System.Drawing.Size(113, 27);
            this.MaxShapeSize.TabIndex = 13;
            this.MaxShapeSize.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "MinSize:";
            // 
            // MinShapeSize
            // 
            this.MinShapeSize.Location = new System.Drawing.Point(76, 44);
            this.MinShapeSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MinShapeSize.Name = "MinShapeSize";
            this.MinShapeSize.Size = new System.Drawing.Size(113, 27);
            this.MinShapeSize.TabIndex = 15;
            this.MinShapeSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(31, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Generate Shapes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(12, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Find Foreground Shapes";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 734);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MinShapeSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MaxShapeSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FindShapesSquare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FindShapesCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.FindAsync);
            this.Controls.Add(this.FindSync);
            this.Controls.Add(this.ClearPanel);
            this.Controls.Add(this.GenerateShapes);
            this.Controls.Add(this.ShapesCount);
            this.Name = "MainForm";
            this.Text = "Foreground Shapes Detector";
            ((System.ComponentModel.ISupportInitialize)(this.ShapesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindShapesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FindShapesSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxShapeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinShapeSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NumericUpDown ShapesCount;
        private Button GenerateShapes;
        private Button ClearPanel;
        private Button FindSync;
        private Button FindAsync;
        private PictureBox PictureBox;
        private Label label1;
        private Label label2;
        private NumericUpDown FindShapesCount;
        private Label label3;
        private NumericUpDown FindShapesSquare;
        private Label label4;
        private NumericUpDown MaxShapeSize;
        private Label label5;
        private NumericUpDown MinShapeSize;
        private Label label6;
        private Label label7;
    }
}