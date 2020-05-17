using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetPhotoAlbum
{
    internal partial class ControlPanel : UserControl
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

        #region Component Designer

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Bottom = new TriangleButton();
            this.Btn_Right = new TriangleButton();
            this.Btn_Left = new TriangleButton();
            this.Btn_Up = new TriangleButton();
            this.Btn_Ok = new CircularButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_Bottom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Right, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Left, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Up, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Ok, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.32667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(90, 90);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Btn_Bottom
            // 

            this.Btn_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Bottom.FlatAppearance.BorderSize = 0;
            this.Btn_Bottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Bottom.Location = new System.Drawing.Point(32, 62);
            this.Btn_Bottom.Name = "Btn_Bottom";
            this.Btn_Bottom.Rotate = Rotation.Bottom;
            this.Btn_Bottom.Size = new System.Drawing.Size(24, 25);
            this.Btn_Bottom.TabIndex = 0;
            this.Btn_Bottom.UseVisualStyleBackColor = false;
            // 
            // Btn_Right
            //           
            this.Btn_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Right.FlatAppearance.BorderSize = 0;
            this.Btn_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Right.Location = new System.Drawing.Point(62, 32);
            this.Btn_Right.Name = "Btn_Right";
            this.Btn_Right.Rotate = Rotation.Right;
            this.Btn_Right.Size = new System.Drawing.Size(25, 24);
            this.Btn_Right.TabIndex = 1;
            this.Btn_Right.UseVisualStyleBackColor = false;
            // 
            // Btn_Left
            //           
            this.Btn_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Left.FlatAppearance.BorderSize = 0;
            this.Btn_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Left.Location = new System.Drawing.Point(3, 32);
            this.Btn_Left.Name = "Btn_Left";
            this.Btn_Left.Rotate = Rotation.Left;
            this.Btn_Left.Size = new System.Drawing.Size(23, 24);
            this.Btn_Left.TabIndex = 2;
            this.Btn_Left.UseVisualStyleBackColor = false;
            // 
            // Btn_Up
            //             
            this.Btn_Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Up.FlatAppearance.BorderSize = 0;
            this.Btn_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Up.Location = new System.Drawing.Point(32, 3);
            this.Btn_Up.Name = "Btn_Up";
            this.Btn_Up.Size = new System.Drawing.Size(24, 23);
            this.Btn_Up.TabIndex = 3;
            this.Btn_Up.UseVisualStyleBackColor = false;
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Ok.FlatAppearance.BorderSize = 0;
            this.Btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ok.Location = new System.Drawing.Point(32, 32);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(24, 24);
            this.Btn_Ok.TabIndex = 4;
            this.Btn_Ok.UseVisualStyleBackColor = false;
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Controller";
            this.Size = new System.Drawing.Size(90, 90);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal ControlPanel()
        {
            InitializeComponent();
            this.ButtonsColor = Color.Orange;
            this.ButtonsDownBackcolor = Color.Transparent;
            this.ButtonsHoverBackcolor = Color.Transparent;
        }

        [Category("Design")]
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

        [Category("Design")]
        [DefaultValue(typeof(Color), "Transparent")]
        [Description("Control buttons back color")]
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

        [Category("Design")]
        [DefaultValue(typeof(Color), "Transparent")]
        [Description("Control buttons back color")]
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

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TriangleButton Btn_Bottom;
        private TriangleButton Btn_Right;
        private TriangleButton Btn_Left;
        private TriangleButton Btn_Up;
        private CircularButton Btn_Ok;
        private Color _ButtonsColor;
        private Color _ButtonsDownBackcolor;
        private Color _ButtonsHoverBackcolor;
    }
}
