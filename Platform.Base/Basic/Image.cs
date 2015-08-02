using System.Collections.Generic;
using Platform.Core;

namespace Platform.Base.Basic
{
    public class Image : CoreModel
    {
        public Image()
        {
            Url = "";
        }

        public string Url { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }

    // List

    public class Images : CoreList<Image>
    {
    }

    // Response

    public class rpImage : Response
    {
        public Image data { get; set; }
    }

    public class rpImages : Response
    {
        public Images data { get; set; }
    }

}
