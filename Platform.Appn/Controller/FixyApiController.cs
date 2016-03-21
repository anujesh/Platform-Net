using Platform.Core;
using Platform.Core.Interface;

namespace Platform.Appn.Controller
{
    abstract public class FixyApiController<T, Ts, rpT, rpTs> : AdminApiController<T, Ts, rpT, rpTs>
        where T : FixyModel
        where Ts : CoreList<T>, new()
        where rpT : ResponseItem<T>, new()
        where rpTs : ResponseItem<Ts>, new()
    {
        protected readonly IFixyRepository<T, Ts> _repo;

        public FixyApiController(IFixyRepository<T, Ts> repo) : base(repo) 
        {
            _repo = repo;
        }
    }
}
