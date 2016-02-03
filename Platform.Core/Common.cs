namespace Platform.Core
{
    using Enums;
    using System;
    using System.Collections.Generic;

    abstract public class CoreModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    abstract public class UkeyModel : CoreModel
    {
        public string Ukey { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    abstract public class AlonModel : UkeyModel
    {
        public bool Active { get; set; }

        public bool Locked { get; set; }

        public bool Online { get; set; }
    }

    abstract public class AdminModel : AlonModel
    {
        public int AdminedBy { get; set; }

        public DateTime AdminedAt { get; set; }

        public EntryStatus Status { get; set; }
    }

    abstract public class FixyModel : AdminModel
    {
        public int FixId { get; set; }
    }

    abstract public class CoreList<T>
    {
        public CoreList()
        {
            page = new Paging();
            list = new List<T>();
            summ = new Summary();
        }

        public List<T> list { get; set; }

        public Paging page { get; set; }

        public Summary summ { get; set; }
    }
}



