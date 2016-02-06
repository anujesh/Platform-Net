using System;
using Platform.Core;
using Platform.Core.Interface;

namespace Platform.Base.Repository
{
    abstract public class FixyRepository<T, Ts> : AdminRepository<T, Ts>, IFixyRepository<T, Ts> where T : FixyModel, new() where Ts : CoreList<T>, new()
    {
        public bool FixById(int thisId, int correctId)
        {
            throw new NotImplementedException();
        }
    }
}
