using Platform.Core.Enums;
using System;

namespace Platform.Core.Request
{
    public class RequestInfo
    {
        public int UserId { get; set; }

        public Devices Device { get; set; }

        public DateTime TimeStamp { get; set; }

        public string LastUrl { get; set; }

        public string IPaddress { get; set; }
    }
}
