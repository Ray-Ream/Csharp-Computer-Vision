using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DIP_3D
{
    public partial class Form1 : Form
    {
        Point left_redPointCenter;
        Point right_redPointCenter;
        private readonly object imageLock = new object();

        public Form1()
        {
            InitializeComponent();

            AllVisualizeImage_2_Zoom();
            img01_label.Text = "";
            img02_label.Text = "";
            moveDist_tb.Text = "20";

            leftImg_center_tb.Text = "1237 802";
            rightImg_center_tb.Text = "896 808";
            updatePointCenter();
        }

        public void AllVisualizeImage_2_Zoom()
        {
            visualize_leftImage.SizeMode = PictureBoxSizeMode.Zoom;
            visualize_RightImage.SizeMode = PictureBoxSizeMode.Zoom;
            visualize_templateImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void AllVisualizeImage_2_Normal()
        {
            visualize_leftImage.SizeMode = PictureBoxSizeMode.Normal;
            visualize_RightImage.SizeMode = PictureBoxSizeMode.Normal;
            visualize_templateImage.SizeMode = PictureBoxSizeMode.Normal;
        }

        public void updatePointCenter()
        {
            if (!string.IsNullOrEmpty(leftImg_center_tb.Text))
            {
                string[] coordinate = leftImg_center_tb.Text.Split(" ");
                left_redPointCenter.X = Convert.ToInt32(coordinate[0]);
                left_redPointCenter.Y = Convert.ToInt32(coordinate[1]);
            }
            if (!string.IsNullOrEmpty(rightImg_center_tb.Text))
            {
                string[] coordinate = rightImg_center_tb.Text.Split(" ");
                right_redPointCenter.X = Convert.ToInt32(coordinate[0]);
                right_redPointCenter.Y = Convert.ToInt32(coordinate[1]);
            }
        }

        private void loadLeftImage_btn_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                visualize_leftImage.Image = image;

                img01_label.Text = $"({left_redPointCenter.X}, {left_redPointCenter.Y})";
            }
        }

        private void loadRightImage_btn_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                visualize_RightImage.Image = image;

                img02_label.Text = $"({right_redPointCenter.X}, {right_redPointCenter.Y})";
            }
        }

        private void loadTemplate_btn_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                visualize_templateImage.Image = image;
            }
        }

        private void calculationResults_btn_Click(object sender, EventArgs e)
        {
            double focalLength = 12.07;
            double baseline = 20.0;

            if (!string.IsNullOrEmpty(moveDist_tb.Text))
            {
                baseline = double.Parse(moveDist_tb.Text);
            }
            updatePointCenter();

            double disparity = Math.Abs(right_redPointCenter.X - left_redPointCenter.X) * 0.0033450704225352;
            double depth = (focalLength * baseline) / disparity;
            depth = Math.Round(depth, 2);
            calculationResults_label.Text = Convert.ToString(depth) + " 公分";
        }

        private void cosineSimilarity_btn_Click(object sender, EventArgs e)
        {
            Bitmap sourceImage_Left = new Bitmap(visualize_leftImage.Image);
            Bitmap sourceImage_Right = new Bitmap(visualize_RightImage.Image);
            Bitmap templateImage = new Bitmap(visualize_templateImage.Image);
            Point matchLocation;

            matchLocation = templateMatching(sourceImage_Left, templateImage);  // Left image
            using (Graphics g = Graphics.FromImage(visualize_leftImage.Image))
            using (Pen pen = new Pen(Color.Red, 2))
            {
                int boxWidth = visualize_templateImage.Image.Width;
                int boxHeight = visualize_templateImage.Image.Height;
                Rectangle box = new Rectangle(matchLocation.X, matchLocation.Y, boxWidth, boxHeight);
                g.DrawRectangle(pen, box);

                int boxWidth_half = boxWidth / 2;
                int boxHeight_half = boxHeight / 2;
                img01_label.Text = $"({matchLocation.X + boxWidth_half}, {matchLocation.Y + boxHeight_half})";
                leftImg_center_tb.Text = $"{matchLocation.X + boxWidth_half} {matchLocation.Y + boxHeight_half}";
            }

            matchLocation = templateMatching(sourceImage_Right, templateImage);  // Right image
            using (Graphics g = Graphics.FromImage(visualize_RightImage.Image))
            using (Pen pen = new Pen(Color.Red, 2))
            {
                int boxWidth = visualize_templateImage.Image.Width;
                int boxHeight = visualize_templateImage.Image.Height;
                Rectangle box = new Rectangle(matchLocation.X, matchLocation.Y, boxWidth, boxHeight);
                g.DrawRectangle(pen, box);

                int boxWidth_half = boxWidth / 2;
                int boxHeight_half = boxHeight / 2;
                img02_label.Text = $"({matchLocation.X + boxWidth_half}, {matchLocation.Y + boxHeight_half})";
                rightImg_center_tb.Text = $"{matchLocation.X + boxWidth_half} {matchLocation.Y + boxHeight_half}";
            }

            visualize_leftImage.Refresh();
            visualize_RightImage.Refresh();
            similarityLabel.Text = "餘弦相似度計算完成";
        }

        private Point templateMatching(Bitmap sourceImage, Bitmap templateImage)
        {
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;
            int templateWidth = templateImage.Width;
            int templateHeight = templateImage.Height;

            double maxSimilarity = 0.0;
            Point bestMatch = Point.Empty;

            BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0, sourceWidth, sourceHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData templateData = templateImage.LockBits(new Rectangle(0, 0, templateWidth, templateHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int sourceStride = sourceData.Stride;
            int templateStride = templateData.Stride;

            byte[] sourcePixels = new byte[sourceStride * sourceHeight];
            byte[] templatePixels = new byte[templateStride * templateHeight];

            Marshal.Copy(sourceData.Scan0, sourcePixels, 0, sourceStride * sourceHeight);
            Marshal.Copy(templateData.Scan0, templatePixels, 0, templateStride * templateHeight);

            sourceImage.UnlockBits(sourceData);
            templateImage.UnlockBits(templateData);

            Parallel.For(0, sourceHeight - templateHeight + 1, y =>
            {
                for (int x = 0; x <= sourceWidth - templateWidth; x++)
                {
                    if (maxSimilarity >= 0.995) break;

                    double similarity = CosineSimilarityParallel(sourcePixels, templatePixels, sourceStride, templateStride, x, y, sourceWidth, templateWidth, templateHeight);

                    if (similarity > maxSimilarity)
                    {
                        maxSimilarity = similarity;
                        bestMatch = new Point(x, y);
                    }
                }
            });

            return bestMatch;
        }

        private static unsafe double CosineSimilarityParallel(byte[] sourcePixels, byte[] templatePixels, int sourceStride, int templateStride, int x, int y, int sourceWidth, int templateWidth, int templateHeight)
        {
            double dotProductR = 0.0;
            double dotProductG = 0.0;
            double dotProductB = 0.0;
            double magnitudeA_R = 0.0;
            double magnitudeA_G = 0.0;
            double magnitudeA_B = 0.0;
            double magnitudeB_R = 0.0;
            double magnitudeB_G = 0.0;
            double magnitudeB_B = 0.0;

            int templateOffset = 0;

            for (int ty = 0; ty < templateHeight; ty++)
            {
                int sourceOffset = ((y + ty) * sourceStride) + (x * 3);

                for (int tx = 0; tx < templateWidth; tx++)
                {
                    double sourceR = sourcePixels[sourceOffset];
                    double sourceG = sourcePixels[sourceOffset + 1];
                    double sourceB = sourcePixels[sourceOffset + 2];

                    double templateR = templatePixels[templateOffset];
                    double templateG = templatePixels[templateOffset + 1];
                    double templateB = templatePixels[templateOffset + 2];

                    dotProductR += sourceR * templateR;
                    dotProductG += sourceG * templateG;
                    dotProductB += sourceB * templateB;

                    magnitudeA_R += sourceR * sourceR;
                    magnitudeA_G += sourceG * sourceG;
                    magnitudeA_B += sourceB * sourceB;

                    magnitudeB_R += templateR * templateR;
                    magnitudeB_G += templateG * templateG;
                    magnitudeB_B += templateB * templateB;

                    sourceOffset += 3;
                    templateOffset += 3;
                }

                templateOffset += templateStride - (templateWidth * 3);
            }

            double magnitudeA = Math.Sqrt(magnitudeA_R + magnitudeA_G + magnitudeA_B);
            double magnitudeB = Math.Sqrt(magnitudeB_R + magnitudeB_G + magnitudeB_B);

            if (magnitudeA == 0.0 || magnitudeB == 0.0)
                return 0.0;

            double dotProduct = dotProductR + dotProductG + dotProductB;

            return dotProduct / (magnitudeA * magnitudeB);
        }

        private void SAD_btn_Click(object sender, EventArgs e)
        {
            Bitmap sourceImage_Left = new Bitmap(visualize_leftImage.Image);
            Bitmap sourceImage_Right = new Bitmap(visualize_RightImage.Image);
            Bitmap templateImage = new Bitmap(visualize_templateImage.Image);
            Point matchLocation;

            matchLocation = templateMatchingSAD(sourceImage_Left, templateImage);  // Left image
            using (Graphics g = Graphics.FromImage(visualize_leftImage.Image))
            using (Pen pen = new Pen(Color.Red, 2))
            {
                int boxWidth = visualize_templateImage.Image.Width;
                int boxHeight = visualize_templateImage.Image.Height;
                Rectangle box = new Rectangle(matchLocation.X, matchLocation.Y, boxWidth, boxHeight);
                g.DrawRectangle(pen, box);

                int boxWidth_half = boxWidth / 2;
                int boxHeight_half = boxHeight / 2;
                img01_label.Text = $"({matchLocation.X + boxWidth_half}, {matchLocation.Y + boxHeight_half})";
                leftImg_center_tb.Text = $"{matchLocation.X + boxWidth_half} {matchLocation.Y + boxHeight_half}";
            }

            matchLocation = templateMatchingSAD(sourceImage_Right, templateImage);  // Right image
            using (Graphics g = Graphics.FromImage(visualize_RightImage.Image))
            using (Pen pen = new Pen(Color.Red, 2))
            {
                int boxWidth = visualize_templateImage.Image.Width;
                int boxHeight = visualize_templateImage.Image.Height;
                Rectangle box = new Rectangle(matchLocation.X, matchLocation.Y, boxWidth, boxHeight);
                g.DrawRectangle(pen, box);

                int boxWidth_half = boxWidth / 2;
                int boxHeight_half = boxHeight / 2;
                img02_label.Text = $"({matchLocation.X + boxWidth_half}, {matchLocation.Y + boxHeight_half})";
                rightImg_center_tb.Text = $"{matchLocation.X + boxWidth_half} {matchLocation.Y + boxHeight_half}";
            }

            visualize_leftImage.Refresh();
            visualize_RightImage.Refresh();
            similarityLabel.Text = "絕對差異總和計算完成";
        }

        private Point templateMatchingSAD(Bitmap sourceImage, Bitmap templateImage)
        {
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;
            int templateWidth = templateImage.Width;
            int templateHeight = templateImage.Height;

            int minDifference = int.MaxValue;
            Point bestMatch = Point.Empty;

            BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0, sourceWidth, sourceHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData templateData = templateImage.LockBits(new Rectangle(0, 0, templateWidth, templateHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int sourceStride = sourceData.Stride;
            int templateStride = templateData.Stride;

            byte[] sourcePixels = new byte[sourceStride * sourceHeight];
            byte[] templatePixels = new byte[templateStride * templateHeight];

            Marshal.Copy(sourceData.Scan0, sourcePixels, 0, sourceStride * sourceHeight);
            Marshal.Copy(templateData.Scan0, templatePixels, 0, templateStride * templateHeight);

            sourceImage.UnlockBits(sourceData);
            templateImage.UnlockBits(templateData);

            Parallel.For(0, sourceHeight - templateHeight + 1, y =>
            {
                for (int x = 0; x <= sourceWidth - templateWidth; x++)
                {
                    if (minDifference <= 3) break;

                    int totalDifference = CalculateSAD(sourcePixels, templatePixels, sourceStride, templateStride, x, y, sourceWidth, templateWidth, templateHeight);

                    if (totalDifference < minDifference)
                    {
                        minDifference = totalDifference;
                        bestMatch = new Point(x, y);
                    }
                }
            });

            return bestMatch;
        }

        private int CalculateSAD(byte[] sourcePixels, byte[] templatePixels, int sourceStride, int templateStride, int x, int y, int sourceWidth, int templateWidth, int templateHeight)
        {
            int totalDifference = 0;

            for (int ty = 0; ty < templateHeight; ty++)
            {
                for (int tx = 0; tx < templateWidth; tx++)
                {
                    int sourceOffset = ((y + ty) * sourceStride) + ((x + tx) * 3);
                    int templateOffset = (ty * templateStride) + (tx * 3);

                    int diffR = Math.Abs(sourcePixels[sourceOffset] - templatePixels[templateOffset]);
                    int diffG = Math.Abs(sourcePixels[sourceOffset + 1] - templatePixels[templateOffset + 1]);
                    int diffB = Math.Abs(sourcePixels[sourceOffset + 2] - templatePixels[templateOffset + 2]);

                    totalDifference += diffR + diffG + diffB;
                }
            }

            return totalDifference;
        }
    }
}