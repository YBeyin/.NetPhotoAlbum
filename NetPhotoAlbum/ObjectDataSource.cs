﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPhotoAlbum
{
    [Serializable]
    public class ObjectDataSource : IObject,IDisposable
    {
        public int Id { get; set; }      
        public string Information { get; set; }
        public Image Image { get; set; }
        public string Path { get ; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
