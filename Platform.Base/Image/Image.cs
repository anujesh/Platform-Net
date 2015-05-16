using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.Image
{
    class Image
    {
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Booolean.Core.Models;

namespace Booolean.Core.Webbase
{
    public class Image : BaseModel
    {
        public Image()
        {
            Url = "";
        }

        public string Url { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }

    // List

    public class ImageList
    {
        public ImageList()
        {
            page = new Paging();
        }

        public List<Image> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpImage : Response
    {
        public Image data { get; set; }
    }

    public class rpImageList : Response
    {
        public ImageList data { get; set; }
    }

}
