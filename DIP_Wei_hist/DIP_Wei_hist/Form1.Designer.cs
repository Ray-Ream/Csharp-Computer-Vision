namespace DIP_Wei_hist
{
    partial class Form1
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
            Image_Visualize = new PictureBox();
            Histogram_Equalization_Visualize = new PictureBox();
            Load_img_btn = new Button();
            Histogram_Equalization_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Histogram_Equalization_Visualize).BeginInit();
            SuspendLayout();
            // 
            // Image_Visualize
            // 
            Image_Visualize.Location = new Point(12, 12);
            Image_Visualize.Name = "Image_Visualize";
            Image_Visualize.Size = new Size(359, 353);
            Image_Visualize.TabIndex = 0;
            Image_Visualize.TabStop = false;
            // 
            // Histogram_Equalization_Visualize
            // 
            Histogram_Equalization_Visualize.Location = new Point(400, 12);
            Histogram_Equalization_Visualize.Name = "Histogram_Equalization_Visualize";
            Histogram_Equalization_Visualize.Size = new Size(359, 353);
            Histogram_Equalization_Visualize.TabIndex = 1;
            Histogram_Equalization_Visualize.TabStop = false;
            // 
            // Load_img_btn
            // 
            Load_img_btn.Location = new Point(12, 371);
            Load_img_btn.Name = "Load_img_btn";
            Load_img_btn.Size = new Size(180, 23);
            Load_img_btn.TabIndex = 2;
            Load_img_btn.Text = "Load_image_And_Gray_scale";
            Load_img_btn.UseVisualStyleBackColor = true;
            Load_img_btn.Click += Load_img_btn_Click;
            // 
            // Histogram_Equalization_btn
            // 
            Histogram_Equalization_btn.Location = new Point(400, 371);
            Histogram_Equalization_btn.Name = "Histogram_Equalization_btn";
            Histogram_Equalization_btn.Size = new Size(180, 23);
            Histogram_Equalization_btn.TabIndex = 3;
            Histogram_Equalization_btn.Text = "Histogram Equalization";
            Histogram_Equalization_btn.UseVisualStyleBackColor = true;
            Histogram_Equalization_btn.Click += Histogram_Equalization_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 450);
            Controls.Add(Histogram_Equalization_btn);
            Controls.Add(Load_img_btn);
            Controls.Add(Histogram_Equalization_Visualize);
            Controls.Add(Image_Visualize);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).EndInit();
            ((System.ComponentModel.ISupportInitialize)Histogram_Equalization_Visualize).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Image_Visualize;
        private PictureBox Histogram_Equalization_Visualize;
        private Button Load_img_btn;
        private Button Histogram_Equalization_btn;
    }
}