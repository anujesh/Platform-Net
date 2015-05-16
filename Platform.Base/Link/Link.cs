

using System.Collections.Generic;

using Platform.Core;

namespace Platform.Base.Link
{
    public class Link : BaseModel
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    // List

    public class LinkList
    {
        public LinkList()
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

    public class rpLinkList : Response
    {
        public LinkList data { get; set; }
    }

}
