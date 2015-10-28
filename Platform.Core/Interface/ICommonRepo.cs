using System.Collections.Generic;

namespace Platform.Core.Interface
{
    using Platform.Core.Enums;

    public interface ICoreRepository<T>
    {
        T GetById(int id);

        T GetByName(string name);

        IEnumerable<T> GetItems(string where = "");

        //List<T> GetItems(string where = "");
    }

    public interface IUkeyRepository<T> : ICoreRepository<T> where T : UkeyModel
    {
        T GetByUKey(string ukey);
        //T Find(string uKey);
    }

    public interface IAlonRepository<T, Ts> : IUkeyRepository<T> where T : AlonModel where Ts : CoreList<T>
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

    public interface IAdminRepository<T, Ts> : IAlonRepository<T, Ts> where T : AdminModel where Ts : CoreList<T>
    {
        bool SetStatusTo(EntryStatus newStatus);

        Ts GetForModeration();
        
    }

    public interface IFixyRepository<T, Ts> : IAdminRepository<T, Ts> where T : FixyModel where Ts : CoreList<T>
    {
        bool FixById(int thisId, int correctId);
    }
}
