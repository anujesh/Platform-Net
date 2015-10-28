using System.Collections.Generic;

namespace Platform.Core.Album
{


    // item

    public class Album : CoreModel
    {
        public string Name { get; set; }
        public string Descript { get; set; }
    }

    // List

    public class Albums
    {
        public Albums()
        {
            page = new Paging();
        }

        public List<Album> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpAlbum : ResponseItem<Album>
    {
    }

    public class rpAlbums : ResponseItem<Albums>
    {
    }
}
