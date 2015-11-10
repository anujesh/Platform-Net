namespace Platform.Core.Basic
{
    public class Status : AlonModel
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
