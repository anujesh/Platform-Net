
namespace Platform.Core
{
    public class CoreModel
    {
        public int Id { get; set; }
    }

    public class BaseModel : CoreModel
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class LoasModel : BaseModel
    {
        public string Online { get; set; }
        public string Active { get; set; }
        public string Locked { get; set; }
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



