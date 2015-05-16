using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.HomeGrid
{
    class HomeGrid
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
    public class HomeGrid : BaseModel
    {
        public string GridName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<GridBox> Boxes { get; set; }
    }

    public class GridBox : BaseModel
    {
        public int GridId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    // List

    public class HomeGridList
    {
        public HomeGridList()
        {
            page = new Paging();
        }

        public List<HomeGrid> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpHomeGrid : Response
    {
        public HomeGrid data { get; set; }
    }

    public class rpHomeGridList : Response
    {
        public HomeGridList data { get; set; }
    }

}
