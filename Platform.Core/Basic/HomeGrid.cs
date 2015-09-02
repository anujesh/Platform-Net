
using System;
using System.Collections.Generic;


namespace Platform.Core.HomeGrid
{
    public class HomeGrid : CoreModel
    {
        public string GridName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<GridBox> Boxes { get; set; }
    }

    public class GridBox : CoreModel
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public int SortBy { get; set; }
    }

    // List

    public class HomeGrids : CoreList<HomeGrid>
    {
    }

    // Response

    public class rpHomeGrid : Response<HomeGrid>
    {
    }

    public class rpHomeGrids : Response<HomeGrids>
    {
    }
}
