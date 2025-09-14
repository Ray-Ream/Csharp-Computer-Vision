namespace Wei_DIP_edgeDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
            EdgeDetection_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void LoadImg_And_GrayScale_btn_Click(object sender, EventArgs e)
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

        private void edgeDetection_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                int[,] sboel_res_recorder = new int[width, height];
                Bitmap sobel_img = new Bitmap(width, height);
                Bitmap oriRGB_img = (Bitmap)this.Image_Visualize.Image;

                int[,] sobelX = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                int[,] sobelY = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

                int maxGradient = int.MinValue;
                int minGradient = int.MaxValue;
                int edgeDetection_thres = 0;

                if (!string.IsNullOrEmpty(edgeDetection_tb.Text))
                {
                    edgeDetection_thres = int.Parse(edgeDetection_tb.Text);
                }

                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        int gx = 0;
                        int gy = 0;

                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                Color pixel = oriRGB_img.GetPixel(x + i, y + j);
                                int grayValue = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

                                gx += grayValue * sobelX[i + 1, j + 1];
                                gy += grayValue * sobelY[i + 1, j + 1];
                            }
                        }

                        int gradient = (int)Math.Sqrt(gx * gx + gy * gy);
                        sboel_res_recorder[x, y] = gradient;

                        if (gradient > maxGradient)
                        {
                            maxGradient = gradient;
                        }

                        if (gradient < minGradient)
                        {
                            minGradient = gradient;
                        }
                    }
                }

                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        int gradient = sboel_res_recorder[x, y];
                        int normalizedValue = (int)((gradient - minGradient) * 255.0 / (maxGradient - minGradient));

                        if (edgeDetection_thres > 0)
                        {
                            if (normalizedValue >= edgeDetection_thres)
                            {
                                sobel_img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                            }
                            else
                            {
                                sobel_img.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
                        }
                        else
                        {
                            sobel_img.SetPixel(x, y, Color.FromArgb(normalizedValue, normalizedValue, normalizedValue));
                        }
                    }
                }

                this.EdgeDetection_Visualize.Image = sobel_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }

        private void prewitt_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = this.Image_Visualize.Image.Height;
                int width = this.Image_Visualize.Image.Width;
                int[,] sboel_res_recorder = new int[width, height];
                Bitmap sobel_img = new Bitmap(width, height);
                Bitmap oriRGB_img = (Bitmap)this.Image_Visualize.Image;

                int[,] sobelX = new int[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
                int[,] sobelY = new int[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };

                int maxGradient = int.MinValue;
                int minGradient = int.MaxValue;
                int edgeDetection_thres = 0;

                if (!string.IsNullOrEmpty(edgeDetection_tb.Text))
                {
                    edgeDetection_thres = int.Parse(edgeDetection_tb.Text);
                }

                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        int gx = 0;
                        int gy = 0;

                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                Color pixel = oriRGB_img.GetPixel(x + i, y + j);
                                int grayValue = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

                                gx += grayValue * sobelX[i + 1, j + 1];
                                gy += grayValue * sobelY[i + 1, j + 1];
                            }
                        }

                        int gradient = (int)Math.Sqrt(gx * gx + gy * gy);
                        sboel_res_recorder[x, y] = gradient;

                        if (gradient > maxGradient)
                        {
                            maxGradient = gradient;
                        }

                        if (gradient < minGradient)
                        {
                            minGradient = gradient;
                        }
                    }
                }

                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        int gradient = sboel_res_recorder[x, y];
                        int normalizedValue = (int)((gradient - minGradient) * 255.0 / (maxGradient - minGradient));

                        if (edgeDetection_thres > 0)
                        {
                            if (normalizedValue >= edgeDetection_thres)
                            {
                                sobel_img.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                            }
                            else
                            {
                                sobel_img.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
                        }
                        else
                        {
                            sobel_img.SetPixel(x, y, Color.FromArgb(normalizedValue, normalizedValue, normalizedValue));
                        }
                    }
                }

                this.EdgeDetection_Visualize.Image = sobel_img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("請先載入圖像！ 錯誤訊息: " + ex.Message, "System Message...");
            }
        }
    }
}