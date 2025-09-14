using System.Windows.Forms.VisualStyles;

namespace DIP_Wei_bitPlane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image_Visualize.SizeMode = PictureBoxSizeMode.Zoom;  // Fit the image into the PictureBox
            GrayScale_Visualize.SizeMode = PictureBoxSizeMode.Zoom;  // Fit the image into the PictureBox
            img_bit0.SizeMode = PictureBoxSizeMode.Zoom;
            img_bit1.SizeMode = PictureBoxSizeMode.Zoom;
            img_bit2.SizeMode = PictureBoxSizeMode.Zoom;
            img_bit3.SizeMode = PictureBoxSizeMode.Zoom;
            img_bit4.SizeMode = PictureBoxSizeMode.Zoom;
            img_bit5.SizeMode = PictureBoxSizeMode.Zoom;
            img_bit6.SizeMode = PictureBoxSizeMode.Zoom;
            img_bit7.SizeMode = PictureBoxSizeMode.Zoom;
            GrayScale_Visualize_bits.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Load_img_btn_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                //Image_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
                Image_Visualize.Image = image;
            }
        }

        private void Gray_Scale_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                Bitmap grayScale_img = new Bitmap(width, height);

                #region
                Bitmap bit7 = new Bitmap(width, height);
                Bitmap bit6 = new Bitmap(width, height);
                Bitmap bit5 = new Bitmap(width, height);
                Bitmap bit4 = new Bitmap(width, height);
                Bitmap bit3 = new Bitmap(width, height);
                Bitmap bit2 = new Bitmap(width, height);
                Bitmap bit1 = new Bitmap(width, height);
                Bitmap bit0 = new Bitmap(width, height);

                Bitmap merge_bit5_2_bit8 = new Bitmap(width, height);
                #endregion

                Bitmap oriRBG_img = (Bitmap)this.Image_Visualize.Image;
                Color pixel;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int merge_res = 0;

                        pixel = oriRBG_img.GetPixel(x, y);
                        int r, g, b, res = 0;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        res = (299 * r + 587 * g + 114 * b) / 1000;  // ver. 1
                        grayScale_img.SetPixel(x, y, Color.FromArgb(res, res, res));

                        #region
                        int tmp = 0;
                        tmp = res & 0x01;
                        if (tmp != 0) bit0.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit0.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        tmp = res & 0x02;
                        if (tmp != 0) bit1.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit1.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        tmp = res & 0x04;
                        if (tmp != 0) bit2.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit2.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        tmp = res & 0x08;
                        if (tmp != 0) bit3.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit3.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        tmp = res & 0x10;
                        if (tmp != 0) bit4.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit4.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        tmp = res & 0x20;
                        if (tmp != 0) bit5.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit5.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        tmp = res & 0x40;
                        if (tmp != 0) bit6.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit6.SetPixel(x, y, Color.FromArgb(0, 0, 0));

                        tmp = res & 0x80;
                        if (tmp != 0) bit7.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else bit7.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        #endregion

                        #region
                        tmp = res & 0x10;
                        merge_res += tmp;

                        tmp = res & 0x20;
                        merge_res += tmp;

                        tmp = res & 0x40;
                        merge_res += tmp;

                        tmp = res & 0x80;
                        merge_res += tmp;

                        merge_bit5_2_bit8.SetPixel(x, y, Color.FromArgb(merge_res, merge_res, merge_res));
                        #endregion
                    }
                }

                //this.GrayScale_Visualize.Image = grayScale_img;
                this.GrayScale_Visualize.Image = grayScale_img;
                this.img_bit0.Image = bit0;
                this.img_bit1.Image = bit1;
                this.img_bit2.Image = bit2;
                this.img_bit3.Image = bit3;
                this.img_bit4.Image = bit4;
                this.img_bit5.Image = bit5;
                this.img_bit6.Image = bit6;
                this.img_bit7.Image = bit7;

                this.GrayScale_Visualize_bits.Image = merge_bit5_2_bit8;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }
    }
}