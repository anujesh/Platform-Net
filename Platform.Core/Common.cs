namespace Platform.Core
{
    using System;
    using System.Collections.Generic;

    public class CoreModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class TrakModel : CoreModel
    {
        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class AlonModel : TrakModel
    {
        public Boolean Active { get; set; }

        public Boolean Locked { get; set; }

        public Boolean Online { get; set; }
    }


    public class AdminModel : AlonModel
    {
        public int AdminedBy { get; set; }

        public DateTime AdminedAt { get; set; }

        public EntryStatus Status { get; set; }
    }

    public class UkeyModel : AdminModel
    {
        public string Ukey { get; set; }
    }

    public class Fixyable : UkeyModel
    {
        public int FixId { get; set; }
    }

    public class CoreList<T>
    {
        public CoreList()
        {
            page = new Paging();
        }

        public IEnumerable<T> list { get; set; }

        public Paging page { get; set; }

        public Summary summ { get; set; }
    }
}



