namespace Wei_DIP_edgeDetection
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
            EdgeDetection_Visualize = new PictureBox();
            LoadImg_And_GrayScale_btn = new Button();
            sobel_btn = new Button();
            edgeDetection_tb = new TextBox();
            label1 = new Label();
            prewitt_btn = new Button();
            Visualize_HoughTransform = new PictureBox();
            hough_transform_btn = new Button();
            save_hough_transform_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EdgeDetection_Visualize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_HoughTransform).BeginInit();
            SuspendLayout();
            // 
            // Image_Visualize
            // 
            Image_Visualize.Location = new Point(12, 12);
            Image_Visualize.Name = "Image_Visualize";
            Image_Visualize.Size = new Size(525, 437);
            Image_Visualize.TabIndex = 0;
            Image_Visualize.TabStop = false;
            // 
            // EdgeDetection_Visualize
            // 
            EdgeDetection_Visualize.Location = new Point(543, 12);
            EdgeDetection_Visualize.Name = "EdgeDetection_Visualize";
            EdgeDetection_Visualize.Size = new Size(525, 437);
            EdgeDetection_Visualize.TabIndex = 1;
            EdgeDetection_Visualize.TabStop = false;
            // 
            // LoadImg_And_GrayScale_btn
            // 
            LoadImg_And_GrayScale_btn.Location = new Point(12, 455);
            LoadImg_And_GrayScale_btn.Name = "LoadImg_And_GrayScale_btn";
            LoadImg_And_GrayScale_btn.Size = new Size(179, 23);
            LoadImg_And_GrayScale_btn.TabIndex = 2;
            LoadImg_And_GrayScale_btn.Text = "Load Image And Gray Scale";
            LoadImg_And_GrayScale_btn.UseVisualStyleBackColor = true;
            LoadImg_And_GrayScale_btn.Click += LoadImg_And_GrayScale_btn_Click;
            // 
            // sobel_btn
            // 
            sobel_btn.Location = new Point(543, 455);
            sobel_btn.Name = "sobel_btn";
            sobel_btn.Size = new Size(146, 23);
            sobel_btn.TabIndex = 3;
            sobel_btn.Text = "Sobel edge detection";
            sobel_btn.UseVisualStyleBackColor = true;
            sobel_btn.Click += edgeDetection_btn_Click;
            // 
            // edgeDetection_tb
            // 
            edgeDetection_tb.Location = new Point(744, 456);
            edgeDetection_tb.Name = "edgeDetection_tb";
            edgeDetection_tb.Size = new Size(100, 23);
            edgeDetection_tb.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(744, 482);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 5;
            label1.Text = "門檻值 (0-255)";
            // 
            // prewitt_btn
            // 
            prewitt_btn.Location = new Point(543, 484);
            prewitt_btn.Name = "prewitt_btn";
            prewitt_btn.Size = new Size(146, 23);
            prewitt_btn.TabIndex = 6;
            prewitt_btn.Text = "Prewitt edge detection";
            prewitt_btn.UseVisualStyleBackColor = true;
            prewitt_btn.Click += prewitt_btn_Click;
            // 
            // Visualize_HoughTransform
            // 
            Visualize_HoughTransform.Location = new Point(1074, 12);
            Visualize_HoughTransform.Name = "Visualize_HoughTransform";
            Visualize_HoughTransform.Size = new Size(525, 437);
            Visualize_HoughTransform.TabIndex = 7;
            Visualize_HoughTransform.TabStop = false;
            // 
            // hough_transform_btn
            // 
            hough_transform_btn.Location = new Point(1074, 456);
            hough_transform_btn.Name = "hough_transform_btn";
            hough_transform_btn.Size = new Size(146, 23);
            hough_transform_btn.TabIndex = 8;
            hough_transform_btn.Text = "Hough transform";
            hough_transform_btn.UseVisualStyleBackColor = true;
            hough_transform_btn.Click += hough_transform_btn_Click;
            // 
            // save_hough_transform_btn
            // 
            save_hough_transform_btn.Location = new Point(1226, 455);
            save_hough_transform_btn.Name = "save_hough_transform_btn";
            save_hough_transform_btn.Size = new Size(146, 23);
            save_hough_transform_btn.TabIndex = 9;
            save_hough_transform_btn.Text = "Save Hough transform";
            save_hough_transform_btn.UseVisualStyleBackColor = true;
            save_hough_transform_btn.Click += save_hough_transform_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1608, 603);
            Controls.Add(save_hough_transform_btn);
            Controls.Add(hough_transform_btn);
            Controls.Add(Visualize_HoughTransform);
            Controls.Add(prewitt_btn);
            Controls.Add(label1);
            Controls.Add(edgeDetection_tb);
            Controls.Add(sobel_btn);
            Controls.Add(LoadImg_And_GrayScale_btn);
            Controls.Add(EdgeDetection_Visualize);
            Controls.Add(Image_Visualize);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).EndInit();
            ((System.ComponentModel.ISupportInitialize)EdgeDetection_Visualize).EndInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_HoughTransform).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Image_Visualize;
        private PictureBox EdgeDetection_Visualize;
        private Button LoadImg_And_GrayScale_btn;
        private Button sobel_btn;
        private TextBox edgeDetection_tb;
        private Label label1;
        private Button prewitt_btn;
        private PictureBox Visualize_HoughTransform;
        private Button hough_transform_btn;
        private Button save_hough_transform_btn;
    }
}