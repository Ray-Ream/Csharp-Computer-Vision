namespace DIP_Wei_BoostFilter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Visualize_Image_GrayScale.SizeMode = PictureBoxSizeMode.Zoom;
            Visualize_BoostFilter_4.SizeMode = PictureBoxSizeMode.Zoom;
            Visualize_BoostFilter_8.SizeMode = PictureBoxSizeMode.Zoom;
            boost_value_tb.Text = "1";
        }

        private void Load_img_btn_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                Visualize_Image_GrayScale.Image = image;
                GrayScale();
            }
        }

        private void GrayScale()
        {
            try
            {
                int height = this.Visualize_Image_GrayScale.Image.Height;
                int width = this.Visualize_Image_GrayScale.Image.Width;
                Bitmap grayScale_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Visualize_Image_GrayScale.Image;
                Color pixel;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        pixel = oriRBG_img.GetPixel(x, y);
                        int r, g, b, res = 0;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;
                        res = (299 * r + 587 * g + 114 * b) / 1000;  // ver. 1
                        grayScale_img.SetPixel(x, y, Color.FromArgb(res, res, res));
                    }
                }

                Visualize_Image_GrayScale.Image = grayScale_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }

        private void boostFilter_btn_4_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Visualize_Image_GrayScale.Image.Height;
                int width = this.Visualize_Image_GrayScale.Image.Width;
                Bitmap boostFiltered_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Visualize_Image_GrayScale.Image;

                double input_A = Convert.ToDouble(boost_value_tb.Text);
                int[] pixel_mask = new int[9];
                double[] boostFIlter_mask = new double[] { 0, -1, 0, -1, input_A + 4, -1, 0, -1, 0 };
                int pixS = 0;

                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        pixel_mask[0] = oriRBG_img.GetPixel(x - 1, y - 1).G;
                        pixel_mask[1] = oriRBG_img.GetPixel(x, y - 1).G;
                        pixel_mask[2] = oriRBG_img.GetPixel(x + 1, y - 1).G;
                        pixel_mask[3] = oriRBG_img.GetPixel(x - 1, y).G;
                        pixel_mask[4] = oriRBG_img.GetPixel(x, y).G;
                        pixel_mask[5] = oriRBG_img.GetPixel(x + 1, y).G;
                        pixel_mask[6] = oriRBG_img.GetPixel(x - 1, y + 1).G;
                        pixel_mask[7] = oriRBG_img.GetPixel(x, y + 1).G;
                        pixel_mask[8] = oriRBG_img.GetPixel(x + 1, y + 1).G;
                        pixS = 0;
                        for (int i = 0; i < 9; i++)
                            pixS += Convert.ToInt16(pixel_mask[i] * boostFIlter_mask[i]);

                        if (pixS < 0) pixS = 0;
                        if (pixS > 255) pixS = 255;

                        boostFiltered_img.SetPixel(x, y, Color.FromArgb(pixS, pixS, pixS));
                    }
                }
                this.Visualize_BoostFilter_4.Image = boostFiltered_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }

        private void boostFilter_btn_8_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Visualize_Image_GrayScale.Image.Height;
                int width = this.Visualize_Image_GrayScale.Image.Width;
                Bitmap boostFiltered_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Visualize_Image_GrayScale.Image;

                double input_A = Convert.ToDouble(boost_value_tb.Text);
                int[] pixel_mask = new int[9];
                double[] boostFIlter_mask = new double[] { -1, -1, -1, -1, input_A + 8, -1, -1, -1, -1 };
                int pixS = 0;

                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        pixel_mask[0] = oriRBG_img.GetPixel(x - 1, y - 1).G;
                        pixel_mask[1] = oriRBG_img.GetPixel(x, y - 1).G;
                        pixel_mask[2] = oriRBG_img.GetPixel(x + 1, y - 1).G;
                        pixel_mask[3] = oriRBG_img.GetPixel(x - 1, y).G;
                        pixel_mask[4] = oriRBG_img.GetPixel(x, y).G;
                        pixel_mask[5] = oriRBG_img.GetPixel(x + 1, y).G;
                        pixel_mask[6] = oriRBG_img.GetPixel(x - 1, y + 1).G;
                        pixel_mask[7] = oriRBG_img.GetPixel(x, y + 1).G;
                        pixel_mask[8] = oriRBG_img.GetPixel(x + 1, y + 1).G;
                        pixS = 0;
                        for (int i = 0; i < 9; i++)
                            pixS += Convert.ToInt16(pixel_mask[i] * boostFIlter_mask[i]);

                        if (pixS < 0) pixS = 0;
                        if (pixS > 255) pixS = 255;

                        boostFiltered_img.SetPixel(x, y, Color.FromArgb(pixS, pixS, pixS));
                    }
                }
                this.Visualize_BoostFilter_8.Image = boostFiltered_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }
    }
}