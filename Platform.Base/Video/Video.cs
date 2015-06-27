using Platform.Core;
using System.Collections.Generic;

namespace Platform.Base.Video
{
    //ula_mda_bas_video_master
    //Id,UpdatedAt,CreatedAt,UpdatedBy,CreatedBy,Active,Locked,Online

    public class Video : CoreModel
    {
        public string Name { get; set; }
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

    public class rpVideo : Response
    {
        public Video data { get; set; }
    }

    public class rpVideos : Response
    {
        public Videos data { get; set; }
    }

}
