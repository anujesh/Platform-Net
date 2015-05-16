

using System.Collections.Generic;

using Platform.Core;

namespace Platform.Base.Tag
{
    public class Tag : BaseModel
    {
        public string TagKey { get; set; }
        public string TagName { get; set; }
    }

    // List

    public class TagList
    {
        public TagList()
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

    public class rpTagList : Response
    {
        public TagList data { get; set; }
    }

}
