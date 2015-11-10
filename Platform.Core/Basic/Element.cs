using Platform.Core.Enums;

namespace Platform.Core.Basic
{
    //ula_web_bas_element_master
    //Id,ParentId,Name,Title,Type,DisplayOrder,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy,Active,Online,Locked
    public class Element : AlonModel
    {
        public int ParentId { get; set; }
        public string Title { get; set; }
        public ElementType Type { get; set; }
        public int SortOn { get; set; }
    }
}
