using System.Collections.Generic;

namespace Platform.Core.Basic
{
    //ula_mda_bas_video_master
    //Id,UpdatedAt,CreatedAt,UpdatedBy,CreatedBy,Active,Locked,Online

    public class Video : CoreModel
    {
        public string Descript { get; set; }
    }

    // List

    public class Videos
    {
        public Videos()
        {
            page = new Paging();
        }

        public List<Video> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpVideo : ResponseItem<Video>
    {
    }

    public class rpVideos : ResponseItem<Videos>
    {
    }

}
