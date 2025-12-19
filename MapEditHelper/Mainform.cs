using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;

namespace MapEditHelper
{
    public partial class Mainform : Form
    {
        private Bitmap? sourceImage;
        private Dictionary<string, Rectangle> tilePositions = new Dictionary<string, Rectangle>();
        private MenuStrip? menuStrip1; // Make menuStrip1 nullable
        private List<string[]> parsedRows = new List<string[]>();
        private TilePreviewForm? tilePreviewForm;

        private const int TILES_PER_ROW = 24;
        private const int TILES_PER_SECTION = 5;
        private int currentSection = 0;
        private int totalSections = 0;

        public Mainform()
        {
            InitializeComponent();

            // Ensure window icon is loaded from bundled icon file
            TrySetAppIcon();
            
            // Existing button click handlers
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            
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

                    InitializeTilePositions();
                    ShowTilePreview(sourceImage);
                    GenerateFromText(); // update preview if map text already exists
                }
            }
        }

        private void InitializeTilePositions()
        {
            if (sourceImage == null) return;

            tilePositions.Clear();
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

        private void GenerateFromText(bool showWarnings = false)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                parsedRows.Clear();
                totalSections = 0;
                currentSection = 0;
                ClearPreview();
                UpdateSectionLabel();
                return;
            }

            if (sourceImage == null)
                return;

            parsedRows = ParseInput(richTextBox1.Text);
            if (parsedRows.Count == 0)
            {
                ClearPreview();
                totalSections = 0;
                currentSection = 0;
                UpdateSectionLabel();
                if (showWarnings)
                {
                    MessageBox.Show("No rows found in the map text. Expected lines like 'Row { 0x00, 0x01, ... }'.", "No map rows detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            totalSections = (int)Math.Ceiling(parsedRows.Count / (double)TILES_PER_SECTION);
            currentSection = 0; // Reset to first section
            UpdatePreview();
            UpdateSectionLabel(); // Update the section label
        }

        private void UpdatePreview()
        {
            if (sourceImage == null || parsedRows.Count == 0) return;
            int tileSize = 16;

            using (Bitmap resultImage = new Bitmap(TILES_PER_ROW * tileSize, TILES_PER_SECTION * tileSize))
            using (Graphics g = Graphics.FromImage(resultImage))
            {
                g.Clear(Color.White); // Clear background

                int startRow = currentSection * TILES_PER_SECTION;
                int endRow = Math.Min(startRow + TILES_PER_SECTION, parsedRows.Count);

                for (int rowIndex = startRow; rowIndex < endRow; rowIndex++)
                {
                    string[] hexValues = parsedRows[rowIndex];
                    for (int i = 0; i < Math.Min(hexValues.Length, TILES_PER_ROW); i++)
                    {
                        string hex = hexValues[i].Trim().ToUpper().PadLeft(2, '0');
                        if (tilePositions.TryGetValue(hex, out Rectangle sourceRect))
                        {
                            int destX = i * tileSize;
                            int destY = (rowIndex - startRow) * tileSize;
                            Rectangle destRect = new Rectangle(destX, destY, tileSize, tileSize);
                            g.DrawImage(sourceImage, destRect, sourceRect, GraphicsUnit.Pixel);
                        }
                    }
                }

                pictureBox2.Image?.Dispose();
                pictureBox2.Image = new Bitmap(resultImage);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void ClearPreview()
        {
            pictureBox2.Image?.Dispose();
            pictureBox2.Image = null;
        }

        private List<string[]> ParseInput(string input)
        {
            List<string[]> result = new List<string[]>();

            // Match content between Row { and }, regardless of casing
            const string pattern = @"row\s*\{([^}]*)\}";
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    string rowContent = match.Groups[1].Value.Trim();
                    // Extract hex values, removing "0x" prefix (any casing) and normalizing to two digits
                    string[] hexValues = Regex.Matches(rowContent, @"(?:0x|0X)?([0-9a-fA-F]{1,2})")
                        .Cast<Match>()
                        .Select(m => m.Groups[1].Value.ToUpper().PadLeft(2, '0'))
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
                    GenerateFromText(showWarnings: true);
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
            lblSectionNumber.Text = totalSections > 0
                ? $"Section: {currentSection + 1}/{totalSections}"
                : "Section: 0/0";
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

        private void RichTextBox1_TextChanged(object? sender, EventArgs e)
        {
            GenerateFromText(); // auto-refresh when text changes
        }

        private void ShowTilePreview(Bitmap image)
        {
            tilePreviewForm?.Close();
            tilePreviewForm?.Dispose();

            tilePreviewForm = new TilePreviewForm();
            if (this.Icon != null)
            {
                tilePreviewForm.Icon = this.Icon;
            }
            tilePreviewForm.SetImage(image);
            tilePreviewForm.Show(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            tilePreviewForm?.Close();
            base.OnFormClosing(e);
        }

        private void TrySetAppIcon()
        {
            try
            {
                string iconPath = Path.Combine(AppContext.BaseDirectory, "rikako.ico");
                if (File.Exists(iconPath))
                {
                    Icon = new Icon(iconPath);
                }
                else
                {
                    Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
                }
            }
            catch
            {
                // Ignore icon failures to avoid crashing the UI
            }
        }
    }
}
