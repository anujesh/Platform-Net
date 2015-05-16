

using System.Collections.Generic;

using Platform.Core;

namespace Platform.Base.Basic
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
