

using System.Collections.Generic;

using Platform.Core;

namespace Platform.Core.Status
{
    public class Status : CoreModel
    {
        public string Content { get; set; }
    }

    // List

    public class Statuses : CoreList<Status>
    {
    }

    // Response

    public class rpStatus : ResponseItem<Status>
    {
    }

    public class rpStatuses : ResponseList<Statuses>
    {
    }

}
