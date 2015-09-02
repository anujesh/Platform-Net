using System.Collections.Generic;

namespace Platform.Core.Basic
{
    public class Page : AdminModel
    {
        public Page()
        {
            Image = new Image();
        }

        public string UKey { get; set; }
        public string UText { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; }
        public string Content { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }

    // List

    public class Pages : CoreList<Page>
    {
    }

    // Response

    public class rpPage : Response<Page>
    {
    }

    public class rpPages : Response<Pages>
    {
    }

    public class vmPage
    {
        public Page item { get; set; }
    }

    public class vmPages
    {
        public List<Page> list { get; set; }
    }

}
