namespace Platform.Core.Basic
{
    public class Post : AlonModel
    {
        public string Descript { get; set; }
        //public List<Tag> Tags { get; set; }
    }

    // List

    public class Posts : CoreList<Post>
    {
    }

    // Response

    public class rpPost : ResponseItem<Post>
    {
    }

    public class rpPosts : ResponseItem<Posts>
    {
    }
}
