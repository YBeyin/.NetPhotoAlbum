using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NetPhotoAlbum
{
    internal partial class ListObject : UserControl
    {        
        internal ListObject()
        {
            InitializeComponent();
            this.ImageMarginColor = Color.Silver;
            this.InfoBackColor = Color.LightGray;
            this.PictureBorderStyle = BorderStyle.None;
            this.InfoFont = (Font)new FontConverter().ConvertFromString(_DefaultInfoFont);
            this.PictureBoxMargin = new Padding(15);
            this.ImageMarginHoverColor = Color.Gray;
            this.InfoBackHoverColor = Color.Gray;
            this.IsSelected = false;
        }
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tlay_Container = new System.Windows.Forms.TableLayoutPanel();
            this.Pnl_Image = new System.Windows.Forms.Panel();
            this.Pbox = new System.Windows.Forms.PictureBox();
            this.Pnl_Info = new System.Windows.Forms.Panel();
            this.Lbl_Info = new System.Windows.Forms.Label();
            this.Tlay_Container.SuspendLayout();
            this.Pnl_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbox)).BeginInit();
            this.Pnl_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tlay_Container
            // 
            this.Tlay_Container.ColumnCount = 2;
            this.Tlay_Container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.Tlay_Container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tlay_Container.Controls.Add(this.Pnl_Image, 0, 0);
            this.Tlay_Container.Controls.Add(this.Pnl_Info, 1, 0);
            this.Tlay_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tlay_Container.Location = new System.Drawing.Point(0, 0);
            this.Tlay_Container.Margin = new System.Windows.Forms.Padding(0);
            this.Tlay_Container.Name = "Tlay_Container";
            this.Tlay_Container.RowCount = 1;
            this.Tlay_Container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tlay_Container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Tlay_Container.Size = new System.Drawing.Size(450, 100);
            this.Tlay_Container.TabIndex = 0;
            this.Tlay_Container.MouseEnter += ControlMouseEnter;
            this.Tlay_Container.MouseLeave += ControlMouseLeave;
            // 
            // Pnl_Image
            // 
            this.Pnl_Image.Controls.Add(this.Pbox);
            this.Pnl_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Image.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Image.Margin = new System.Windows.Forms.Padding(0);
            this.Pnl_Image.Name = "Pnl_Image";
            this.Pnl_Image.Padding = new System.Windows.Forms.Padding(15);
            this.Pnl_Image.Size = new System.Drawing.Size(150, 100);
            this.Pnl_Image.TabIndex = 0;
            this.Pnl_Image.BackColor = _ImageMarginColor;
            this.Pnl_Image.MouseEnter += ControlMouseEnter;
            this.Pnl_Image.MouseLeave += ControlMouseLeave;
            // 
            // Pbox
            // 
            this.Pbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pbox.Location = new System.Drawing.Point(15, 15);
            this.Pbox.Margin = new System.Windows.Forms.Padding(0);
            this.Pbox.Name = "Pbox";
            this.Pbox.Size = new System.Drawing.Size(120, 70);
            this.Pbox.TabIndex = 0;
            this.Pbox.TabStop = false;
            this.Pbox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Pbox.MouseEnter += ControlMouseEnter;
            this.Pbox.MouseLeave += ControlMouseLeave;
            // 
            // Pnl_Info
            // 
            this.Pnl_Info.Controls.Add(this.Lbl_Info);
            this.Pnl_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Info.Location = new System.Drawing.Point(150, 0);
            this.Pnl_Info.Margin = new System.Windows.Forms.Padding(0);
            this.Pnl_Info.Name = "Pnl_Info";
            this.Pnl_Info.Size = new System.Drawing.Size(300, 100);
            this.Pnl_Info.TabIndex = 1;
            this.Pnl_Info.BackColor = _InfoBackColor;
            this.Pnl_Info.MouseEnter += ControlMouseEnter;
            this.Pnl_Info.MouseLeave += ControlMouseLeave;
            // 
            // Lbl_Info
            // 
            this.Lbl_Info.AutoSize = true;
            this.Lbl_Info.Dock = System.Windows.Forms.DockStyle.None;
            this.Lbl_Info.Font = (Font)new FontConverter().ConvertFromString(_DefaultInfoFont);
            this.Lbl_Info.Location = GetInfoLocation();
            this.Lbl_Info.Name = "Lbl_Info";
            this.Lbl_Info.Size = new System.Drawing.Size(70, 16);
            this.Lbl_Info.TabIndex = 0;
            this.Lbl_Info.Text = "Lbl_Info";
            this.Lbl_Info.MouseEnter += ControlMouseEnter;
            this.Lbl_Info.MouseLeave += ControlMouseLeave;
            // 
            // ListObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Tlay_Container);
            this.Name = "ListObject";
            this.Size = new System.Drawing.Size(450, 100);
            this.Tlay_Container.ResumeLayout(false);
            this.Pnl_Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pbox)).EndInit();
            this.Pnl_Info.ResumeLayout(false);
            this.Pnl_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Overrides
        protected override void OnSizeChanged(EventArgs e)
        {
            this.Lbl_Info.Location = GetInfoLocation();
            base.OnSizeChanged(e);
        }
        private void ControlMouseEnter(object sender, EventArgs e)
        {
            this.Pnl_Image.BackColor = _ImageMarginHoverColor;
            this.Pnl_Info.BackColor = _InfoBackHoverColor;
            this.IsSelected = true;
        }
        private void ControlMouseLeave(object sender, EventArgs e)
        {
            this.Pnl_Image.BackColor = _ImageMarginColor;
            this.Pnl_Info.BackColor = _InfoBackColor;
            this.IsSelected = false;
        }
        #endregion
        private void PopulateData()
        {
            Pbox.SuspendLayout();
            Image _Img;           
            Size ThumbSize;
            if (_DataSource.Path != null)
            {
                if (File.Exists(_DataSource.Path))
                {                    
                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(_DataSource.Path)))
                    {
                        _Img = Image.FromStream(ms, true, false);
                        ThumbSize = CalculateThumbImageSize(_Img.Size, this.Pbox.Size);
                        _Img = _Img.GetThumbnailImage(ThumbSize.Width, ThumbSize.Height, null, new IntPtr());
                    }                    
                }
                else
                {
                    ThumbSize = CalculateThumbImageSize(Images.Resources.brokenImage.Size, this.Pbox.Size);
                    _Img = Images.Resources.brokenImage.GetThumbnailImage(ThumbSize.Width, ThumbSize.Height, null, new IntPtr());
                }
            }
            else if (_DataSource.Image != null)
            {
                ThumbSize = CalculateThumbImageSize(_DataSource.Image.Size, this.Pbox.Size);
                _Img = _DataSource.Image.GetThumbnailImage(ThumbSize.Width, ThumbSize.Height, null, new IntPtr());
            }
            else
            {
                ThumbSize = CalculateThumbImageSize(Images.Resources.brokenImage.Size, this.Pbox.Size);
                _Img = Images.Resources.brokenImage.GetThumbnailImage(ThumbSize.Width, ThumbSize.Height, null, new IntPtr());
            }
            this.Pbox.Image = _Img;
            this.Lbl_Info.Text = _DataSource.Information == null ? "No info!" : _DataSource.Information;
            Pbox.ResumeLayout();
        }

        private Size CalculateThumbImageSize(Size CurrentImageSize, Size ObjectSize)
        {
            Size NewSize = new Size();
            NewSize.Width = ObjectSize.Width - 3;
            NewSize.Height = (int)Math.Round(((float)CurrentImageSize.Height * (float)NewSize.Width) / (float)CurrentImageSize.Width);
            return NewSize;
        }

        private Point GetInfoLocation()
        {
            return new Point(25, (this.Height / 2) - Convert.ToInt32(this.Lbl_Info.Font.Size));
        }

        [Category("Design List Object")]
        [DefaultValue(typeof(Color), "Control")]
        [Description("Picture box margin color")]
        public Color ImageMarginColor
        {
            get { return _ImageMarginColor; }
            set
            {
                _ImageMarginColor = value;
                this.Pnl_Image.BackColor = _ImageMarginColor;
                Refresh();
            }
        }

        [Category("Design List Object")]
        [DefaultValue(typeof(Color), "Control")]
        [Description("Information label's panel background color")]
        public Color InfoBackColor
        {
            get { return _InfoBackColor; }
            set
            {
                _InfoBackColor = value;
                this.Pnl_Info.BackColor = _InfoBackColor;
                Refresh();
            }
        }

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
                this.Pbox.BorderStyle = _PboxBorderStyle;
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
                this.Lbl_Info.Font = _InfoFont;
                this.Lbl_Info.Location = GetInfoLocation();
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
                this.Pnl_Image.Padding = _PictureBoxMargin;
                Refresh();
            }
        }

        public ObjectDataSource DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;               
                PopulateData();                
                Refresh();
            }
        }


        private const string _DefaultInfoFont = "Microsoft Sans Serif, 10pt";
        private System.Windows.Forms.TableLayoutPanel Tlay_Container;
        private System.Windows.Forms.Panel Pnl_Image;
        private System.Windows.Forms.Panel Pnl_Info;
        private System.Windows.Forms.Label Lbl_Info;
        private Color _ImageMarginColor;
        private Color _InfoBackColor;
        private Color _ImageMarginHoverColor;
        private Color _InfoBackHoverColor;
        private Font _InfoFont;
        private ObjectDataSource _DataSource;
        private BorderStyle _PboxBorderStyle;
        private Padding _PictureBoxMargin;
        internal PictureBox Pbox;
        public bool IsSelected;
      
    }
}
