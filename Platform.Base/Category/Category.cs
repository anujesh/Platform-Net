
using System.Collections.Generic;

using Platform.Core;

namespace Platform.Base.Category
{
    public class Category : CoreModel
    {
        public string UKey { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
    }

    // List

    public class Categories
    {
        public Categories()
        {
            page = new Paging();
        }

        public List<Category> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpCategory : Response
    {
        public Category data { get; set; }
    }

    public class rpCategories : Response
    {
        public Categories data { get; set; }
    }

}
