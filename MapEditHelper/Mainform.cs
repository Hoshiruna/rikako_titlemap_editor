using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace MapEditHelper
{
    public partial class Mainform : Form
    {
        private Bitmap? sourceImage;
        private Dictionary<string, Rectangle> tilePositions = new Dictionary<string, Rectangle>();
        private MenuStrip? menuStrip1; // Make menuStrip1 nullable

        private const int TILES_PER_ROW = 24;
        private const int TILES_PER_SECTION = 5;
        private int currentSection = 0;
        private int totalSections = 0;

        public Mainform()
        {
            InitializeComponent();
            
            // Existing button click handlers
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            
            // Set form properties for menu
            this.MainMenuStrip = menuStrip1;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.bmp;*.png;*.jpg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sourceImage = new Bitmap(ofd.FileName);
                    pictureBox1.Image = sourceImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    InitializeTilePositions();
                }
            }
        }

        private void InitializeTilePositions()
        {
            if (sourceImage == null) return;

            int tileSize = 16;
            int tilesPerRow = sourceImage.Width / tileSize;
            int rows = sourceImage.Height / tileSize;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < tilesPerRow; x++)
                {
                    string hexValue = $"{y:X1}{x:X1}";
                    Rectangle tileRect = new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize);
                    tilePositions[hexValue] = tileRect;
                }
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            if (sourceImage == null || string.IsNullOrWhiteSpace(richTextBox1.Text))
                return;

            List<string[]> allRows = ParseInput(richTextBox1.Text);
            if (allRows.Count == 0) return;

            totalSections = (int)Math.Ceiling(allRows.Count / (double)TILES_PER_SECTION);
            currentSection = 0; // Reset to first section
            UpdatePreview();
            UpdateSectionLabel(); // Update the section label
        }

        private void UpdatePreview()
        {
            if (sourceImage == null) return;

            List<string[]> allRows = ParseInput(richTextBox1.Text);
            int tileSize = 16;

            using (Bitmap resultImage = new Bitmap(TILES_PER_ROW * tileSize, TILES_PER_SECTION * tileSize))
            using (Graphics g = Graphics.FromImage(resultImage))
            {
                g.Clear(Color.White); // Clear background

                int startRow = currentSection * TILES_PER_SECTION;
                int endRow = Math.Min(startRow + TILES_PER_SECTION, allRows.Count);

                for (int rowIndex = startRow; rowIndex < endRow; rowIndex++)
                {
                    string[] hexValues = allRows[rowIndex];
                    for (int i = 0; i < Math.Min(hexValues.Length, TILES_PER_ROW); i++)
                    {
                        string hex = hexValues[i].Trim().ToUpper();
                        if (tilePositions.ContainsKey(hex))
                        {
                            int destX = i * tileSize;
                            int destY = (rowIndex - startRow) * tileSize;
                            Rectangle destRect = new Rectangle(destX, destY, tileSize, tileSize);
                            g.DrawImage(sourceImage, destRect, tilePositions[hex], GraphicsUnit.Pixel);
                        }
                    }
                }

                pictureBox2.Image?.Dispose();
                pictureBox2.Image = new Bitmap(resultImage);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private List<string[]> ParseInput(string input)
        {
            List<string[]> result = new List<string[]>();

            // Match content between Row { and }
            string pattern = @"Row\s*\{([^}]+)\}";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    string rowContent = match.Groups[1].Value.Trim();
                    // Extract hex values, removing "0x" prefix
                    string[] hexValues = rowContent.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Replace("0x", ""))
                        .ToArray();

                    if (hexValues.Length > 0)
                    {
                        result.Add(hexValues);
                    }
                }
            }

            return result;
        }

        private void Button3_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        // Add these methods to your Mainform class
        private void LoadTilemap_Click(object? sender, EventArgs e)
        {
            Button1_Click(sender, e); // Reuse existing functionality
        }

        private void LoadMap_Click(object? sender, EventArgs e)
        {
            Button3_Click(sender, e); // Reuse existing functionality
        }

        private void Exit_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Map Edit Helper\nVersion 1.0", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Add these new methods
        private void UpdateSectionLabel()
        {
            lblSectionNumber.Text = $"Section: {currentSection + 1}/{totalSections}";
            btnPrevSection.Enabled = currentSection > 0;
            btnNextSection.Enabled = currentSection < totalSections - 1;
        }

        private void NextSection_Click(object? sender, EventArgs e)
        {
            if (currentSection < totalSections - 1)
            {
                currentSection++;
                UpdatePreview();
                UpdateSectionLabel();
            }
        }

        private void PreviousSection_Click(object? sender, EventArgs e)
        {
            if (currentSection > 0)
            {
                currentSection--;
                UpdatePreview();
                UpdateSectionLabel();
            }
        }
    }
}