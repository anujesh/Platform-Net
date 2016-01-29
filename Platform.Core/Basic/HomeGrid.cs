using System;
using System.Collections.Generic;

namespace Platform.Core.Basic
{
    public class Homegrid : CoreModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<HomegridBox> Boxes { get; set; }
    }

    public class HomegridBox : CoreModel
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public int SortBy { get; set; }
    }

    // List

    public class HomeGrids : CoreList<Homegrid>
    {
    }

    // Response

    public class rpHomeGrid : ResponseItem<Homegrid>
    {
    }

    public class rpHomeGrids : ResponseItem<HomeGrids>
    {
    }
}
