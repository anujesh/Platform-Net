

using System.Collections.Generic;

using Platform.Core;

namespace Platform.Base.Basic
{
    public class Post : BaseModel
    {
        public string Key { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Descript { get; set; }
        //public List<Tag> Tags { get; set; }
    }

    // List

    public class PostList
    {
        public PostList()
        {
            page = new Paging();
        }

        public List<Post> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpPost : Response
    {
        public Post data { get; set; }
    }

    public class rpPostList : Response
    {
        public PostList data { get; set; }
    }

}
