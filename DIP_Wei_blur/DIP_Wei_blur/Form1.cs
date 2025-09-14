namespace DIP_Wei_blur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
            Visualize_smoothing_filter.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Load_img_btn_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                Image_Visualize.Image = image;
                GrayScale();
            }
        }

        private void GrayScale()
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                Bitmap grayScale_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Image_Visualize.Image;
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

                Image_Visualize.Image = grayScale_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }

        private void Smoothing_Filter_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                Bitmap smoothing_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Image_Visualize.Image;
                int[] pixel_mask = new int[9];
                int[] smoothing = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
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
                            pixS += (pixel_mask[i] * smoothing[i]);
                        pixS /= 9;
                        smoothing_img.SetPixel(x, y, Color.FromArgb(pixS, pixS, pixS));
                    }
                }
                this.Visualize_smoothing_filter.Image = smoothing_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }

        private void Medium_Filter_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                Bitmap median_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Image_Visualize.Image;
                int[] pixel_values = new int[9];

                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        pixel_values[0] = oriRBG_img.GetPixel(x - 1, y - 1).G;
                        pixel_values[1] = oriRBG_img.GetPixel(x, y - 1).G;
                        pixel_values[2] = oriRBG_img.GetPixel(x + 1, y - 1).G;
                        pixel_values[3] = oriRBG_img.GetPixel(x - 1, y).G;
                        pixel_values[4] = oriRBG_img.GetPixel(x, y).G;
                        pixel_values[5] = oriRBG_img.GetPixel(x + 1, y).G;
                        pixel_values[6] = oriRBG_img.GetPixel(x - 1, y + 1).G;
                        pixel_values[7] = oriRBG_img.GetPixel(x, y + 1).G;
                        pixel_values[8] = oriRBG_img.GetPixel(x + 1, y + 1).G;

                        Array.Sort(pixel_values);
                        int median = pixel_values[4];
                        median_img.SetPixel(x, y, Color.FromArgb(median, median, median));
                    }
                }
                this.Visualize_smoothing_filter.Image = median_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }

        }
    }
}