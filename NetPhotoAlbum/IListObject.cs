using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPhotoAlbum
{
    public interface IListObject
    {
        int Id { get; set; }
        Image Picture { get; set; }
        string Information { get; set; }
    }
}
