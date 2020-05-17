using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NetPhotoAlbum
{
    internal partial class CatalogObject : UserControl
    {
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
        internal CatalogObject()
        {
            InitializeComponent();
            this.PBoxBorderStyle = BorderStyle.None;
            this.PBoxBackColor = Color.White;
            this.PBoxHoverColor = Color.Silver;
            this.PBoxSizeMode = PictureBoxSizeMode.Zoom;
        }



        #region Component Designer

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // Pbox
            // 
            this.Pbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pbox.Location = new System.Drawing.Point(0, 0);
            this.Pbox.Name = "Pbox";
            this.Pbox.Size = new System.Drawing.Size(150, 150);
            this.Pbox.TabIndex = 0;
            this.Pbox.TabStop = false;
            this.Pbox.MouseEnter += ControlMouseEnter;
            this.Pbox.MouseLeave += ControlMouseLeave;
            // 
            // CatalogObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Pbox);
            this.Name = "CatalogObject";
            ((System.ComponentModel.ISupportInitialize)(this.Pbox)).EndInit();
            this.MouseEnter += ControlMouseEnter;
            this.MouseLeave += ControlMouseLeave;
            this.ResumeLayout(false);

        }

        #endregion

        private void ControlMouseEnter(object sender, EventArgs e)
        {
            this.Pbox.BackColor = _PboxBackHoverColor;
            this.BackColor = _PboxBackHoverColor;
            this.IsSelected = true;
        }

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            this.Pbox.BackColor = _PboxBackColor;
            this.BackColor = _PboxBackColor;
            this.IsSelected = false;
        }

        /// <summary>
        /// Picture box size mood.
        /// </summary>
        [Category("Design Control")]
        [Description("Picture box size mood")]
        [DefaultValue(typeof(PictureBoxSizeMode), "Zoom")]
        public PictureBoxSizeMode PBoxSizeMode
        {
            get { return _SizeMode; }
            set
            {
                _SizeMode = value;
                this.Pbox.SizeMode = _SizeMode;
                Refresh();
            }
        }

        /// <summary>
        /// Picture box border style.
        /// </summary>
        [Category("Design Control")]
        [Description("Picture box border style")]
        [DefaultValue(typeof(BorderStyle), "None")]
        public BorderStyle PBoxBorderStyle
        {
            get { return _BorderStyle; }
            set
            {
                _BorderStyle = value;
                this.Pbox.BorderStyle = _BorderStyle;
                Refresh();
            }
        }

        /// <summary>
        /// Picture box back color.
        /// </summary>
        [Category("Design Control")]
        [Description("Picture box back color")]
        [DefaultValue(typeof(Color), "White")]
        public Color PBoxBackColor
        {
            get { return _PboxBackColor; }
            set
            {
                _PboxBackColor = value;
                this.Pbox.BackColor = _PboxBackColor;
                this.BackColor = _PboxBackColor;
                Refresh();
            }
        }
        /// <summary>
        /// Picture box back color.
        /// </summary>
        [Category("Design Control")]
        [Description("Picture box hover back color")]
        [DefaultValue(typeof(Color), "Siver")]
        public Color PBoxHoverColor
        {
            get { return _PboxBackHoverColor; }
            set
            {
                _PboxBackHoverColor = value;
                Refresh();
            }
        }

        public ListObjectDataSource DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;
                this.Pbox.Image = _DataSource.Picture;
                Refresh();
            }
        }

        private ListObjectDataSource _DataSource;

        private PictureBox Pbox;
        private BorderStyle _BorderStyle;
        private Color _PboxBackColor;
        private Color _PboxBackHoverColor;
        private PictureBoxSizeMode _SizeMode;
        public bool IsSelected;
    }
}
