using System.Collections.Generic;

namespace Platform.Core.Tag
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

    public class rpTag : ResponseItem<Tag>
    {
    }

    public class rpTags : ResponseItem<Tags>
    {
    }

}
