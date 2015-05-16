using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.Video
{
    class Video
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
    public class Video : BaseModel
    {
        public string Name { get; set; }
        public string Descript { get; set; }
    }

    // List

    public class VideoList
    {
        public VideoList()
        {
            page = new Paging();
        }

        public List<Video> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpVideo : Response
    {
        public Video data { get; set; }
    }

    public class rpVideoList : Response
    {
        public VideoList data { get; set; }
    }

}
