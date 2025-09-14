namespace DIP_3D
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
            visualize_leftImage = new PictureBox();
            visualize_RightImage = new PictureBox();
            loadLeftImage_btn = new Button();
            loadRightImage_btn = new Button();
            img01_label = new Label();
            img02_label = new Label();
            moveDist_label = new Label();
            moveDist_tb = new TextBox();
            label4 = new Label();
            calculationResults_btn = new Button();
            calculationResults_label = new Label();
            leftImg_center_tb = new TextBox();
            rightImg_center_tb = new TextBox();
            infos_label = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)visualize_leftImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)visualize_RightImage).BeginInit();
            SuspendLayout();
            // 
            // visualize_leftImage
            // 
            visualize_leftImage.BackColor = SystemColors.ControlDark;
            visualize_leftImage.Location = new Point(12, 12);
            visualize_leftImage.Name = "visualize_leftImage";
            visualize_leftImage.Size = new Size(550, 400);
            visualize_leftImage.TabIndex = 0;
            visualize_leftImage.TabStop = false;
            // 
            // visualize_RightImage
            // 
            visualize_RightImage.BackColor = SystemColors.ControlDark;
            visualize_RightImage.Location = new Point(672, 12);
            visualize_RightImage.Name = "visualize_RightImage";
            visualize_RightImage.Size = new Size(550, 400);
            visualize_RightImage.TabIndex = 1;
            visualize_RightImage.TabStop = false;
            // 
            // loadLeftImage_btn
            // 
            loadLeftImage_btn.Location = new Point(12, 418);
            loadLeftImage_btn.Name = "loadLeftImage_btn";
            loadLeftImage_btn.Size = new Size(115, 23);
            loadLeftImage_btn.TabIndex = 2;
            loadLeftImage_btn.Text = "Load left image";
            loadLeftImage_btn.UseVisualStyleBackColor = true;
            loadLeftImage_btn.Click += loadLeftImage_btn_Click;
            // 
            // loadRightImage_btn
            // 
            loadRightImage_btn.Location = new Point(672, 418);
            loadRightImage_btn.Name = "loadRightImage_btn";
            loadRightImage_btn.Size = new Size(112, 23);
            loadRightImage_btn.TabIndex = 3;
            loadRightImage_btn.Text = "Load right image";
            loadRightImage_btn.UseVisualStyleBackColor = true;
            loadRightImage_btn.Click += loadRightImage_btn_Click;
            // 
            // img01_label
            // 
            img01_label.AutoSize = true;
            img01_label.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            img01_label.Location = new Point(133, 421);
            img01_label.Name = "img01_label";
            img01_label.Size = new Size(54, 20);
            img01_label.TabIndex = 4;
            img01_label.Text = "label1";
            // 
            // img02_label
            // 
            img02_label.AutoSize = true;
            img02_label.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            img02_label.Location = new Point(790, 421);
            img02_label.Name = "img02_label";
            img02_label.Size = new Size(54, 20);
            img02_label.TabIndex = 5;
            img02_label.Text = "label2";
            // 
            // moveDist_label
            // 
            moveDist_label.AutoSize = true;
            moveDist_label.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            moveDist_label.Location = new Point(12, 460);
            moveDist_label.Name = "moveDist_label";
            moveDist_label.Size = new Size(121, 20);
            moveDist_label.TabIndex = 6;
            moveDist_label.Text = "相機移動距離：";
            // 
            // moveDist_tb
            // 
            moveDist_tb.Location = new Point(133, 460);
            moveDist_tb.Name = "moveDist_tb";
            moveDist_tb.Size = new Size(100, 23);
            moveDist_tb.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(239, 460);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 8;
            label4.Text = "公分";
            // 
            // calculationResults_btn
            // 
            calculationResults_btn.Location = new Point(672, 457);
            calculationResults_btn.Name = "calculationResults_btn";
            calculationResults_btn.Size = new Size(133, 23);
            calculationResults_btn.TabIndex = 9;
            calculationResults_btn.Text = "Calculation results";
            calculationResults_btn.UseVisualStyleBackColor = true;
            calculationResults_btn.Click += calculationResults_btn_Click;
            // 
            // calculationResults_label
            // 
            calculationResults_label.AutoSize = true;
            calculationResults_label.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            calculationResults_label.Location = new Point(811, 460);
            calculationResults_label.Name = "calculationResults_label";
            calculationResults_label.Size = new Size(41, 20);
            calculationResults_label.TabIndex = 10;
            calculationResults_label.Text = "公分";
            // 
            // leftImg_center_tb
            // 
            leftImg_center_tb.Location = new Point(12, 531);
            leftImg_center_tb.Name = "leftImg_center_tb";
            leftImg_center_tb.Size = new Size(100, 23);
            leftImg_center_tb.TabIndex = 11;
            // 
            // rightImg_center_tb
            // 
            rightImg_center_tb.Location = new Point(133, 531);
            rightImg_center_tb.Name = "rightImg_center_tb";
            rightImg_center_tb.Size = new Size(100, 23);
            rightImg_center_tb.TabIndex = 12;
            // 
            // infos_label
            // 
            infos_label.AutoSize = true;
            infos_label.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            infos_label.Location = new Point(239, 534);
            infos_label.Name = "infos_label";
            infos_label.Size = new Size(426, 20);
            infos_label.TabIndex = 13;
            infos_label.Text = "原圖: 1237 802，向右20cm: 896 808，向右40cm: 526 852";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 508);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 14;
            label1.Text = "左圖座標：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(133, 508);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 15;
            label2.Text = "右圖座標：";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 566);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(infos_label);
            Controls.Add(rightImg_center_tb);
            Controls.Add(leftImg_center_tb);
            Controls.Add(calculationResults_label);
            Controls.Add(calculationResults_btn);
            Controls.Add(label4);
            Controls.Add(moveDist_tb);
            Controls.Add(moveDist_label);
            Controls.Add(img02_label);
            Controls.Add(img01_label);
            Controls.Add(loadRightImage_btn);
            Controls.Add(loadLeftImage_btn);
            Controls.Add(visualize_RightImage);
            Controls.Add(visualize_leftImage);
            Name = "Form1";
            Text = "Two Eye and 3D";
            ((System.ComponentModel.ISupportInitialize)visualize_leftImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)visualize_RightImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox visualize_leftImage;
        private PictureBox visualize_RightImage;
        private Button loadLeftImage_btn;
        private Button loadRightImage_btn;
        private Label img01_label;
        private Label img02_label;
        private Label moveDist_label;
        private TextBox moveDist_tb;
        private Label label4;
        private Button calculationResults_btn;
        private Label calculationResults_label;
        private TextBox leftImg_center_tb;
        private TextBox rightImg_center_tb;
        private Label infos_label;
        private Label label1;
        private Label label2;
    }
}