namespace Platform.Core
{
    using System;

    public class CoreModel
    {
        public int Id { get; set; }
    }

    public class BaseModel : CoreModel
    {
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class LoasModel : BaseModel
    {
        public Boolean Online { get; set; }
        public Boolean Active { get; set; }
        public Boolean Locked { get; set; }
    }

    public class AdminableModel : LoasModel
    {
        public int AdminedBy { get; set; }
        public DateTime AdminedAt { get; set; }
    }

    public class Fixable : AdminableModel
    {
        public int FixId { get; set; }
    }

    public class CoreList
    {
        public CoreList()
        {
            page = new Paging();
        }
        
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }
}



