using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Platform.Core;
using System.IO;

namespace Platform.Base.Controller
{
    public class BaseApiController<T, Ts, rpT, rpTs> : ApiController
        where T : AdminModel
        where Ts : CoreList<T>, new()
        where rpT : Response<T>, new()
        where rpTs : Response<Ts>, new()
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(T));

        protected IBaseRepository<T, Ts> repo;

        public BaseApiController() : this(null)
        {

        }

        public BaseApiController(IBaseRepository<T, Ts> _repoT)
        {
            repo = _repoT;
        }

        [HttpGet]
        public async Task<rpTs> List()
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

        [HttpGet]
        public async Task<rpT> FindById(int id)
        {
            rpT respo = new rpT();
            log.Info("Action " + typeof(rpT));

            try
            {
                //repoT repo = new repoT();
                T items = await Task.Run<T>(() => repo.FindById(id));
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

        [HttpGet]
        public async Task<rpT> FindByUkey(string uKey)
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
    }
}
