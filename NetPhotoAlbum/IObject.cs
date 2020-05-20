using System.Drawing;

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
