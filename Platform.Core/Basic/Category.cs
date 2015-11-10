namespace Platform.Core.Basic
{
    public class Category : AlonModel
    {
        public string Descript { get; set; }
    }

    // List
    public class Categories : CoreList<Category>
    {
    }

    // Response
    public class rpCategory : ResponseItem<Category>
    {
    }

    public class rpCategories : ResponseItem<Categories>
    {
    }

}
