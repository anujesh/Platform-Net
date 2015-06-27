﻿using System.Collections.Generic;
using Platform.Core;

namespace Platform.Base.Link
{


    //ula_web_bas_link_master
    //Id,Name,Title,Url,OrderBy,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy,Active,Online,Locked
    public class Link : LoasModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string OrderBy { get; set; }
    }


    // List

    public class Links
    {
        public Links()
        {
            page = new Paging();
        }

        public List<Link> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpLink : Response
    {
        public Link data { get; set; }
    }

    public class rpLinks : Response
    {
        public Links data { get; set; }
    }

}
