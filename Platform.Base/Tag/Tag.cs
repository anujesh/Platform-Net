

using System.Collections.Generic;

using Platform.Core;

namespace Platform.Base.Tag
{
    public class Tag : CoreModel
    {
        public string TagKey { get; set; }
        public string TagName { get; set; }
    }

    // List

    public class Tags
    {
        public Tags()
        {
            page = new Paging();
        }

        public List<Tag> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpTag : Response
    {
        public Tag data { get; set; }
    }

    public class rpTags : Response
    {
        public Tags data { get; set; }
    }

}
