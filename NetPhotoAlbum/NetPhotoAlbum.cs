using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using NetPhotoAlbum.TrackBarCollection;

namespace NetPhotoAlbum
{
    /// <summary>
    /// Variations of album view
    /// </summary>
    public enum AlbumStyle
    {
        /// <summary>
        /// Sets the view of album as catalog
        /// </summary>
        Catalog = 1,
        /// <summary>
        /// Sets the view of album as list
        /// </summary>
        List = 2
    }
    /// <summary>
    /// Variations of controls locations
    /// </summary>
    public enum TrackBarLocation
    {
        /// <summary>
        /// Hides the controls
        /// </summary>
        None = 1,
        /// <summary>
        /// Left
        /// </summary>
        ///     
        Left = 2,
        /// <summary>
        /// Top
        /// </summary>
        Top = 3,
        /// <summary>
        /// Right
        /// </summary>
        Right = 4,
        /// <summary>
        /// Bottom
        /// </summary>
        Bottom = 5
    }

    /// <summary>
    /// Variations of controls locations
    /// </summary>
    public enum CornerLocation
    {
        /// <summary>
        /// Hides the controls
        /// </summary>
        None = 1,
        /// <summary>
        /// Top left corner
        /// </summary>
        ///     
        TopLeft = 2,
        /// <summary>
        /// Top right corner
        /// </summary>
        TopRight = 3,
        /// <summary>
        /// Bottom left corner
        /// </summary>
        BottomLeft = 4,
        /// <summary>
        /// Bottom right corner
        /// </summary>
        BottomRight = 5
    }

    /// <summary>
    /// A Winforms Photo Album control
    /// </summary>   
    [Serializable]
    [ToolboxBitmap(typeof(NetPhotoAlbum),"NetPhotoAlbum.bmp")]
    [ToolboxItem(true)]
    public partial class NetPhotoAlbum : UserControl
    {
        public NetPhotoAlbum()
        {
            InitializeComponent();
            this.AlbumStyle = AlbumStyle.Catalog;
            this.TrackBarLocation = TrackBarLocation.Bottom;
            this.CornerLocation = CornerLocation.BottomRight;
            this.ControlsButtonMargin = new Padding(0, 0, 0, 0);
            this._TrackbarMargin = 10;
            this.ButtonsColor = Color.Orange;
            this.ButtonsDownBackcolor = Color.Yellow;
            this.ButtonsHoverBackcolor = Color.Maroon;
            this.TrackerColor = Color.Orange;
            this.TrackLineColor = Color.Gray;
            this.TickColor = Color.Gray;
            this.TrackForeColor = Color.Gray;
            this.TrackLineHeight = 3;
            this.IndentHeight = 2;
            this.IndentWidth = 6;
            this.TrackerSize = new Size(16, 16);
            this.Maximum = 10;
            this.Minimum = 0;
            this.LargeChange = 2;
            this.SmallChange = 1;
            this.TickStyle = TickStyle.None;
            this.TextTickStyle = TickStyle.None;
            this._ControlButtonsSize = new Size(75, 75);
            this.Btn_Ok.Image = Images.Resources.Catalog_x16;
            this.Albumborder = BorderStyle.None;
            this.AlbumMargin = new Padding(0, 0, 0, 0);
            this.ListObjectHeight = 75;
            this.ImageMarginColor = Color.Silver;
            this.InfoBackColor = Color.LightGray;
            this.PictureBorderStyle = BorderStyle.None;
            this.InfoFont = (Font)new FontConverter().ConvertFromString(_DefaultInfoFont);
            this.PictureBoxMargin = new Padding(15);
            this.ImageMarginHoverColor = Color.Gray;
            this.InfoBackHoverColor = Color.Gray;
            this.ArrowTick = 10;
            this.CatalogObjBorder = BorderStyle.None;
            this.CatalogObjImgMode = PictureBoxSizeMode.Zoom;
            this.CatalogObjSize = new Size(160, 120);
            this.CatalogObjImgBackColor = Color.White;
            this.CatalogObjImgHoverColor = Color.Silver;
        }

