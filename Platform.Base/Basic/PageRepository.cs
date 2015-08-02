using System.Linq;
using Dapper;
using Platform.Core;

namespace Platform.Base.Basic
{

    public interface IPageRepository
    {
        Pages GetAll();
        Page Find(int id);
        Page Find(string id);
        Page Add(Page page);
        void Remove(int id);
    }

    public class PageRepository : BaseRepository<Page, Pages>, IPageRepository
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
