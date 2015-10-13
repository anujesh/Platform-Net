
using Platform.Base.Repository;

namespace Platform.Core.Basic
{
    public interface IPageRepository
    {
        //Page Find(int id);
        //Page Find(string id);
        //Page Add(Page page);
        //void Remove(int id);
    }

    public class PageRepository : BaseRepo<Page, Pages>, IPageRepository
    {
        public PageRepository()
        {
            tableName = "bol_web_bas_page_master";
        }
        
        public void Remove(int id)
        {
            ///var sqlQuery = string.Format("Delete From {0} Where EmpID = {1}", tableName, id);
            ///this.conn.Execute(sqlQuery);
        }
    }
}
