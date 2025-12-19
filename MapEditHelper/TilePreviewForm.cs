using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace MapEditHelper
{
    internal class TilePreviewForm : Form
    {
        private readonly PictureBox pictureBox;

        public TilePreviewForm()
        {
            Text = "Tilemap Preview";
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            Width = 480;
            Height = 480;
            TrySetIcon();

            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black
            };

            Controls.Add(pictureBox);
        }

        public void SetImage(Bitmap source)
        {
            pictureBox.Image?.Dispose();
            pictureBox.Image = new Bitmap(source);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pictureBox.Image?.Dispose();
            base.OnFormClosed(e);
        }

        private void TrySetIcon()
        {
            try
            {
                Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            }
            catch
            {
                // best-effort; ignore icon failures
            }
        }
    }
}
