

using System.Linq;


using Dapper;

using Platform.Core;


namespace Platform.Base.Basic
{

    public interface IPageRepository
    {
        PageList GetAll();
        Page Find(int id);
        Page Find(string id);
        Page Add(Page page);
        //Page Update(Page page);
        void Remove(int id);
    }

    //public class MyDatabase : Database<MyDatabase>
    //{
    //    public Table<Page> Pages { get; set; }
    //}

    public class PageRepository : BaseRepository<Page>, IPageRepository
    {
        public PageRepository()
        {
            tableName = "bol_web_bas_page_master";
        }
        
        //private IDbConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString);

        public PageList GetAll()
        {
            PageList lists = new PageList();
            
            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(string.Format(
                    @"
                    SELECT COUNT(*) as Total FROM {0};
                    SELECT * FROM {0} LIMIT 0, 100"
                    , tableName)))
            {
                lists.summ = multi.Read<Summary>().Single();
                lists.list = multi.Read<Page>().AsList();
            }

            return lists;
        }



        public void Remove(int id)
        {
            ///var sqlQuery = string.Format("Delete From {0} Where EmpID = {1}", tableName, id);
            ///this.conn.Execute(sqlQuery);
        }
    }
}
