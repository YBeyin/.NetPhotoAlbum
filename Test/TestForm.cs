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
            List<ListObjectDataSource> Objs = new List<ListObjectDataSource>();
            for (int i = 0; i < 25; i++)
            {
                ListObjectDataSource obj = new ListObjectDataSource();
                obj.Picture = Properties.Resources.SadCat;
                obj.Information = "Test Picture " + i.ToString();
                Objs.Add(obj);
            }
            netPhotoAlbum1.DataSource = Objs;
        }

        private void netPhotoAlbum1_Load(object sender, EventArgs e)
        {

        }
    }
}
