namespace Platform.Core.Interface
{
    public interface IUkeyRepository<T, Ts> : ICoreRepository<T> where T : UkeyModel where Ts : CoreList<T>, new()
    {
        T GetByUKey(string ukey);

        Ts GetList();

        Ts GetList(string onWhere = "");
    }
}
