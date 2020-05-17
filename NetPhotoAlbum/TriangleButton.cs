using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NetPhotoAlbum
{
    /// <summary>
    /// Sets the rotation of triangle
    /// </summary>
    public enum Rotation
    {
        /// <summary>
        /// Sets triangles top angle to show left
        /// </summary>
        Left = 1,
        /// <summary>
        /// Sets triangles top angle to show top
        /// </summary>
        Top = 2,
        /// <summary>
        /// Sets triangles top angle to show right
        /// </summary>
        Right = 3,
        /// <summary>
        /// Sets triangles top angle to show bottom
        /// </summary>
        Bottom = 4
    }
    [Serializable]
    [ToolboxBitmap(typeof(TriangleButton), "TriangleButton.bmp")]
    [ToolboxItem(true)]
    public class TriangleButton : Button
    {
        private Rotation _Rotate;

        public TriangleButton()
        {
            this.Rotate = Rotation.Top;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Orange;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            PointF[] Pts = SetPoints();

            g.FillPolygon(new SolidBrush(this.BackColor), Pts, FillMode.Alternate);
            GraphicsPath GPath = new GraphicsPath();
            GPath.AddPolygon(Pts);
            this.Region = new Region(GPath);
            base.OnPaint(pevent);
        }

        private PointF[] SetPoints()
        {
            float _H = this.Height;
            float _W = this.Width;
            PointF[] Pts = new PointF[3];
            switch (_Rotate)
            {
                case Rotation.Left:
                    Pts = new PointF[] { new PointF(_W, 0), new PointF(0, _H / 2), new PointF(_W, _H) };
                    break;
                case Rotation.Top:
                    Pts = new PointF[] { new PointF(_W / 2, 0), new PointF(0, _H), new PointF(_W, _H) };
                    break;
                case Rotation.Right:
                    Pts = new PointF[] { new PointF(0, 0), new PointF(0, _H), new PointF(_W, _H / 2) };
                    break;
                case Rotation.Bottom:
                    Pts = new PointF[] { new PointF(0, 0), new PointF(_W, 0), new PointF(_W / 2, _H) };
                    break;
            }
            return Pts;
        }

        [Category("Design")]
        [DefaultValue(typeof(Rotation), "Top")]
        [Description("Triangles rotation")]
        public Rotation Rotate
        {
            get { return _Rotate; }
            set
            {
                _Rotate = value;
                Refresh();
            }
        }
    }
}
