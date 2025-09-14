namespace DIP_Wei_BoostFilter
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
            Visualize_Image_GrayScale = new PictureBox();
            Visualize_BoostFilter_4 = new PictureBox();
            Visualize_BoostFilter_8 = new PictureBox();
            Load_img_btn = new Button();
            boostFilter_btn_4 = new Button();
            boostFilter_btn_8 = new Button();
            boost_value_tb = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Visualize_Image_GrayScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_BoostFilter_4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_BoostFilter_8).BeginInit();
            SuspendLayout();
            // 
            // Visualize_Image_GrayScale
            // 
            Visualize_Image_GrayScale.BackColor = SystemColors.ControlDark;
            Visualize_Image_GrayScale.Location = new Point(12, 12);
            Visualize_Image_GrayScale.Name = "Visualize_Image_GrayScale";
            Visualize_Image_GrayScale.Size = new Size(394, 344);
            Visualize_Image_GrayScale.TabIndex = 0;
            Visualize_Image_GrayScale.TabStop = false;
            // 
            // Visualize_BoostFilter_4
            // 
            Visualize_BoostFilter_4.BackColor = SystemColors.ControlDark;
            Visualize_BoostFilter_4.Location = new Point(512, 12);
            Visualize_BoostFilter_4.Name = "Visualize_BoostFilter_4";
            Visualize_BoostFilter_4.Size = new Size(394, 344);
            Visualize_BoostFilter_4.TabIndex = 1;
            Visualize_BoostFilter_4.TabStop = false;
            // 
            // Visualize_BoostFilter_8
            // 
            Visualize_BoostFilter_8.BackColor = SystemColors.ControlDark;
            Visualize_BoostFilter_8.Location = new Point(971, 12);
            Visualize_BoostFilter_8.Name = "Visualize_BoostFilter_8";
            Visualize_BoostFilter_8.Size = new Size(394, 344);
            Visualize_BoostFilter_8.TabIndex = 2;
            Visualize_BoostFilter_8.TabStop = false;
            // 
            // Load_img_btn
            // 
            Load_img_btn.Location = new Point(12, 362);
            Load_img_btn.Name = "Load_img_btn";
            Load_img_btn.Size = new Size(191, 23);
            Load_img_btn.TabIndex = 3;
            Load_img_btn.Text = "Load_image_And_GrayScale";
            Load_img_btn.UseVisualStyleBackColor = true;
            Load_img_btn.Click += Load_img_btn_Click;
            // 
            // boostFilter_btn_4
            // 
            boostFilter_btn_4.Location = new Point(655, 362);
            boostFilter_btn_4.Name = "boostFilter_btn_4";
            boostFilter_btn_4.Size = new Size(114, 23);
            boostFilter_btn_4.TabIndex = 4;
            boostFilter_btn_4.Text = "高增幅濾波 (A+4)";
            boostFilter_btn_4.UseVisualStyleBackColor = true;
            boostFilter_btn_4.Click += boostFilter_btn_4_Click;
            // 
            // boostFilter_btn_8
            // 
            boostFilter_btn_8.Location = new Point(1109, 361);
            boostFilter_btn_8.Name = "boostFilter_btn_8";
            boostFilter_btn_8.Size = new Size(111, 23);
            boostFilter_btn_8.TabIndex = 5;
            boostFilter_btn_8.Text = "高增幅濾波 (A+8)";
            boostFilter_btn_8.UseVisualStyleBackColor = true;
            boostFilter_btn_8.Click += boostFilter_btn_8_Click;
            // 
            // boost_value_tb
            // 
            boost_value_tb.Location = new Point(889, 361);
            boost_value_tb.Name = "boost_value_tb";
            boost_value_tb.Size = new Size(100, 23);
            boost_value_tb.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 450);
            Controls.Add(boost_value_tb);
            Controls.Add(boostFilter_btn_8);
            Controls.Add(boostFilter_btn_4);
            Controls.Add(Load_img_btn);
            Controls.Add(Visualize_BoostFilter_8);
            Controls.Add(Visualize_BoostFilter_4);
            Controls.Add(Visualize_Image_GrayScale);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Visualize_Image_GrayScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_BoostFilter_4).EndInit();
            ((System.ComponentModel.ISupportInitialize)Visualize_BoostFilter_8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Visualize_Image_GrayScale;
        private PictureBox Visualize_BoostFilter_4;
        private PictureBox Visualize_BoostFilter_8;
        private Button Load_img_btn;
        private Button boostFilter_btn_4;
        private Button boostFilter_btn_8;
        private TextBox boost_value_tb;
    }
}