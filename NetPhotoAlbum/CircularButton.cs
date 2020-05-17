using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NetPhotoAlbum
{
    [Serializable]
    [ToolboxBitmap(typeof(CircularButton), "CircularButton.bmp")]
    [ToolboxItem(true)]
    public class CircularButton : Button
    {
        public CircularButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Orange;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath g = new GraphicsPath();
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(g);
            base.OnPaint(pevent);
        }
    }
}
