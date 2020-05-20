using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPhotoAlbum
{
    public interface IObject
    {
        int Id { get; set; }
        Image Image { get; set; }
        string Path { get; set; }
        string Information { get; set; }
    }
}
