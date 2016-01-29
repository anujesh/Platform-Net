﻿namespace Platform.Core.Basic
{
    
    //ula_web_bas_link_master
    //Id,Name,Title,Url,OrderBy,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy,Active,Online,Locked
    public class Link : AlonModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string SortOn { get; set; }
    }


    // List

    public class Links : CoreList<Link>
    {
    }

    // Response

    public class rpLink : ResponseItem<Link>
    {
    }

    public class rpLinks : ResponseItem<Links>
    {
    }

}
