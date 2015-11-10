using System.Collections.Generic;

namespace Platform.Core.Basic
{
    public class Tag : CoreModel
    {
        public string TagKey { get; set; }
        public string TagName { get; set; }
    }

    // List

    public class Tags : CoreList<Tag>
    {
    }

    // Response

    public class rpTag : ResponseItem<Tag>
    {
    }

    public class rpTags : ResponseItem<Tags>
    {
    }

}
