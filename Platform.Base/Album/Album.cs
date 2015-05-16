using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.Album
{
    class Album
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
    // item

    public class Album : BaseModel
    {
        public string Name { get; set; }
        public string Descript { get; set; }
    }

    // List

    public class AlbumList
    {
        public AlbumList()
        {
            page = new Paging();
        }

        public List<Album> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpAlbum : Response
    {
        public Album data { get; set; }
    }

    public class rpAlbumList : Response
    {
        public AlbumList data { get; set; }
    }
}
