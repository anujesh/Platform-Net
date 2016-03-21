using Platform.Core;
using Platform.Core.Interface;

namespace Platform.Appn.Controller
{
    abstract public class AdminApiController<T, Ts, rpT, rpTs> : AlonApiController<T, Ts, rpT, rpTs>
        where T : AdminModel
        where Ts : CoreList<T>, new()
        where rpT : ResponseItem<T>, new()
        where rpTs : ResponseItem<Ts>, new()
    {
        protected readonly IAdminRepository<T, Ts> _repo;

        public AdminApiController(IAdminRepository<T, Ts> repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
