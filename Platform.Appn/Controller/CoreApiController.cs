using System.Web.Http;

namespace Platform.Appn.Controller
{
    public class CoreApiController : ApiController
    {

        protected readonly ICoreRepository<T, Ts> _repo;

        public CoreApiController()
        {

        }
    }
}
