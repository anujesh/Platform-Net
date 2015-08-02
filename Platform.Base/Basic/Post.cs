using Platform.Core;
using System.Collections.Generic;

namespace Platform.Base.Basic
{
    public class Post : CoreModel
    {
        public string Key { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
        //public List<Tag> Tags { get; set; }
    }

    // List

    public class Posts : CoreList<Post>
    {
    }

    // Response

    public class rpPost : Response
    {
        public Post data { get; set; }
    }

    public class rpPosts : Response
    {
        public Posts data { get; set; }
    }

}
