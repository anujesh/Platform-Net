using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Platform.Core;

namespace Platform.Base.Element
{
    //ula_web_bas_element_master
    //Id,ParentId,Name,Title,Type,DisplayOrder,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy,Active,Online,Locked
    public class Element : LoasModel
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string DisplayOrder { get; set; }
    }
}
