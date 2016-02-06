using Platform.Core;
using Platform.Core.Interface;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Platform.Appn.Controller
{
    abstract public class CoreApiController<T, Ts, rpT, rpTs> : ApiController
        where T : CoreModel
        where Ts : CoreList<T>, new()
        where rpT : ResponseItem<T>, new()
        where rpTs : ResponseItem<Ts>, new()

    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(T));
        protected readonly ICoreRepository<T> _repo;

        public CoreApiController(ICoreRepository<T> repo)
        {
            _repo = repo;
        }

        protected async Task<rpT> FindById(int id)
        {
            rpT respo = new rpT();
            log.Info("Action " + typeof(rpT));

            try
            {
                T items = await Task.Run<T>(() => _repo.GetById(id));
                respo.data = items;
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
