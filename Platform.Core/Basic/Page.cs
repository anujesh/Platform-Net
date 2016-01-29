using System.Collections.Generic;

namespace Platform.Core.Basic
{
    public class Page : AlonModel
    {
        public Page()
        {
            Image = new Image();
        }

        public string Utext { get; set; }
        public string Title { get; set; }
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

    public class rpPage : ResponseItem<Page>
    {
    }

    public class rpPages : ResponseItem<Pages>
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
