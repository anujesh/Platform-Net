using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface IAlonRepository<T, Ts> : IUkeyRepository<T, Ts> where T : AlonModel where Ts : CoreList<T>, new()
    {
        bool Lock(int id);

        bool UnLock(int id);

        bool Delete(int id);

        bool Recall(int id);

        bool SetOnline(int id);

        bool SetOffLine(int id);

        IEnumerable<T> GetAllDeleted();

        Ts GetList();
    }
}
