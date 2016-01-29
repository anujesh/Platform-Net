using Platform.Base.Repository;

namespace Platform.Core.Basic
{
    public class PageRepository : AlonRepository<Page, Pages>
    {
        public PageRepository()
        {
            tableName = "bol_web_bas_page_master";
        }
    }
}
