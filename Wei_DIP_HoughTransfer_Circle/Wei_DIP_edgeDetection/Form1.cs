using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Wei_DIP_edgeDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
            EdgeDetection_Visualize.SizeMode = PictureBoxSizeMode.Zoom;
            Visualize_HoughTransform.SizeMode = PictureBoxSizeMode.Zoom;
        }

        struct XYPoint
        {
            public short X;
            public short Y;
        }

        struct LineParameters
        {
            public int Angle;
            public int Distance;
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
                Bitmap original = new Bitmap(Image_Visualize.Image);
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);

                for (int x = 1; x < original.Width - 1; x++)
                {
                    for (int y = 1; y < original.Height - 1; y++)
                    {
                        int[] pixelX = new int[9];
                        int[] pixelY = new int[9];

                        // Sobel edge detection in X direction
                        pixelX[0] = original.GetPixel(x - 1, y - 1).R;
                        pixelX[1] = original.GetPixel(x, y - 1).R;
                        pixelX[2] = original.GetPixel(x + 1, y - 1).R;
                        pixelX[3] = original.GetPixel(x - 1, y).R;
                        pixelX[4] = original.GetPixel(x, y).R;
                        pixelX[5] = original.GetPixel(x + 1, y).R;
                        pixelX[6] = original.GetPixel(x - 1, y + 1).R;
                        pixelX[7] = original.GetPixel(x, y + 1).R;
                        pixelX[8] = original.GetPixel(x + 1, y + 1).R;
                        int edgeX = ((pixelX[0] + (2 * pixelX[1]) + pixelX[2]) - (pixelX[6] + (2 * pixelX[7]) + pixelX[8]));

                        // Sobel edge detection in Y direction
                        pixelY[0] = original.GetPixel(x - 1, y - 1).R;
                        pixelY[1] = original.GetPixel(x, y - 1).R;
                        pixelY[2] = original.GetPixel(x + 1, y - 1).R;
                        pixelY[3] = original.GetPixel(x - 1, y).R;
                        pixelY[4] = original.GetPixel(x, y).R;
                        pixelY[5] = original.GetPixel(x + 1, y).R;
                        pixelY[6] = original.GetPixel(x - 1, y + 1).R;
                        pixelY[7] = original.GetPixel(x, y + 1).R;
                        pixelY[8] = original.GetPixel(x + 1, y + 1).R;
                        int edgeY = ((pixelY[2] + (2 * pixelY[5]) + pixelY[8]) - (pixelY[0] + (2 * pixelY[3]) + pixelY[6]));

                        int edge = Math.Min(255, Math.Max(0, Math.Abs(edgeX) + Math.Abs(edgeY))); // Absolute sum of X and Y Sobel edges

                        newBitmap.SetPixel(x, y, Color.FromArgb(edge, edge, edge));
                    }
                }

                EdgeDetection_Visualize.Image = newBitmap;
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


        private void hough_transform_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int Height = this.EdgeDetection_Visualize.Image.Height;
                int Width = this.EdgeDetection_Visualize.Image.Width;
                Bitmap oldBitmap = (Bitmap)this.EdgeDetection_Visualize.Image;
                int EdgeNum = 0;
                XYPoint[] EdgePoint = new XYPoint[Width * Height];
                LineParameters[] Line = new LineParameters[Width * Height];
                for (short x = 0; x < Width; x++)
                    for (short y = 0; y < Height; y++)
                        if (oldBitmap.GetPixel(x, y).G == 255)
                        {
                            EdgePoint[EdgeNum].X = x;
                            EdgePoint[EdgeNum].Y = y;
                            EdgeNum++;
                        }

                int AngleNum = 360;
                int DistNum = (int)Math.Sqrt(Width * Width + Height * Height) * 2;
                int threshold = Math.Min(Width, Height) / 5;
                int HoughSpaceMax = 0;
                Bitmap newBitmap = new Bitmap(AngleNum, DistNum);
                int pixH;
                double DeltaAngle, DeltaDist;
                double MaxDist, MinDist;
                double Angle, Dist;
                int LineCount;
                int[,] HoughSpace = new int[AngleNum, DistNum];
                MaxDist = Math.Sqrt(Width * Width + Height * Height);
                MinDist = (double)-Width;
                DeltaAngle = Math.PI / AngleNum;
                DeltaDist = (MaxDist - MinDist) / DistNum;

                // Hough Space
                for (int i = 0; i < AngleNum; i++)
                    for (int j = 0; j < DistNum; j++)
                        HoughSpace[i, j] = 0;
                for (int i = 0; i < EdgeNum; i++)
                    for (int j = 0; j < AngleNum; j++)
                    {
                        Angle = j * DeltaAngle;
                        Dist = EdgePoint[i].X * Math.Cos(Angle) + EdgePoint[i].Y * Math.Sin(Angle);
                        HoughSpace[j, (int)((Dist - MinDist) / DeltaDist)]++;
                    }

                // Vote line in Hough Space
                LineCount = 0;
                for (int i = 0; i < AngleNum; i++)
                    for (int j = 0; j < DistNum; j++)
                    {
                        if (HoughSpace[i, j] > HoughSpaceMax) HoughSpaceMax = HoughSpace[i, j];
                        if (HoughSpace[i, j] >= threshold)
                        {
                            Line[LineCount].Angle = i;
                            Line[LineCount].Distance = j;
                            LineCount++;
                        }
                    }

                // Draw Hough transform candidates
                for (int x = 0; x < AngleNum; x++)
                    for (int y = 0; y < DistNum; y++)
                    {
                        pixH = 255 - (HoughSpaceMax - HoughSpace[x, y]) * 255 / HoughSpaceMax;
                        if (HoughSpace[x, y] > threshold)
                            newBitmap.SetPixel(x, y, Color.FromArgb(pixH, 0, 0));
                        else
                            newBitmap.SetPixel(x, y, Color.FromArgb(pixH, pixH, pixH));
                    }
                this.Visualize_HoughTransform.Image = newBitmap;

                for (int i = 0; i < LineCount & i < Width * Height; i++)
                {
                    using (StreamWriter sw = new StreamWriter("E:\\DIPCource_hw\\LineEquations.txt"))
                    {
                        for (int ii = 0; ii < LineCount & ii < Width * Height; ii++)
                        {
                            double tangent = Math.Tan(Line[ii].Angle * DeltaAngle);

                            double slope = tangent != 0 ? -1 / tangent : double.PositiveInfinity;
                            double intercept = (Line[ii].Distance * DeltaDist - Width * Height * Math.Sin(Line[ii].Angle * DeltaAngle)) / (tangent != 0 ? Math.Cos(Line[ii].Angle * DeltaAngle) : 1);
                            slope = Math.Round(slope, 2);
                            intercept = Math.Round(intercept);

                            sw.WriteLine($"Equation of line {ii + 1}: y = {slope}x + {intercept}");

                            using (Graphics g = Graphics.FromImage(oldBitmap))
                            {
                                Font font = new Font("Arial", 10);
                                SolidBrush brush = new SolidBrush(Color.Red);

                                PointF textPosition = new PointF(10, 20 + ii * 20);
                                g.DrawString($"Line {ii + 1}: y = {slope}x + {intercept}", font, brush, textPosition);
                            }
                        }
                    }

                    for (int x = 0; x < Width; x++)
                    {
                        int y = (int)((Line[i].Distance * DeltaDist + MinDist - x * Math.Cos(Line[i].Angle * DeltaAngle)) / Math.Sin(Line[i].Angle * DeltaAngle));
                        if (y >= 0 & y < Height)
                        {
                            pixH = oldBitmap.GetPixel(x, y).G;
                            oldBitmap.SetPixel(x, y, Color.FromArgb(pixH ^ 255, pixH, pixH));
                        }
                    }
                    for (int y = 0; y < Height; y++)
                    {
                        int x = (int)((Line[i].Distance * DeltaDist + MinDist - y * Math.Sin(Line[i].Angle * DeltaAngle)) / Math.Cos(Line[i].Angle * DeltaAngle));
                        if (x >= 0 & x < Width)
                        {
                            pixH = oldBitmap.GetPixel(x, y).G;
                            oldBitmap.SetPixel(x, y, Color.FromArgb(pixH ^ 255, pixH, pixH));
                        }
                    }
                }

                // Result
                this.EdgeDetection_Visualize.Image = oldBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }

        private void hough_circle_transform_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int Height = this.EdgeDetection_Visualize.Image.Height;
                int Width = this.EdgeDetection_Visualize.Image.Width;
                Bitmap oldBitmap = (Bitmap)this.EdgeDetection_Visualize.Image;
                Bitmap newBitmap = new Bitmap(Width, Height);

                int minRadius = 30;
                int maxRadius = 150;
                int radiusStep = 5;
                int threshold = 100;
                int RadiusDiff = maxRadius - minRadius;
                int HoughSpaceMax = 0;

                int[,,] HoughSpace = new int[Width, Height, RadiusDiff];
                int[,] HoughSpace_show_ShowTransform = new int[Width, Height];
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                        if (oldBitmap.GetPixel(x, y).R == 255)
                            for (int r = minRadius; r < maxRadius; r += radiusStep)
                                for (int theta = 0; theta < 360; theta++)
                                {
                                    int a = x - (int)(r * Math.Cos(theta * Math.PI / 180));
                                    int b = y - (int)(r * Math.Sin(theta * Math.PI / 180));

                                    if (a >= 0 && a < Width && b >= 0 && b < Height)
                                    {
                                        HoughSpace[a, b, r - minRadius]++;
                                        HoughSpace_show_ShowTransform[a, b]++;
                                        if (HoughSpace_show_ShowTransform[a, b] > HoughSpaceMax) HoughSpaceMax = HoughSpace_show_ShowTransform[a, b];
                                    }
                                }

                using (Graphics g = Graphics.FromImage(oldBitmap))
                {
                    Pen redPen = new Pen(Color.Red, 2);

                    using (StreamWriter writer = new StreamWriter("E:\\DIPCource_hw\\CircleEquations.txt"))
                    {
                        for (int x = 0; x < Width; x++)
                            for (int y = 0; y < Height; y++)
                            {
                                int maxDiff = 0, maxDiffZ = 0, houghValue = 0;
                                for (int z = 0; z < RadiusDiff; z += radiusStep)
                                {
                                    houghValue = HoughSpace[x, y, z];
                                    if (houghValue > threshold && houghValue > maxDiff)
                                    {
                                        maxDiff = houghValue;
                                        maxDiffZ = z;
                                    }
                                }
                                if (maxDiffZ != 0)
                                {
                                    int radius = minRadius + maxDiffZ;
                                    writer.WriteLine($"Circle equation: (x - {x})^2 + (y - {y})^2 = {radius}^2");
                                    g.DrawEllipse(redPen, x - radius, y - radius, 2 * radius, 2 * radius);
                                }
                            }
                    }
                }

                // Draw Hough transform candidates
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        int pixH = 255 - (HoughSpaceMax - HoughSpace_show_ShowTransform[x, y]) * 255 / HoughSpaceMax;
                        newBitmap.SetPixel(x, y, Color.FromArgb(pixH, pixH, pixH));
                    }
                this.Visualize_HoughTransform.Image = newBitmap;

                // Show result
                this.EdgeDetection_Visualize.Image = oldBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }

        private void save_hough_transform_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Bitmap Image | *.bmp";
                saveFileDialog.Title = "儲存圖片";
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            this.Visualize_HoughTransform.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}