using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.Link
{
    class Link
    {
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Booolean.Core.Models;

namespace Booolean.Core.Webbase
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
