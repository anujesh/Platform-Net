using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface ICoreRepo<T>
    {
        T GetById(int id);

        T GetByName(string name);

        IEnumerable<T> GetItems(string where = "");
    }

    // ITrackModel 

    public interface IAlonRepo<T> : ICoreRepo<T>
    {
        bool Lock(int id);

        bool UnLock(int id);

        bool Delete(int id);

        bool Recall(int id);

        bool SetOnline(int id);

        bool SetOffLine(int id);

        IEnumerable<T> GetAllDeleted();
    }



    public interface IAdminRepo<T, Ts> : IAlonRepo<T>
    {
        bool SetStatusTo();

        bool ValidateStatusChange();

        IList<T> GetForModeration();

        Ts GetList();
    }


    public interface IUkeyRepo<T, Ts> : IAdminRepo<T, Ts>
    {
        T GetByUKey(string ukey);

        bool UpdateUkey(int id, string ukey);

        T Find(string ukey);
    }

    public interface IFixyRepo<T, Ts> : IUkeyRepo<T, Ts>
    {
        bool FixById(int thisId, int correctId);
    }
}
