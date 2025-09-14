namespace DIP_Wei_gamma
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
            GrayScale_Visualize = new PictureBox();
            Gamma_Visualize = new PictureBox();
            Load_img_btn = new Button();
            Gray_Scale_btn = new Button();
            Gamma_tb = new TextBox();
            Chnage_Gamma_btn = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GrayScale_Visualize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Gamma_Visualize).BeginInit();
            SuspendLayout();
            // 
            // Image_Visualize
            // 
            Image_Visualize.Location = new Point(12, 12);
            Image_Visualize.Name = "Image_Visualize";
            Image_Visualize.Size = new Size(323, 285);
            Image_Visualize.TabIndex = 0;
            Image_Visualize.TabStop = false;
            // 
            // GrayScale_Visualize
            // 
            GrayScale_Visualize.Location = new Point(341, 12);
            GrayScale_Visualize.Name = "GrayScale_Visualize";
            GrayScale_Visualize.Size = new Size(323, 285);
            GrayScale_Visualize.TabIndex = 1;
            GrayScale_Visualize.TabStop = false;
            // 
            // Gamma_Visualize
            // 
            Gamma_Visualize.Location = new Point(670, 12);
            Gamma_Visualize.Name = "Gamma_Visualize";
            Gamma_Visualize.Size = new Size(323, 285);
            Gamma_Visualize.TabIndex = 2;
            Gamma_Visualize.TabStop = false;
            // 
            // Load_img_btn
            // 
            Load_img_btn.Location = new Point(12, 303);
            Load_img_btn.Name = "Load_img_btn";
            Load_img_btn.Size = new Size(91, 23);
            Load_img_btn.TabIndex = 3;
            Load_img_btn.Text = "Load_Image";
            Load_img_btn.UseVisualStyleBackColor = true;
            Load_img_btn.Click += Load_img_btn_Click;
            // 
            // Gray_Scale_btn
            // 
            Gray_Scale_btn.Location = new Point(341, 303);
            Gray_Scale_btn.Name = "Gray_Scale_btn";
            Gray_Scale_btn.Size = new Size(85, 23);
            Gray_Scale_btn.TabIndex = 4;
            Gray_Scale_btn.Text = "Gray_Scale";
            Gray_Scale_btn.UseVisualStyleBackColor = true;
            Gray_Scale_btn.Click += Gray_Scale_btn_Click;
            // 
            // Gamma_tb
            // 
            Gamma_tb.Location = new Point(670, 303);
            Gamma_tb.Name = "Gamma_tb";
            Gamma_tb.Size = new Size(100, 23);
            Gamma_tb.TabIndex = 5;
            // 
            // Chnage_Gamma_btn
            // 
            Chnage_Gamma_btn.Location = new Point(776, 303);
            Chnage_Gamma_btn.Name = "Chnage_Gamma_btn";
            Chnage_Gamma_btn.Size = new Size(75, 23);
            Chnage_Gamma_btn.TabIndex = 6;
            Chnage_Gamma_btn.Text = "乘冪律轉換";
            Chnage_Gamma_btn.UseVisualStyleBackColor = true;
            Chnage_Gamma_btn.Click += Chnage_Gamma_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(670, 329);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 7;
            label1.Text = "Gamma";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 450);
            Controls.Add(label1);
            Controls.Add(Chnage_Gamma_btn);
            Controls.Add(Gamma_tb);
            Controls.Add(Gray_Scale_btn);
            Controls.Add(Load_img_btn);
            Controls.Add(Gamma_Visualize);
            Controls.Add(GrayScale_Visualize);
            Controls.Add(Image_Visualize);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Image_Visualize).EndInit();
            ((System.ComponentModel.ISupportInitialize)GrayScale_Visualize).EndInit();
            ((System.ComponentModel.ISupportInitialize)Gamma_Visualize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Image_Visualize;
        private PictureBox GrayScale_Visualize;
        private PictureBox Gamma_Visualize;
        private Button Load_img_btn;
        private Button Gray_Scale_btn;
        private TextBox Gamma_tb;
        private Button Chnage_Gamma_btn;
        private Label label1;
    }
}