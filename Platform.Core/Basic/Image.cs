﻿namespace Platform.Core.Basic
{
    public class Image : AlonModel
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

    public class rpImage : ResponseItem<Image>
    {
    }

    public class rpImages : ResponseItem<Images>
    {
    }

}
