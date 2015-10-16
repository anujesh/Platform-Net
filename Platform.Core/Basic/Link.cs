
namespace Platform.Core.Link
{


    //ula_web_bas_link_master
    //Id,Name,Title,Url,OrderBy,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy,Active,Online,Locked
    public class Link : AlonModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string OrderBy { get; set; }
    }


    // List

    public class Links : CoreList<Link>
    {
    }

    // Response

    public class rpLink : ResponseItem<Link>
    {
        public Link data { get; set; }
    }

    public class rpLinks : ResponseItem<Links>
    {
        public Links data { get; set; }
    }

}
