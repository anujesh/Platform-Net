using Platform.Core;
using Platform.Core.Enums;
using Platform.Core.Interface;
using System;

namespace Platform.Base.Repository
{
    public class AdminRepository<T, Ts> : AlonRepository<T, Ts>, IAdminRepository<T, Ts> where Ts : CoreList<T>, new() where T : AdminModel, new()
    {
        public Ts GetSubmittedList()
        {
            return GetList(string.Format("Status={0}", (int)EntryStatus.Submitted));
        }

        public bool SetStatusTo(EntryStatus status)
        {
            throw new NotImplementedException();
        }

        public Ts GetForModeration()
        {
            throw new NotImplementedException();
        }
    }
}
