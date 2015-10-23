using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface ICoreRepo<T>
    {
        T GetById(int id);

        T GetByName(string name);

        IEnumerable<T> GetItems(string where = "");
    }

    public interface IUkeyRepository<T> : ICoreRepo<T>
    {
        T GetByUKey(string ukey);

        bool UpdateUkey(int id, string ukey);

        T Find(string ukey);
    }

    public interface IAlonRepository<T, Ts> : IUkeyRepository<T>
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

    public interface IAdminRepository<T, Ts> : IAlonRepository<T, Ts>
    {
        bool SetStatusTo();

        bool ValidateStatusChange();

        IList<T> GetForModeration();
    }

    public interface IFixyRepository<T, Ts> : IAdminRepository<T, Ts>
    {
        bool FixById(int thisId, int correctId);
    }
}
