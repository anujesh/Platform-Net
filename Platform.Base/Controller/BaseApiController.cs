using System;
using System.Threading.Tasks;
using System.Web.Http;
using Platform.Base.Provider;
using Platform.Core;
using Platform.Core.Enums;
using Platform.Core.Interface;

namespace Platform.Base.Controller
{
    public class BaseApiController<T, Ts, rpT, rpTs> : ApiController
          where T : AdminModel
          where Ts : CoreList<T>, new()
          where rpT : ResponseItem<T>, new()
          where rpTs : ResponseItem<Ts>, new()
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(T));

        protected IAdminRepository<T, Ts> _repo;

        public BaseApiController(IAdminRepository<T, Ts> repoT)
        {
            log.DebugFormat("Type", "");
            _repo = repoT;
        }

        //[System.Web.Http.Route("listx1")]

        protected async Task<rpTs> List()
        //protected rpTs List()
        {
            rpTs respo = new rpTs();
            log.Info("Action " + typeof(rpTs));

            try
            {
                Ts listTs = await Task.Run<Ts>(() => _repo.GetList());
                //Ts listTs = _repo.GetList();
                respo.data = listTs;
            }
            catch (Exception ex)
            {
                respo.error = 1;
                respo.status = "Error";
                log.ErrorFormat("Pages", ex);
            }

            return respo;
        }

        protected async Task<rpT> FindById(int id)
        {
            rpT respo = new rpT();
            log.Info("Action " + typeof(rpT));

            try
            {
                //repoT repo = new repoT();
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

        protected async Task<rpT> FindByUkey(string uKey)
        {
            rpT respo = new rpT();
            log.Info("Action " + typeof(rpT));

            try
            {
                //repoT repo = new repoT();
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

        protected async Task<int> ActionMove(int id, EntryStatus requestedStage)
        {
            T items = await Task.Run<T>(() => _repo.GetById(id));

            RequestProviderModel reqProvider = new RequestProviderModel();

            if (!ActionChecker.IsRequestedActionValid(reqProvider.UserMode, items.Status, requestedStage))
            {
                //throw "Not allowed";
            }

            return 1;
        }
    }

}
