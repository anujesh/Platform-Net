using Platform.Core;
using Platform.Core.Enums;

namespace Platform.Base.Repository
{
    public interface IAdminRepo
    {

    }

    public class AdminRepo<T, TS> : AlonRepo<T, TS>, IAdminRepo where T : AdminModel where TS : CoreList<T>, new()
    {
        public TS GetSubmittedList()
        {
            return GetList(string.Format("Status={0}", (int)EntryStatus.Submitted));
        }
    }
}
