using Platform.Core;
using Platform.Core.Interface;

namespace Platform.Appn.Controller
{
    abstract public class AlonApiController<T, Ts, rpT, rpTs> : UkeyApiController<T, Ts, rpT, rpTs>
        where T : AlonModel
        where Ts : CoreList<T>, new()
        where rpT : ResponseItem<T>, new()
        where rpTs : ResponseItem<Ts>, new()

    {
        protected readonly IAlonRepository<T, Ts> _repo;

        public AlonApiController(IAlonRepository<T, Ts> repo) : base(repo)
        {
            _repo = repo;
        }
    }
}
