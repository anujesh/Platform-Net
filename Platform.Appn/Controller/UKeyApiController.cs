using Platform.Core;
using Platform.Core.Interface;
using System;
using System.Threading.Tasks;

namespace Platform.Appn.Controller
{
    abstract public class UkeyApiController<T, Ts, rpT, rpTs> : CoreApiController<T, Ts, rpT, rpTs>
        where T : UkeyModel
        where Ts : CoreList<T>, new()
        where rpT : ResponseItem<T>, new()
        where rpTs : ResponseItem<Ts>, new()
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(T));
        protected readonly IUkeyRepository<T> _repo;

        public UkeyApiController(IUkeyRepository<T> repo) : base(repo)
        {
            _repo = repo;
        }

        protected async Task<rpT> FindByUkey(string uKey)
        {
            rpT respo = new rpT();
            log.Info("Action " + typeof(rpT));

            try
            {
                T item = await Task.Run<T>(() => _repo.GetByUKey(uKey));
                respo.data = item;
            }
            catch (Exception ex)
            {
                respo.error = 1;
                respo.status = "Error";
                log.ErrorFormat("Pages", ex);
            }

            return respo;
        }

        protected async Task<rpTs> GetList()
        {
            rpTs respo = new rpTs();
            log.Info("Action " + typeof(rpTs));

            try
            {
                //T item = await Task.Run<T>(() => _repoTs GetList(string onWhere = "")GetByUKey(uKey));
                //respo.data = item;
            }
            catch (Exception ex)
            {
                respo.error = 1;
                respo.status = "Error";
                log.ErrorFormat("Pages", ex);
            }

            return respo;

        }

    }
}
