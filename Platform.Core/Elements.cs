using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core
{
    class Elements
    {
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booolean.Core.Models
{
    public class HttpStatus
    {
        public HttpStatus()
        {
            Status = "OK";
            ErrNo = 0;
        }

        public string Status { get; set; }
        public int ErrNo { get; set; }
    }

    public class Response
    {
        public Response()
        {
            error = 0;
            status = "OK";
        }

        public int error { get; set; }
        public string status { get; set; }
    }

    public class Paging
    {
        public Paging()
        {
            total = 0;
            page= 0;
            start = 0;
            limit = 0;
            page = 0;
            active = false;
        }

        public int total { get; set; }
        public int pages { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public int page { get; set; }
        public bool active { get; set; }
    }

    public class Summary
    {
        public Summary()
        {
            total = 0;
        }

        public int total { get; set; }
    }


    public class DOB
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }

}
