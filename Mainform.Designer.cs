using System.Reflection;

namespace MapEditHelper
{
    partial class Mainform
    {
        private System.ComponentModel.IContainer components = null;
        // Add this line to declare mainMenuStrip
        private MenuStrip mainMenuStrip;

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
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            menuStrip1 = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Help");
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(832, 112);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(110, 27);
            button1.TabIndex = 0;
            button1.Text = "LoadTitleMap";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(496, 16);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(320, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(832, 64);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(90, 27);
            button2.TabIndex = 3;
            button2.Text = "Generate";
            button2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.AcceptsTab = true;
            richTextBox1.Font = new Font("Consolas", 10F);
            richTextBox1.Location = new Point(16, 16);
            richTextBox1.Margin = new Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(465, 161);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // button3
            // 
            button3.Location = new Point(832, 16);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(90, 27);
            button3.TabIndex = 5;
            button3.Text = "Load Map";
            button3.UseVisualStyleBackColor = true;
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
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 363);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1006, 237);
            panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1 = new MenuStrip();
            mainMenuStrip = menuStrip1;
            fileMenu = new ToolStripMenuItem("File");
            helpMenu = new ToolStripMenuItem("Help");

            // Add menu items to File menu
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("Load Tilemap", null, new EventHandler(LoadTilemap_Click)),
                new ToolStripMenuItem("Load Map", null, new EventHandler(LoadMap_Click)),
                new ToolStripSeparator(),
                new ToolStripMenuItem("Exit", null, new EventHandler(Exit_Click))
            });

            // Add menu items to Help menu
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem("About", null, new EventHandler(About_Click))
            });

            // Add menus to menu strip
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu, helpMenu });

            // Add menu strip to form
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            // 
            // btnPrevSection
            // 
            btnPrevSection = new Button();
            btnPrevSection.Location = new Point(16, 200);
            btnPrevSection.Size = new Size(90, 27);
            btnPrevSection.Name = "btnPrevSection";
            btnPrevSection.Text = "< Previous";
            btnPrevSection.UseVisualStyleBackColor = true;
            btnPrevSection.Click += PreviousSection_Click;
            panel1.Controls.Add(btnPrevSection);
            // 
            // lblSectionNumber
            // 
            lblSectionNumber = new Label();
            lblSectionNumber.Location = new Point(116, 204);
            lblSectionNumber.Size = new Size(100, 20);
            lblSectionNumber.Name = "lblSectionNumber";
            lblSectionNumber.Text = "Section: 1/1";
            lblSectionNumber.TextAlign = ContentAlignment.MiddleCenter;
            panel1.Controls.Add(lblSectionNumber);
            // 
            // btnNextSection
            // 
            btnNextSection = new Button();
            btnNextSection.Location = new Point(226, 200);
            btnNextSection.Size = new Size(90, 27);
            btnNextSection.Name = "btnNextSection";
            btnNextSection.Text = "Next >";
            btnNextSection.UseVisualStyleBackColor = true;
            btnNextSection.Click += NextSection_Click;
            panel1.Controls.Add(btnNextSection);
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 602);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2);
            MinimumSize = new Size(804, 489);
            Name = "Mainform";
            Text = "Rikako";
            this.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
        private RichTextBox richTextBox1;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Button btnPrevSection;
        private Button btnNextSection;
        private Label lblSectionNumber;
    }
}