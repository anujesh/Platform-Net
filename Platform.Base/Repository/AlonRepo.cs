using Platform.Core;
using Platform.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base.Repository
{

    public class AlonRepo<T, Ts> : BaseRepo<T, Ts>, IAlonRepo<T> where T : AlonModel where Ts : CoreList<T>, new()
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllDeleted()
        {
            throw new NotImplementedException();
        }

        public bool Lock(int id)
        {
            throw new NotImplementedException();
        }

        public bool Recall(int id)
        {
            throw new NotImplementedException();
        }

        public bool SetOffLine(int id)
        {
            throw new NotImplementedException();
        }

        public bool SetOnline(int id)
        {
            throw new NotImplementedException();
        }

        public bool UnLock(int id)
        {
            throw new NotImplementedException();
        }
    }
}
