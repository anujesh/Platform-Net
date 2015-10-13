using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface IBaseRepo<T>
    {
        T GetById(int id);

        T GetByName(string name);

        IEnumerable<T> GetAll();
    }

    // ITrackModel 

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



    public interface IAdminRepo<T>
    {
        bool SetStatusTo();

        bool ValidateStatusChange();

        IList<T> GetForModeration();
    }


    public interface IUkeyRepo<T, Ts>// : IAdminRepo<T>
    {
        T GetByUKey(string ukey);

        bool UpdateUkey(int id, string ukey);
    }

    public interface IFixyRepo<T, Ts> : IUkeyRepo<T, Ts>
    {
        bool FixById(int thisId, int correctId);
    }
}