        private void InitializeComponent()
        {
            this.trackBar1 = new MACTrackBar();
            this._ControlPanel = new ControlPanel();
            this._AlbumContainer = new Panel();
            //this._SoloPBox = new PictureBox();
            this._SelectedDataSource = new ListObjectDataSource();
            this.Btn_Left = (TriangleButton)_ControlPanel.Controls.Find("Btn_Left", true)[0];
            this.Btn_Up = (TriangleButton)_ControlPanel.Controls.Find("Btn_Up", true)[0];
            this.Btn_Right = (TriangleButton)_ControlPanel.Controls.Find("Btn_Right", true)[0];
            this.Btn_Bottom = (TriangleButton)_ControlPanel.Controls.Find("Btn_Bottom", true)[0];
            this.Btn_Ok = (CircularButton)_ControlPanel.Controls.Find("Btn_Ok", true)[0];
            this.SuspendLayout();


            // 
            // trackBar1
            // 
            this.trackBar1.Size = SetTrackBarSize();
            this.trackBar1.Location = GetTrackBarLocation(trackBar1);
            this.trackBar1.Orientation = SetOrientation();
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += TrackBall_Scroll;
            //
            // ControlPanel
            //           
            this._ControlPanel.Location = GetControlButtonsLocation(_ControlPanel);
            this._ControlPanel.Name = "controller";
            this._ControlPanel.TabIndex = 1;
            this.Btn_Left.Click += BtnLeft_Click;
            this.Btn_Up.Click += BtnUp_Click;
            this.Btn_Right.Click += BtnRight_Click;
            this.Btn_Bottom.Click += BtnDown_Click;
            this.Btn_Ok.Click += BtnOk_Click;
            //
            // _AlbumContainer
            //
            this._AlbumContainer.BorderStyle = _Albumborder;
            this._AlbumContainer.Size = GetAlbumContainerSize();
            this._AlbumContainer.Location = GetAlbumContainerLocation();
            this._AlbumContainer.Name = "AlbumContainer";
            this._AlbumContainer.TabIndex = 2;
            //
            // _ListFlow
            //
            this._ListFlow = new FlowLayoutPanel();
            this._ListFlow.Dock = DockStyle.Fill;
            this._ListFlow.AutoScroll = true;

            //
            //_SoloPbox
            //
            CreateSoloPboxWithProperties();
            // 
            // NetPhotoAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this._ControlPanel);
            this.Controls.Add(this._AlbumContainer);
            this.Name = "NetPhotoAlbum";
            this.Size = new System.Drawing.Size(578, 378);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void CreateSoloPboxWithProperties()
        {
            this._SoloPBox = new PictureBox();
            this._SoloPBox.Cursor = Cursors.SizeAll;
            this._SoloPBox.Dock = DockStyle.Fill;
            this._SoloPBox.SizeMode = PictureBoxSizeMode.Zoom;
            this._SoloPBox.MouseClick += this.SoloPBox_Clicked;
            this._SoloPBox.MouseWheel += this.SoloPBox_MouseWheel;
            this._SoloPBox.MouseDown += this.SoloPBox_MouseDown;
            this._SoloPBox.MouseMove += this.SoloPBox_MouseMove;
            this._SoloPBox.MouseUp += this.SoloPBox_MouseUp;
            this._SoloPBox.Paint += this.SoloPBox_Paint;
        }

        #region Overrides
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            trackBar1.Size = SetTrackBarSize();
            trackBar1.Location = GetTrackBarLocation(trackBar1);
            _ControlPanel.Location = GetControlButtonsLocation(_ControlPanel);
            _AlbumContainer.Size = GetAlbumContainerSize();
            _AlbumContainer.Location = GetAlbumContainerLocation();
        }
        #endregion
        #region Events
        private void ListObjectClicked(object sender, EventArgs e)
        {
            CreateSoloPboxWithProperties();
            _SelectedObj = _ListFlow.Controls.Cast<ListObject>().FirstOrDefault(Lo => Lo.IsSelected);
            if (_SelectedObj != null)
            {
                _AlbumContainer.Controls.Clear();
                _AlbumContainer.Controls.Add(_SoloPBox);
                _SoloPBox.Image = new Bitmap(_SelectedObj.DataSource.Picture);
                _SourceBitmap = new Bitmap(_SoloPBox.Image);
                _OriginalSizeOfSourceImage = _SoloPBox.Image.Size;
                _SelectedDataSource.Picture = new Bitmap(_SelectedObj.DataSource.Picture);
                ZoomAction();
            }
        }
        private void CatalogObjectClicked(object sender, EventArgs e)
        {
            CreateSoloPboxWithProperties();
            _SelectedCatalogObj = _ListFlow.Controls.Cast<CatalogObject>().FirstOrDefault(Lo => Lo.IsSelected);
            if (_SelectedCatalogObj != null)
            {
                _AlbumContainer.Controls.Clear();
                _AlbumContainer.Controls.Add(_SoloPBox);
                _SoloPBox.Image = _SelectedCatalogObj.DataSource.Picture;
                _SourceBitmap = new Bitmap(_SoloPBox.Image);
                _OriginalSizeOfSourceImage = _SoloPBox.Image.Size;
                _SelectedDataSource.Picture = new Bitmap(_SelectedCatalogObj.DataSource.Picture);
                ZoomAction();
            }
        }

