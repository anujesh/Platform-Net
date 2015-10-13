using Platform.Base.Provider;
using Platform.Core;
using Platform.Core.Interface;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Platform.Base.Controller
{
    public class UkeyApiController<T, Ts, rpT, rpTs> : ApiController
        where T : AdminModel
        where Ts : CoreList<T>, new()
        where rpT : Response<T>, new()
        where rpTs : Response<Ts>, new()
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(T));

        protected IUkeyRepo<T, Ts> repo;

        public UkeyApiController() : this(null)
        {

        }

        public UkeyApiController(IUkeyRepo<T, Ts> _repoT)
        {
            log.DebugFormat("Type", "");
            repo = _repoT;
        }

        protected async Task<rpTs> List()
        {
            rpTs respo = new rpTs();
            log.Info("Action " + typeof(rpTs));

            try
            {
                //repoT repo = new repoT();
                Ts items = await Task.Run<Ts>(() => repo.GetAll());
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

        protected async Task<rpT> FindById(int id)
        {
            rpT respo = new rpT();
            log.Info("Action " + typeof(rpT));

            try
            {
                //repoT repo = new repoT();
                T items = await Task.Run<T>(() => repo.GetById(id));
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
                T items = await Task.Run<T>(() => repo.Find(uKey));
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

        protected async Task<int> ActionMove(int id, EntryStatus requestedStage)
        {
            T items = await Task.Run<T>(() => repo.GetById(id));

            RequestProvider reqProvider = new RequestProvider();

            if (!ActionChecker.IsRequestedActionValid(reqProvider.UserMode, items.Status, requestedStage))
            {
                //throw "Not allowed";
            }

            return 1;
        }
    }
}
