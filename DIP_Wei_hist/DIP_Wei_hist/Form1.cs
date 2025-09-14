namespace DIP_Wei_hist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
            Histogram_Equalization_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void Histogram_Equalization_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                Bitmap histogramEqualization_img = new Bitmap(width, height);
                Bitmap oriRBG_img = (Bitmap)this.Image_Visualize.Image;
                int[] histogram = new int[256];
                int[] cumulative_histogram = new int[256];
                int[] xferFunc = new int[256];
                int resolution = height * width;

                for (int i = 0; i < 256; i++)
                    histogram[i] = 0;
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                        histogram[oriRBG_img.GetPixel(x, y).G]++;
                cumulative_histogram[0] = histogram[0];
                for (int x = 1; x < 256; x++)
                    cumulative_histogram[x] = cumulative_histogram[x - 1] + histogram[x];
                for (int x = 0; x < 256; x++)
                    xferFunc[x] = (255 * cumulative_histogram[x]) / resolution;
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        int res = xferFunc[oriRBG_img.GetPixel(x, y).G];
                        histogramEqualization_img.SetPixel(x, y, Color.FromArgb(res, res, res));
                    }
                this.Histogram_Equalization_Visualize.Image = histogramEqualization_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }
    }
}