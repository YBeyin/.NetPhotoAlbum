using NetPhotoAlbum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            populate();
        }
        private void populate()
        {
            List<ObjectDataSource> Objs = new List<ObjectDataSource>();
            for (int i = 0; i < 25; i++)
            {
                ObjectDataSource obj = new ObjectDataSource();
                //obj.Image = Properties.Resources.textImage5000x4000;
                //obj.Path = //image path of Properties.Resources.SadCat.jpg;
                //obj.Path = @"..Resources\textImage5000x4000.jpg"; // path of the image  
                obj.Information = "Test Picture " + i.ToString();
                Objs.Add(obj);
            }
            netPhotoAlbum1.DataSource = Objs;
        }
    }
}