        private void SoloPBox_Clicked(object obj, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DisposeAndTurnToList();
            }
        }
        private void SoloPBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _OnPanning = true;
                _StartPoint = new Point(e.Location.X - _MovingPoint.X,
                                          e.Location.Y - _MovingPoint.Y);
            }
        }
        private void SoloPBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (trackBar1.Value > 0)
                {
                    if (_OnPanning)
                    {
                        _MovingPoint = new Point(e.Location.X - _StartPoint.X,
                                                e.Location.Y - _StartPoint.Y);
                        _SoloPBox.Invalidate();
                        _TickStart = _MovingPoint;
                    }

                }
            }
        }
        private void TrackBall_Scroll(object sender, EventArgs e)
        {
            if (_SoloPBox.Image != null) ZoomAction();
        }
        private void SoloPBox_MouseUp(object sender, MouseEventArgs e)
        {
            _OnPanning = false;
        }
        private void SoloPBox_Paint(object sender, PaintEventArgs e)
        {
            if (!_FixedImage)
            {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(_SourceBitmap, _MovingPoint);
            }
        }
        private void SoloPBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (trackBar1.Value > trackBar1.Minimum)
                {
                    trackBar1.Value--;
                    ZoomAction();
                }
            }
            else
            {
                if (trackBar1.Value < trackBar1.Maximum)
                {
                    trackBar1.Value++;
                    ZoomAction();
                }

            }
        }
        private void BtnLeft_Click(object sender, EventArgs e)
        {
            if (_SoloPBox.Image != null && trackBar1.Value > 0)
            {
                _MovingPoint = new Point(_TickStart.X - _ArrowTick,
                                        _TickStart.Y);
                _SoloPBox.Invalidate();
                _TickStart = _MovingPoint;
            }
        }
        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (_SoloPBox.Image != null && trackBar1.Value > 0)
            {
                _MovingPoint = new Point(_TickStart.X,
                                        _TickStart.Y - _ArrowTick);
                _SoloPBox.Invalidate();
                _TickStart = _MovingPoint;
            }
        }
        private void BtnRight_Click(object sender, EventArgs e)
        {
            if (_SoloPBox.Image != null && trackBar1.Value > 0)
            {
                _MovingPoint = new Point(_TickStart.X + _ArrowTick,
                                        _TickStart.Y);
                _SoloPBox.Invalidate();
                _TickStart = _MovingPoint;
            }
        }
        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (_SoloPBox.Image != null && trackBar1.Value > 0)
            {
                _MovingPoint = new Point(_TickStart.X,
                                        _TickStart.Y + _ArrowTick);
                _SoloPBox.Invalidate();
                _TickStart = _MovingPoint;
            }
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (_AlbumContainer.Controls.Contains(_SoloPBox))
            {
                DisposeAndTurnToList();
            }
        }

        #endregion


        private void ZoomAction()
        {
            if (trackBar1.Value > 0)
            {
                _FixedImage = false;
                _SoloPBox.Image.Dispose();
                _SoloPBox.SizeMode = PictureBoxSizeMode.Normal;
                _SoloPBox.Image = Zoom(_SelectedDataSource.Picture, new Size(trackBar1.Value, trackBar1.Value));

            }
            else
            {
                _FixedImage = true;
                _SoloPBox.Image = _SourceBitmap;
                _SoloPBox.SizeMode = PictureBoxSizeMode.Zoom;
                _MovingPoint = new Point(0, 0);
                _OriginalSizeOfSourceImage = _SoloPBox.Image.Size;
            }
        }
        private void FillData()
        {
            if (_DataSource != null && _DataSource.Count > 0)
            {
                _ListFlow.Controls.Clear();
                _ListFlow.Dispose();
                this._ListFlow = new FlowLayoutPanel();
                this._ListFlow.Dock = DockStyle.Fill;
                this._ListFlow.AutoScroll = true;
                this._AlbumContainer.Controls.Add(_ListFlow);
                foreach (ListObjectDataSource Src in _DataSource)
                {
                    switch (_AlbumStyle)
                    {
                        case AlbumStyle.List:
                            ListObject Obj = new ListObject { DataSource = Src, Height = _ListObjectHeight, Width = _ListFlow.Width - 30 };
                            SetListObjectProperties(Obj);
                            _ListFlow.Controls.Add(Obj);
                            break;
                        case AlbumStyle.Catalog:
                            CatalogObject CatalogObj = new CatalogObject();
                            SetCatalogObjectProperties(CatalogObj);
                            CatalogObj.DataSource = Src;
                            _ListFlow.Controls.Add(CatalogObj);
                            break;
                    }
                }
            }
        }
        /// <summary>
        ///  This method disposes the picture box that shows solo picture in bigger size, and turns it to back to album style.
        /// </summary>
        private void DisposeAndTurnToList()
        {
            this._SoloPBox.Dispose();
            this._SourceBitmap.Dispose();
            this.trackBar1.Value = 0;
            this._AlbumContainer.Controls.Clear();
            this._AlbumContainer.Controls.Add(_ListFlow);
        }

        ///<summary>
        /// Tick start point.
        ///</summary>
        private Point _TickStart = Point.Empty;
        /// <summary>
        /// Zoom action start point.
        /// </summary>
        private Point _StartPoint = Point.Empty;
        /// <summary>
        /// Zoom action moving to point for drag the image.
        /// </summary>
        private Point _MovingPoint = Point.Empty;
        /// <summary>
        /// Checks if image on panning situation.
        /// </summary>
        private bool _OnPanning = false;
        /// <summary>
        /// Checks if image fixed.
        /// </summary>
        private bool _FixedImage = true;
        /// <summary>
        /// Original size of image whic came from data source.
        /// </summary>
        private Size _OriginalSizeOfSourceImage;
        /// <summary>
        /// Source image as bimap.
        /// </summary>
        private Bitmap _SourceBitmap;
        /// <summary>
        /// Checks if image fixed.
        /// </summary>
        private Image Zoom(Image img, Size size)
        {

            float raitoX = (float)_SoloPBox.Width / (float)_OriginalSizeOfSourceImage.Width;
            float raitoY = (float)_SoloPBox.Height / (float)_OriginalSizeOfSourceImage.Height;
            double ratio = raitoX < raitoY ? raitoX : raitoY;

            int newHeight = Convert.ToInt32(_OriginalSizeOfSourceImage.Height * ratio);
            int newWidth = Convert.ToInt32(_OriginalSizeOfSourceImage.Width * ratio);

            int posX = Convert.ToInt32((_SoloPBox.Width - (_OriginalSizeOfSourceImage.Width * ratio)) / 2);
            int posY = Convert.ToInt32((_SoloPBox.Height - (_OriginalSizeOfSourceImage.Height * ratio)) / 2);



            if (trackBar1.Value == 1)
                _MovingPoint = new Point(posX, posY);
            Bitmap bmp = new Bitmap(img, Convert.ToInt32(newWidth + (newWidth * size.Width / 10)), Convert.ToInt32(newHeight + (newHeight * size.Height / 10)));


            if (_SourceBitmap != null) _SourceBitmap.Dispose();
            _SourceBitmap = bmp;
            return bmp;
        }

        private Point GetControlButtonsLocation(ControlPanel CPnl)
        {
            Point location = Point.Empty;
            switch (_CornerLocation)
            {
                case CornerLocation.TopLeft:
                    location = new Point(ControlsButtonMargin.Left, ControlsButtonMargin.Top);
                    break;
                case CornerLocation.TopRight:
                    location = new Point(this.Width - (CPnl.Width + ControlsButtonMargin.Right), ControlsButtonMargin.Top);
                    break;
                case CornerLocation.BottomLeft:
                    location = new Point(ControlsButtonMargin.Left, this.Height - (CPnl.Height + ControlsButtonMargin.Bottom));
                    break;
                case CornerLocation.BottomRight:
                    location = new Point(this.Width - (CPnl.Width + ControlsButtonMargin.Right), this.Height - (CPnl.Height + ControlsButtonMargin.Bottom));
                    break;
            }
            return location;
        }

        /// <summary>
        /// Calculates the location of track bar while case of TrackBarLocation and .NetPhotoAlbum size and TrackbarMargin.
        /// </summary>       
        private Point GetTrackBarLocation(MACTrackBar Tbar)
        {
            Point location = Point.Empty;
            switch (_TrackBarLocation)
            {
                case TrackBarLocation.Bottom:
                    location = new Point(Convert.ToInt32((this.Width - Tbar.Width) / 2), (this.Height - Tbar.Height - _TrackbarMargin));
                    break;
                case TrackBarLocation.Top:
                    location = new Point(Convert.ToInt32((this.Width - Tbar.Width) / 2), _TrackbarMargin);
                    break;
                case TrackBarLocation.Left:
                    location = new Point(_TrackbarMargin, Convert.ToInt32((this.Height - Tbar.Height) / 2));
                    break;
                case TrackBarLocation.Right:
                    location = new Point((this.Width - Tbar.Width - _TrackbarMargin), Convert.ToInt32((this.Height - Tbar.Height) / 2));
                    break;
                case TrackBarLocation.None:
                    location = new Point(0, 0);
                    break;
            }
            return location;
        }

        /// <summary>
        /// Sets the size of track bar while case of TrackBarLocation and size of .NetPhotoAlbum.
        /// </summary>       
        private Size SetTrackBarSize()
        {
            Size TSize = Size.Empty;
            switch (_TrackBarLocation)
            {
                case TrackBarLocation.Bottom:
                    TSize = new Size(Convert.ToInt32(this.Width / 3), 45);
                    break;
                case TrackBarLocation.Top:
                    TSize = new Size(Convert.ToInt32(this.Width / 3), 45);
                    break;
                case TrackBarLocation.Left:
                    TSize = new Size(45, Convert.ToInt32(this.Height / 3));
                    break;
                case TrackBarLocation.Right:
                    TSize = new Size(45, Convert.ToInt32(this.Height / 3));
                    break;
                case TrackBarLocation.None:
                    TSize = new Size(0, 0);
                    break;
            }
            return TSize;
        }

        /// <summary>
        /// Sets only track bars orientation while case of TrackBarLocation.
        /// </summary>        
        private Orientation SetOrientation()
        {
            Orientation Tor = Orientation.Horizontal;
            if (_TrackBarLocation == TrackBarLocation.Top || _TrackBarLocation == TrackBarLocation.Bottom)
            {
                Tor = Orientation.Horizontal;
            }
            else
            {
                Tor = Orientation.Vertical;
            }
            return Tor;
        }

        /// <summary>
        /// Gets the image of circle button with case of AlbumStyle. 
        /// </summary>        
        private Image GetOkBtnImg()
        {
            Image Result = _AlbumStyle == AlbumStyle.Catalog ? Images.Resources.Catalog_x16 : Images.Resources.List_x16;
            return Result;
        }

        /// <summary>
        /// Gets the size of photo album container panel.
        /// </summary>       
        private Size GetAlbumContainerSize()
        {
            int _CpW = this._ControlPanel.Width;
            int _CpH = this._ControlPanel.Height;
            int _TbW = this.trackBar1.Width;
            int _TbH = this.trackBar1.Height;
            Size size;
            if (_TrackBarLocation == TrackBarLocation.Left && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.BottomLeft))
            {
                size = new Size(this.Width - (_CpW + _ControlsButtonMargin.Left + _ControlsButtonMargin.Right + _AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.Right && (_CornerLocation == CornerLocation.TopRight || _CornerLocation == CornerLocation.BottomRight))
            {
                size = new Size(this.Width - (_CpW + _ControlsButtonMargin.Left + _ControlsButtonMargin.Right + _AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.Top && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.TopRight))
            {
                size = new Size(this.Width - (_AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_CpH + _ControlsButtonMargin.Top + _ControlsButtonMargin.Bottom + _AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.Bottom && (_CornerLocation == CornerLocation.BottomLeft || _CornerLocation == CornerLocation.BottomRight))
            {
                size = new Size(this.Width - (_AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_CpH + _ControlsButtonMargin.Top + _ControlsButtonMargin.Bottom + _AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.Left && (_CornerLocation == CornerLocation.TopRight || _CornerLocation == CornerLocation.BottomRight))
            {
                size = new Size(this.Width - (_CpW + _TrackbarMargin + _ControlsButtonMargin.Right + _ControlsButtonMargin.Left + _AlbumMargin.Left + _AlbumMargin.Right + _TbW), this.Height - (_AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.Right && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.BottomLeft))
            {
                size = new Size(this.Width - (_CpW + _TrackbarMargin + _ControlsButtonMargin.Right + _ControlsButtonMargin.Left + _AlbumMargin.Left + _AlbumMargin.Right + _TbW), this.Height - (_AlbumMargin.Top + _AlbumMargin.Bottom));
                //size = new Size(this.Width - (_CpW + _TrackbarMargin + _ControlsButtonMargin.Left + _AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.Top && (_CornerLocation == CornerLocation.BottomLeft || _CornerLocation == CornerLocation.BottomRight))
            {
                size = new Size(this.Width - (_AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_CpH + _TrackbarMargin + _ControlsButtonMargin.Top + _ControlsButtonMargin.Bottom + _AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.Bottom && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.TopRight))
            {
                size = new Size(this.Width - (_AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_CpH + _TbH + _TrackbarMargin + _ControlsButtonMargin.Top + _ControlsButtonMargin.Bottom + _AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if (_TrackBarLocation == TrackBarLocation.None && _CornerLocation != CornerLocation.None)
            {
                size = new Size(this.Width - (_CpW + _ControlsButtonMargin.Left + _ControlsButtonMargin.Right + _AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if ((_TrackBarLocation == TrackBarLocation.Top || _TrackBarLocation == TrackBarLocation.Bottom) && _CornerLocation == CornerLocation.None)
            {
                size = new Size(this.Width - (_AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_TbH + _TrackbarMargin + _AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else if ((_TrackBarLocation == TrackBarLocation.Right || _TrackBarLocation == TrackBarLocation.Left) && _CornerLocation == CornerLocation.None)
            {
                size = new Size(this.Width - (_TbW + _TrackbarMargin + _AlbumMargin.Left + _AlbumMargin.Right), this.Height - (_AlbumMargin.Top + _AlbumMargin.Bottom));
            }
            else { size = new Size(0, 0); }
            return size;
        }

        /// <summary>
        /// Gets the location of photo album container panel.
        /// </summary>       
        private Point GetAlbumContainerLocation()
        {
            int _CpW = this._ControlPanel.Width;
            int _CpH = this._ControlPanel.Height;
            int _TbW = this.trackBar1.Width;
            int _TbH = this.trackBar1.Height;

            Point location = new Point();
            if (_TrackBarLocation == TrackBarLocation.Left && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.BottomLeft))
            {
                location = new Point((_CpW + _ControlsButtonMargin.Left + _ControlsButtonMargin.Right + _AlbumMargin.Left), _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.Top && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.TopRight))
            {
                location = new Point(_AlbumMargin.Left, (_CpH + _ControlsButtonMargin.Top + _ControlsButtonMargin.Bottom + _AlbumMargin.Top));
            }
            else if ((_TrackBarLocation == TrackBarLocation.Right && (_CornerLocation == CornerLocation.TopRight || _CornerLocation == CornerLocation.BottomRight)) || (_TrackBarLocation == TrackBarLocation.Bottom && (_CornerLocation == CornerLocation.BottomLeft || _CornerLocation == CornerLocation.BottomRight)))
            {
                location = new Point(_AlbumMargin.Left, _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.Left && (_CornerLocation == CornerLocation.TopRight || _CornerLocation == CornerLocation.BottomRight))
            {
                location = new Point(_TbW + _TrackbarMargin + _AlbumMargin.Left, _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.Top && (_CornerLocation == CornerLocation.BottomLeft || _CornerLocation == CornerLocation.BottomRight))
            {
                location = new Point(_AlbumMargin.Left, _TbH + _TrackbarMargin + _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.Right && (_CornerLocation == CornerLocation.BottomLeft || _CornerLocation == CornerLocation.TopLeft))
            {
                location = new Point(_CpW + _ControlsButtonMargin.Left + _ControlsButtonMargin.Right + _AlbumMargin.Left, _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.Bottom && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.TopRight))
            {
                location = new Point(_AlbumMargin.Left, _CpH + _ControlsButtonMargin.Top + _ControlsButtonMargin.Bottom + _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.None && (_CornerLocation == CornerLocation.TopLeft || _CornerLocation == CornerLocation.BottomLeft))
            {
                location = new Point(_CpW + _ControlsButtonMargin.Left + _ControlsButtonMargin.Right + _AlbumMargin.Left, _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.None && (_CornerLocation == CornerLocation.TopRight || _CornerLocation == CornerLocation.BottomRight))
            {
                location = new Point(_AlbumMargin.Left, _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.Left && _CornerLocation == CornerLocation.None)
            {
                location = new Point(_TbW + _TrackbarMargin + _AlbumMargin.Left, _AlbumMargin.Top);
            }
            else if (_TrackBarLocation == TrackBarLocation.Top && _CornerLocation == CornerLocation.None)
            {
                location = new Point(_AlbumMargin.Left, _TbH + _TrackbarMargin + _AlbumMargin.Top);
            }
            else if ((_TrackBarLocation == TrackBarLocation.Right || _TrackBarLocation == TrackBarLocation.Bottom) && _CornerLocation == CornerLocation.None)
            {
                location = new Point(_AlbumMargin.Left, _AlbumMargin.Top);
            }
            else location = new Point(0, 0);
            return location;
        }

        ///<summary>
        ///Set properties of selected ListObject
        ///</summary>
        private void SetListObjectProperties(ListObject Obj)
        {
            Obj.ImageMarginColor = _ImageMarginColor;
            Obj.ImageMarginHoverColor = _ImageMarginHoverColor;
            Obj.InfoBackColor = _InfoBackColor;
            Obj.InfoBackHoverColor = _InfoBackHoverColor;
            Obj.InfoFont = _InfoFont;
            Obj.PictureBoxMargin = _PictureBoxMargin;
            Obj.PictureBorderStyle = _PboxBorderStyle;
            SetClickEventForChilds(Obj);
        }

        /// <summary>
        /// Sets properties of selected CatalogObject.
        /// </summary>
        /// <param name="Obj"></param>
        private void SetCatalogObjectProperties(CatalogObject Obj)
        {
            Obj.PBoxSizeMode = _CatalogObjectSizeMode;
            Obj.Size = _CatalogObjectSize;
            Obj.PBoxBorderStyle = _CatalogObjectBorderStye;
            Obj.PBoxBackColor = _CatalogObjectImageBackcolor;
            Obj.PBoxHoverColor = _CatalogObjectImageHovercolor;
            SetClickEventForChilds(Obj);
        }

        /// <summary>
        /// Sets click event of any child control in Control's control collection.
        /// </summary>
        /// <param name="Control"></param>
        private void SetClickEventForChilds(Control Control)
        {
            foreach (Control Ctr in Control.Controls)
            {
                switch (_AlbumStyle)
                {
                    case AlbumStyle.List:
                        Ctr.DoubleClick += ListObjectClicked;
                        break;
                    case AlbumStyle.Catalog:
                        Ctr.DoubleClick += CatalogObjectClicked;
                        break;
                }
                if (Ctr.HasChildren)
                {
                    SetClickEventForChilds(Ctr);
                }
            }
        }

        /// <summary>
        /// Album inner border style
        /// </summary>
        [Category("Design Album")]
        [Description("Album border style")]
        [DefaultValue(typeof(BorderStyle), "None")]
        public BorderStyle Albumborder
        {
            get { return _Albumborder; }
            set
            {
                _Albumborder = value;
                this._AlbumContainer.BorderStyle = _Albumborder;
                Refresh();
            }
        }

        /// <summary>
        /// AlbumStyle property of control
        /// </summary>
        [Category("Design Album")]
        [Description("Album Style")]
        [DefaultValue(typeof(AlbumStyle), "Catalog")]
        public AlbumStyle AlbumStyle
        {
            get { return _AlbumStyle; }
            set
            {
                _AlbumStyle = value;
                this.Btn_Ok.Image = GetOkBtnImg();
                Refresh();
            }
        }

        /// <summary>
        /// Album container margin
        /// </summary>
        [Category("Design Album")]
        [Description("Album Style")]
        [DefaultValue(typeof(Padding), "0,0,0,0")]
        public Padding AlbumMargin
        {
            get { return _AlbumMargin; }
            set
            {
                _AlbumMargin = value;
                this._AlbumContainer.Size = GetAlbumContainerSize();
                this._AlbumContainer.Location = GetAlbumContainerLocation();
                Refresh();
            }
        }

        /// <summary>
        /// Location of control buttons.
        /// </summary>
        [Category("Design Control Panel")]
        [Description("Controls Location")]
        [DefaultValue(typeof(CornerLocation), "Bottom")]
        public CornerLocation CornerLocation
        {
            get { return _CornerLocation; }
            set
            {
                _CornerLocation = value;
                if (_CornerLocation == CornerLocation.None)
                {
                    _ControlPanel.Visible = false;
                    this._AlbumContainer.Size = GetAlbumContainerSize();
                    this._AlbumContainer.Location = GetAlbumContainerLocation();
                }
                else
                {
                    _ControlPanel.Visible = true;
                    _ControlPanel.Location = GetControlButtonsLocation(_ControlPanel);
                    this._AlbumContainer.Size = GetAlbumContainerSize();
                    this._AlbumContainer.Location = GetAlbumContainerLocation();
                }
                Refresh();
            }
        }

        /// <summary>
        /// Location of track bar.
        /// </summary>
        [Category("Design Control Panel")]
        [Description("Controls Location")]
        [DefaultValue(typeof(TrackBarLocation), "Bottom")]
        public TrackBarLocation TrackBarLocation
        {
            get { return _TrackBarLocation; }
            set
            {
                _TrackBarLocation = value;
                trackBar1.Orientation = SetOrientation();
                trackBar1.Size = SetTrackBarSize();
                trackBar1.Location = GetTrackBarLocation(trackBar1);
                this._AlbumContainer.Size = GetAlbumContainerSize();
                this._AlbumContainer.Location = GetAlbumContainerLocation();
                Refresh();
            }
        }

        /// <summary>
        /// Margin of track bar control.
        /// </summary>
        [Category("Design Control Panel")]
        [Description("Controls Margin")]
        [DefaultValue(typeof(int), "10")]
        public int TrackbarMargin
        {
            get { return _TrackbarMargin; }
            set
            {
                _TrackbarMargin = value;
                trackBar1.Location = GetTrackBarLocation(trackBar1);
                this._AlbumContainer.Size = GetAlbumContainerSize();
                this._AlbumContainer.Location = GetAlbumContainerLocation();
                Refresh();
            }
        }

        /// <summary>
        /// Arrow tick for move the image.
        /// </summary>
        [Category("Design Control Panel")]
        [Description("Arrow tick for move the image")]
        [DefaultValue(typeof(int), "10")]
        public int ArrowTick
        {
            get { return _ArrowTick; }
            set
            {
                _ArrowTick = value;
                Refresh();
            }
        }

        /// <summary>
        /// Button area size
        /// </summary>
        [Category("Design Control Panel")]
        [Description("Size of buttons area")]
        [DefaultValue(typeof(Size), "75,75")]
        public Size ControlButtonsSize
        {
            get { return _ControlButtonsSize; }
            set
            {
                _ControlButtonsSize = value;
                this._ControlPanel.Size = _ControlButtonsSize;
                this._AlbumContainer.Size = GetAlbumContainerSize();
                this._AlbumContainer.Location = GetAlbumContainerLocation();
                Refresh();
            }
        }

        /// <summary>
        /// Control buttons margin.
        /// </summary>
        [Category("Design Control Panel")]
        [Description("Controls Margin")]
        [DefaultValue(typeof(Padding), "0,0,0,0")]
        public Padding ControlsButtonMargin
        {
            get { return _ControlsButtonMargin; }
            set
            {
                _ControlsButtonMargin = value;
                this._ControlPanel.Location = GetControlButtonsLocation(_ControlPanel);
                this._AlbumContainer.Size = GetAlbumContainerSize();
                this._AlbumContainer.Location = GetAlbumContainerLocation();
                Refresh();
            }
        }

        /// <summary>
        /// Control buttons back color.
        /// </summary>
        [Category("Design Control Panel")]
        [DefaultValue(typeof(Color), "Orange")]
        [Description("Control buttons back color")]
        public Color ButtonsColor
        {
            get { return _ButtonsColor; }
            set
            {
                _ButtonsColor = value;
                this.Btn_Right.BackColor = _ButtonsColor;
                this.Btn_Bottom.BackColor = _ButtonsColor;
                this.Btn_Left.BackColor = _ButtonsColor;
                this.Btn_Up.BackColor = _ButtonsColor;
                this.Btn_Ok.BackColor = _ButtonsColor;
                Refresh();
            }
        }

        /// <summary>
        /// Control buttons back color when mouse downed on it.
        /// </summary>
        [Category("Design Control Panel")]
        [DefaultValue(typeof(Color), "Yellow")]
        [Description("Control buttons down color")]
        public Color ButtonsDownBackcolor
        {
            get { return _ButtonsDownBackcolor; }
            set
            {
                _ButtonsDownBackcolor = value;
                this.Btn_Right.FlatAppearance.MouseDownBackColor = _ButtonsDownBackcolor;
                this.Btn_Bottom.FlatAppearance.MouseDownBackColor = _ButtonsDownBackcolor;
                this.Btn_Left.FlatAppearance.MouseDownBackColor = _ButtonsDownBackcolor;
                this.Btn_Up.FlatAppearance.MouseDownBackColor = _ButtonsDownBackcolor;
                this.Btn_Ok.FlatAppearance.MouseDownBackColor = _ButtonsDownBackcolor;
                Refresh();
            }
        }

        /// <summary>
        /// Controls buttons hover back color.
        /// </summary>
        [Category("Design Control Panel")]
        [DefaultValue(typeof(Color), "Maroon")]
        [Description("Control buttons hover color")]
        public Color ButtonsHoverBackcolor
        {
            get { return _ButtonsHoverBackcolor; }
            set
            {
                _ButtonsHoverBackcolor = value;
                this.Btn_Right.FlatAppearance.MouseOverBackColor = _ButtonsHoverBackcolor;
                this.Btn_Bottom.FlatAppearance.MouseOverBackColor = _ButtonsHoverBackcolor;
                this.Btn_Left.FlatAppearance.MouseOverBackColor = _ButtonsHoverBackcolor;
                this.Btn_Up.FlatAppearance.MouseOverBackColor = _ButtonsHoverBackcolor;
                this.Btn_Ok.FlatAppearance.MouseOverBackColor = _ButtonsHoverBackcolor;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's track sapphire color.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(typeof(Color), "Orange")]
        [Description("TrackBars tracker color")]
        public Color TrackerColor
        {
            get { return _TrackerColor; }
            set
            {
                _TrackerColor = value;
                this.trackBar1.TrackerColor = _TrackerColor;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's tracking line color.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(typeof(Color), "Gray")]
        [Description("TrackBars track line color")]
        public Color TrackLineColor
        {
            get { return _TrackLineColor; }
            set
            {
                _TrackLineColor = value;
                this.trackBar1.TrackLineColor = _TrackLineColor;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's tick color.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(typeof(Color), "Gray")]
        [Description("TrackBars track tick color")]
        public Color TickColor
        {
            get { return _TickColor; }
            set
            {
                _TickColor = value;
                this.trackBar1.TickColor = _TickColor;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's fore color.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(typeof(Color), "Gray")]
        [Description("TrackBars track fore color")]
        public Color TrackForeColor
        {
            get { return _TrackForeColor; }
            set
            {
                _TrackForeColor = value;
                this.trackBar1.ForeColor = _TrackForeColor;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's track line thickness.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(3)]
        [Description("TrackBars trackline thick")]
        public int TrackLineHeight
        {
            get { return _TrackLineHeight; }
            set
            {
                _TrackLineHeight = value;
                this.trackBar1.TrackLineHeight = _TrackLineHeight;
                this._AlbumContainer.Size = GetAlbumContainerSize();
                this._AlbumContainer.Location = GetAlbumContainerLocation();
                Refresh();
            }
        }

        [Category("Design TrackBar")]
        [DefaultValue(2)]
        [Description("TrackBars inner margin")]
        public int IndentHeight
        {
            get { return _IndentHeight; }
            set
            {
                _IndentHeight = value;
                this.trackBar1.IndentHeight = _IndentHeight;
                Refresh();
            }
        }

        [Category("Design TrackBar")]
        [DefaultValue(6)]
        [Description("TrackBars inner margin")]
        public int IndentWidth
        {
            get { return _IndentWidth; }
            set
            {
                _IndentWidth = value;
                this.trackBar1.IndentWidth = _IndentWidth;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's track sapphire size.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(typeof(Size), "16,16")]
        [Description("TrackBars tracker size")]
        public Size TrackerSize
        {
            get { return _TrackerSize; }
            set
            {
                _TrackerSize = value;
                this.trackBar1.TrackerSize = _TrackerSize;
                this.trackBar1.Location = GetTrackBarLocation(trackBar1);
                this._AlbumContainer.Size = GetAlbumContainerSize();
                this._AlbumContainer.Location = GetAlbumContainerLocation();
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's maximum value.
        /// <list type="bullet">
        ///         <item><c> Also maximum zoom multiplier value.</c></item>
        ///     </list>
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(10)]
        [Description("TrackBars maximum value")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                this.trackBar1.Maximum = _Maximum;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's minimum value.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(0)]
        [Description("TrackBars minimum value")]
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                _Minimum = value;
                this.trackBar1.Minimum = _Minimum;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's maximum track change in one step.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(2)]
        [Description("TrackBars large tick change step value")]
        public int LargeChange
        {
            get { return _LargeChange; }
            set
            {
                _LargeChange = value;
                this.trackBar1.LargeChange = _LargeChange;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's minimum track change in one step.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(1)]
        [Description("TrackBars small tick change step value")]
        public int SmallChange
        {
            get { return _SmallChange; }
            set
            {
                _SmallChange = value;
                this.trackBar1.SmallChange = _SmallChange;
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's tick style.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(typeof(TickStyle), "None")]
        [Description("TrackBars tick style")]
        public TickStyle TickStyle
        {
            get { return _TickStyle; }
            set
            {
                _TickStyle = value;
                this.trackBar1.TickStyle = _TickStyle;
                this.trackBar1.Location = GetTrackBarLocation(trackBar1);
                Refresh();
            }
        }

        /// <summary>
        /// MACTrackBar's text tick style.
        /// </summary>
        [Category("Design TrackBar")]
        [DefaultValue(typeof(TickStyle), "None")]
        [Description("TrackBars text tick style")]
        public TickStyle TextTickStyle
        {
            get { return _TextTickStyle; }
            set
            {
                _TextTickStyle = value;
                this.trackBar1.TextTickStyle = _TextTickStyle;
                this.trackBar1.Location = GetTrackBarLocation(trackBar1);
                Refresh();
            }
        }

        /// <summary>
        /// Height of list objects
        /// </summary>
        [Category("Design List Object")]
        [DefaultValue(75)]
        [Description("Height of list objects")]
        public int ListObjectHeight
        {
            get { return _ListObjectHeight; }
            set
            {
                _ListObjectHeight = value;
                Refresh();
            }
        }

        /// <summary>
        /// ListObject's image arround color.
        /// </summary>
        [Category("Design List Object")]
        [DefaultValue(typeof(Color), "Control")]
        [Description("Picture box margin color")]
        public Color ImageMarginColor
        {
            get { return _ImageMarginColor; }
            set
            {
                _ImageMarginColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// ListObject's information panel back color.
        /// </summary>
        [Category("Design List Object")]
        [DefaultValue(typeof(Color), "Control")]
        [Description("Information label's panel background color")]
        public Color InfoBackColor
        {
            get { return _InfoBackColor; }
            set
            {
                _InfoBackColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// ListObject's image arround hover color.
        /// </summary>
        [Category("Design List Object")]
        [DefaultValue(typeof(Color), "Gray")]
        [Description("Image margin panel mouse over background color")]
        public Color ImageMarginHoverColor
        {
            get { return _ImageMarginHoverColor; }
            set
            {
                _ImageMarginHoverColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// ListObject's information panel hover color.
        /// </summary>
        [Category("Design List Object")]
        [DefaultValue(typeof(Color), "Gray")]
        [Description("Information label's panel mouse over background color")]
        public Color InfoBackHoverColor
        {
            get { return _InfoBackHoverColor; }
            set
            {
                _InfoBackHoverColor = value;
                Refresh();
            }
        }

        /// <summary>
        /// List object picture box border style
        /// </summary>
        [Category("Design List Object")]
        [Description("List object picture box border style")]
        [DefaultValue(typeof(BorderStyle), "None")]
        public BorderStyle PictureBorderStyle
        {
            get { return _PboxBorderStyle; }
            set
            {
                _PboxBorderStyle = value;
                Refresh();
            }
        }

        /// <summary>
        /// List object info label font
        /// </summary>
        [Category("Design List Object")]
        [Description("List object info label font")]
        [DefaultValue(typeof(Font), _DefaultInfoFont)]
        public Font InfoFont
        {
            get { return _InfoFont; }
            set
            {
                _InfoFont = value;
                Refresh();
            }
        }
        /// <summary>
        /// Margin of picture box
        /// </summary>
        [Category("Design List Object")]
        [Description("Margin of picture box")]
        [DefaultValue(typeof(Padding), "15,15,15,15")]
        public Padding PictureBoxMargin
        {
            get { return _PictureBoxMargin; }
            set
            {
                _PictureBoxMargin = value;
                Refresh();
            }
        }

        /// <summary>
        /// Border style of catalog object.
        /// </summary>
        [Category("Design Catalog Object")]
        [Description("Border style of catalog object")]
        [DefaultValue(typeof(BorderStyle), "None")]
        public BorderStyle CatalogObjBorder
        {
            get { return _CatalogObjectBorderStye; }
            set
            {
                _CatalogObjectBorderStye = value;
                Refresh();
            }
        }

        /// <summary>
        /// Size of catalog object.
        /// </summary>
        [Category("Design Catalog Object")]
        [Description("Size of catalog object")]
        [DefaultValue(typeof(Size), "160,120")]
        public Size CatalogObjSize
        {
            get { return _CatalogObjectSize; }
            set
            {
                _CatalogObjectSize = value;
                Refresh();
            }
        }

        /// <summary>
        /// Image size mode of catalog object.
        /// </summary>
        [Category("Design Catalog Object")]
        [Description("Image size mode of catalog object")]
        [DefaultValue(typeof(PictureBoxSizeMode), "Zoom")]
        public PictureBoxSizeMode CatalogObjImgMode
        {
            get { return _CatalogObjectSizeMode; }
            set
            {
                _CatalogObjectSizeMode = value;
                Refresh();
            }
        }

        /// <summary>
        /// Catalog object image back color.
        /// </summary>
        [Category("Design Catalog Object")]
        [Description("Catalog object image back color")]
        [DefaultValue(typeof(Color), "White")]
        public Color CatalogObjImgBackColor
        {
            get { return _CatalogObjectImageBackcolor; }
            set
            {
                _CatalogObjectImageBackcolor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Catalog object image hover back color.
        /// </summary>
        [Category("Design Catalog Object")]
        [Description("Catalog object image hover back color")]
        [DefaultValue(typeof(Color), "Silver")]
        public Color CatalogObjImgHoverColor
        {
            get { return _CatalogObjectImageHovercolor; }
            set
            {
                _CatalogObjectImageHovercolor = value;
                Refresh();
            }
        }

        /// <summary>
        /// Data source of album.
        /// </summary>
        public List<ListObjectDataSource> DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;
                FillData();
            }
        }



        /// <summary>
        /// Data source of album.
        /// </summary>
        private List<ListObjectDataSource> _DataSource;

        /// <summary>
        /// Flow layout panel for listing objects.
        /// </summary>
        private FlowLayoutPanel _ListFlow;

        //
        // Album elements
        //
        private AlbumStyle _AlbumStyle;
        private int _ArrowTick;
        private CornerLocation _CornerLocation;
        private TrackBarLocation _TrackBarLocation;
        private Size _ControlButtonsSize;
        private MACTrackBar trackBar1;

        private int _TrackbarMargin;
        private ControlPanel _ControlPanel;
        private TriangleButton Btn_Bottom;
        private TriangleButton Btn_Right;
        private TriangleButton Btn_Left;
        private TriangleButton Btn_Up;
        private CircularButton Btn_Ok;
        private Padding _ControlsButtonMargin;
        private Color _ButtonsColor;
        private Color _ButtonsDownBackcolor;
        private Color _ButtonsHoverBackcolor;
        private Color _TrackerColor;
        private Color _TrackLineColor;
        private Color _TickColor;
        private Color _TrackForeColor;
        private int _TrackLineHeight;
        private int _IndentHeight;
        private int _IndentWidth;
        private Size _TrackerSize;
        private TickStyle _TickStyle;
        private TickStyle _TextTickStyle;
        private int _Maximum;
        private int _Minimum;
        private int _LargeChange;
        private int _SmallChange;
        private int _ListObjectHeight;

        //
        // Elements of panel that carries the whole list and images in it.
        //
        /// <summary>
        /// Container panel for album.
        /// </summary>
        private Panel _AlbumContainer;
        /// <summary>
        /// Album container panel's border style.
        /// </summary>
        private BorderStyle _Albumborder;
        /// <summary>
        /// Margin of album container panel.
        /// </summary>
        private Padding _AlbumMargin;


        //
        //Catalog object variables
        //
        ///<summary>
        /// Catalog object broder style.
        /// </summary>
        private BorderStyle _CatalogObjectBorderStye;
        ///<summary>
        ///Catalog object size.
        /// </summary>
        private Size _CatalogObjectSize;
        ///<summary>
        ///Catalog object size mode.
        /// </summary>
        private PictureBoxSizeMode _CatalogObjectSizeMode;
        ///<summary>
        /// Image back color of catalog object.
        /// </summary>
        private Color _CatalogObjectImageBackcolor;
        ///<summary>
        /// Image hover color of catalog object.
        /// </summary>
        private Color _CatalogObjectImageHovercolor;

        //
        // List Object variables
        //
        /// <summary>
        /// Back color of panel that behind of list object's picture box.
        /// </summary>
        private Color _ImageMarginColor;
        /// <summary>
        /// Back color of panel that behind of list object's information label.
        /// </summary>
        private Color _InfoBackColor;
        /// <summary>
        /// Back color of panel that behind of list object's picture box when mouse over on it.
        /// </summary>
        private Color _ImageMarginHoverColor;
        /// <summary>
        /// Back color of panel that behind of list object's information label when mouse over on it.
        /// </summary>
        private Color _InfoBackHoverColor;
        /// <summary>
        /// Font of list object's infomation label.
        /// </summary>
        private Font _InfoFont;
        /// <summary>
        /// Border style of list object's picture box.
        /// </summary>
        private BorderStyle _PboxBorderStyle;
        /// <summary>
        /// Margin of list object's picture box.
        /// </summary>
        private Padding _PictureBoxMargin;
        /// <summary>
        /// Default font of list object's information label.
        /// </summary>
        private const string _DefaultInfoFont = "Microsoft Sans Serif, 10pt";
        //
        // Display elements of the selected list object.
        //
        /// <summary>
        /// Picture box that displays the image of selected list object in big picture.
        /// </summary>
        private PictureBox _SoloPBox;

        /// <summary>
        /// Selected object on list. 
        ///     <list type="bullet">
        ///         <item><c> Set the modifier as public if you need to access this object from out of project.</c></item>
        ///     </list>
        /// </summary>
        private ListObject _SelectedObj;
        /// <summary>
        /// Selected object on catalog. 
        ///     <list type="bullet">
        ///         <item><c> Set the modifier as public if you need to access this object from out of project.</c></item>
        ///     </list>
        /// </summary>
        private CatalogObject _SelectedCatalogObj;

        /// <summary>
        /// Data Source of Selected List Object. 
        /// </summary>
        private ListObjectDataSource _SelectedDataSource;
    }
}
