﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.Page
{
    class Page
    {
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Booolean.Core.Models;

namespace Booolean.Core.Webbase
{
    public class Page : BaseModel
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
        public Image Image { get; set; }
    }

    // List

    public class PageList
    {
        public PageList()
        {
            page = new Paging();
        }

        public List<Page> list { get; set; }
        public Paging page { get; set; }
        public Summary summ { get; set; }
    }

    // Response

    public class rpPage : Response
    {
        public Page data { get; set; }
    }

    public class rpPageList : Response
    {
        public PageList data { get; set; }
    }

}
