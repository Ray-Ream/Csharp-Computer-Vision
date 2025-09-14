namespace DIP_3D
{
    public partial class Form1 : Form
    {
        Point left_redPointCenter;
        Point right_redPointCenter;

        public Form1()
        {
            InitializeComponent();

            visualize_leftImage.SizeMode = PictureBoxSizeMode.Zoom;
            visualize_RightImage.SizeMode = PictureBoxSizeMode.Zoom;
            img01_label.Text = "";
            img02_label.Text = "";
            moveDist_tb.Text = "20";

            leftImg_center_tb.Text = "1237 802";
            rightImg_center_tb.Text = "896 808";
            updatePointCenter();
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
            calculationResults_label.Text = Convert.ToString(depth) + " ¤½¤À";
        }
    }
}