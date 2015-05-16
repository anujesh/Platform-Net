using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.Status
{
    class Status
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
    public class Status : BaseModel
    {
        public string Content { get; set; }
    }

    // List

    public class StatusList
    {
        public StatusList()
        {
            page = new Paging();
        }

        public List<Status> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpStatus : Response
    {
        public Status data { get; set; }
    }

    public class rpStatusList : Response
    {
        public StatusList data { get; set; }
    }

}
