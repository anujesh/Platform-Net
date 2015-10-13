using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface IAlonRepo<T>
    {
        bool Lock(int id);

        bool UnLock(int id);

        bool Delete(int id);

        bool Recall(int id);

        bool SetOnline(int id);

        bool SetOffLine(int id);

        IEnumerable<T> GetAllDeleted();
    }
}
