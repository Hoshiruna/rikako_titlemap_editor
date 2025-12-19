using System.Reflection;

namespace MapEditHelper
{
    partial class Mainform
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            richTextBox1 = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            btnPrevSection = new Button();
            lblSectionNumber = new Label();
            btnNextSection = new Button();
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            helpMenu = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.AcceptsTab = true;
            richTextBox1.Font = new Font("Consolas", 10F);
            richTextBox1.Location = new Point(16, 16);
            richTextBox1.Margin = new Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(967, 161);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pictureBox2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1010, 602);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(2, 2);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1006, 357);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(btnPrevSection);
            panel1.Controls.Add(lblSectionNumber);
            panel1.Controls.Add(btnNextSection);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 363);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1006, 237);
            panel1.TabIndex = 0;
            // 
            // btnPrevSection
            // 
            btnPrevSection.Location = new Point(16, 197);
            btnPrevSection.Name = "btnPrevSection";
            btnPrevSection.Size = new Size(90, 27);
            btnPrevSection.TabIndex = 5;
            btnPrevSection.Text = "< Previous";
            btnPrevSection.UseVisualStyleBackColor = true;
            btnPrevSection.Click += PreviousSection_Click;
            // 
            // lblSectionNumber
            // 
            lblSectionNumber.Location = new Point(442, 200);
            lblSectionNumber.Name = "lblSectionNumber";
            lblSectionNumber.Size = new Size(100, 20);
            lblSectionNumber.TabIndex = 6;
            lblSectionNumber.Text = "Section: 0/0";
            lblSectionNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNextSection
            // 
            btnNextSection.Location = new Point(881, 197);
            btnNextSection.Name = "btnNextSection";
            btnNextSection.Size = new Size(90, 27);
            btnNextSection.TabIndex = 7;
            btnNextSection.Text = "Next >";
            btnNextSection.UseVisualStyleBackColor = true;
            btnNextSection.Click += NextSection_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu, helpMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1010, 28);
            menuStrip1.TabIndex = 0;
            // 
            // fileMenu
            // 
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(46, 24);
            fileMenu.Text = "&File";
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("&Load Tilemap", null, new EventHandler(LoadTilemap_Click)),
                new ToolStripMenuItem("Load &Map", null, new EventHandler(LoadMap_Click)),
                new ToolStripSeparator(),
                new ToolStripMenuItem("E&xit", null, new EventHandler(Exit_Click))
            });
            // 
            // helpMenu
            // 
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(55, 24);
            helpMenu.Text = "&Help";
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("&About", null, new EventHandler(About_Click))
            });
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 602);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            MinimumSize = new Size(804, 489);
            Name = "Mainform";
            Text = "Rikako";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Button btnPrevSection;
        private Button btnNextSection;
        private Label lblSectionNumber;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem helpMenu;
    }
}
