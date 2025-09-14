namespace DIP_Wei_gamma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image_Visualize.SizeMode = PictureBoxSizeMode.Zoom;  // Fit the image into the PictureBox
            GrayScale_Visualize.SizeMode = PictureBoxSizeMode.Zoom;  // Fit the image into the PictureBox
            Gamma_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
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

                //this.GrayScale_Visualize.Image = grayScale_img;
                this.GrayScale_Visualize.Image = grayScale_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }

        private void Chnage_Gamma_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                Bitmap newGamma_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Image_Visualize.Image;
                
                int[] xferFunc = new int[256];
                double pow255, gamma;
                gamma = Convert.ToDouble(Gamma_tb.Text);
                if (gamma < 0) gamma = -gamma;
                else if (gamma > 100) gamma = 100;
                pow255 = Math.Pow(255.0, gamma);
                for (int x = 0; x < 256; x++)
                {
                    xferFunc[x] = (int)(Math.Pow((double)x, gamma) / pow255 * 255 + 0.5);
                }

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int res = xferFunc[oriRBG_img.GetPixel(x, y).G];
                        newGamma_img.SetPixel(x, y, Color.FromArgb(res, res, res));
                    }
                }

                //this.GrayScale_Visualize.Image = grayScale_img;
                this.Gamma_Visualize.Image = newGamma_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }
    }
}