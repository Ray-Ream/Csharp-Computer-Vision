namespace DIP_Wei_blur
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
            Visualize_smoothing_filter = new PictureBox();
            Load_img_btn = new Button();
            Smoothing_Filter_btn = new Button();
            Medium_Filter_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_smoothing_filter).BeginInit();
            SuspendLayout();
            // 
            // Image_Visualize
            // 
            Image_Visualize.Location = new Point(12, 12);
            Image_Visualize.Name = "Image_Visualize";
            Image_Visualize.Size = new Size(500, 400);
            Image_Visualize.TabIndex = 1;
            Image_Visualize.TabStop = false;
            // 
            // Visualize_smoothing_filter
            // 
            Visualize_smoothing_filter.Location = new Point(546, 12);
            Visualize_smoothing_filter.Name = "Visualize_smoothing_filter";
            Visualize_smoothing_filter.Size = new Size(500, 400);
            Visualize_smoothing_filter.TabIndex = 2;
            Visualize_smoothing_filter.TabStop = false;
            // 
            // Load_img_btn
            // 
            Load_img_btn.Location = new Point(12, 418);
            Load_img_btn.Name = "Load_img_btn";
            Load_img_btn.Size = new Size(192, 23);
            Load_img_btn.TabIndex = 3;
            Load_img_btn.Text = "Load_image_And_Gray_scale";
            Load_img_btn.UseVisualStyleBackColor = true;
            Load_img_btn.Click += Load_img_btn_Click;
            // 
            // Smoothing_Filter_btn
            // 
            Smoothing_Filter_btn.Location = new Point(546, 418);
            Smoothing_Filter_btn.Name = "Smoothing_Filter_btn";
            Smoothing_Filter_btn.Size = new Size(126, 23);
            Smoothing_Filter_btn.TabIndex = 4;
            Smoothing_Filter_btn.Text = "Smoothing_Filter";
            Smoothing_Filter_btn.UseVisualStyleBackColor = true;
            Smoothing_Filter_btn.Click += Smoothing_Filter_btn_Click;
            // 
            // Medium_Filter_btn
            // 
            Medium_Filter_btn.Location = new Point(678, 418);
            Medium_Filter_btn.Name = "Medium_Filter_btn";
            Medium_Filter_btn.Size = new Size(126, 23);
            Medium_Filter_btn.TabIndex = 5;
            Medium_Filter_btn.Text = "Medium_Filter";
            Medium_Filter_btn.UseVisualStyleBackColor = true;
            Medium_Filter_btn.Click += Medium_Filter_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 537);
            Controls.Add(Medium_Filter_btn);
            Controls.Add(Smoothing_Filter_btn);
            Controls.Add(Load_img_btn);
            Controls.Add(Visualize_smoothing_filter);
            Controls.Add(Image_Visualize);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).EndInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_smoothing_filter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Image_Visualize;
        private PictureBox Visualize_smoothing_filter;
        private Button Load_img_btn;
        private Button Smoothing_Filter_btn;
        private Button Medium_Filter_btn;
    }
}