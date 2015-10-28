namespace Platform.Core
{
    using Enums;
    using System;
    using System.Collections.Generic;

    /**
        1. CoreModel    -> CoreRepo<T>
        2. TrakModel    -> TrakRepo<T>
        3. AlonModel    -> AlonRepo<T, Ts>
        4. AdminModel   -> AdminRepo<T, Ts>
        5. UkeyModel    -> UkeyRepo<T, Ts>     -> SimpleUkeyRepo
        6. FixyModel    -> FixyRepo<T, Ts>
    */



    public class CoreModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UkeyModel : CoreModel
    {
        public string Ukey { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class AlonModel : UkeyModel
    {
        public bool Active { get; set; }

        public bool Locked { get; set; }

        public bool Online { get; set; }
    }


    public class AdminModel : AlonModel
    {
        public int AdminedBy { get; set; }

        public DateTime AdminedAt { get; set; }

        public EntryStatus Status { get; set; }
    }

    public class UkeyModelToRemove
    {
        public string Ukey { get; set; }
    }

    public class FixyModel : AdminModel
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



