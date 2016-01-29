namespace Platform.Core.Interface
{
    public interface IUkeyRepository<T> : ICoreRepository<T> where T : UkeyModel
    {
        T GetByUKey(string ukey);
    }
}
