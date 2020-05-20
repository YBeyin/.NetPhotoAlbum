namespace Test
{
    partial class TestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.netPhotoAlbum1 = new NetPhotoAlbum.NetPhotoAlbum();
            this.SuspendLayout();
            // 
            // netPhotoAlbum1
            // 
            this.netPhotoAlbum1.AlbumStyle = NetPhotoAlbum.AlbumStyle.List;
            this.netPhotoAlbum1.CatalogObjBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.netPhotoAlbum1.CatalogObjImgBackColor = System.Drawing.Color.DarkRed;
            this.netPhotoAlbum1.CatalogObjSize = new System.Drawing.Size(250, 220);
            this.netPhotoAlbum1.CornerLocation = NetPhotoAlbum.CornerLocation.BottomRight;
            this.netPhotoAlbum1.DataSource = null;
            this.netPhotoAlbum1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.netPhotoAlbum1.ImageMarginColor = System.Drawing.Color.Silver;
            this.netPhotoAlbum1.InfoBackColor = System.Drawing.SystemColors.ControlLight;
            this.netPhotoAlbum1.InfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.netPhotoAlbum1.Location = new System.Drawing.Point(0, 0);
            this.netPhotoAlbum1.Name = "netPhotoAlbum1";
            this.netPhotoAlbum1.Size = new System.Drawing.Size(800, 450);
            this.netPhotoAlbum1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.netPhotoAlbum1);
            this.Name = "TestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private NetPhotoAlbum.NetPhotoAlbum netPhotoAlbum1;
    }
}