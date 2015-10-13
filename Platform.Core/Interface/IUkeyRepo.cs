namespace Platform.Core.Interface
{
    public interface IUkeyRepo<T>
    {
        T GetByUKey(string ukey);

        bool UpdateUkey(int id, string ukey);
    }
}
