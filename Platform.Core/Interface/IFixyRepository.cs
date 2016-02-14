namespace Platform.Core.Interface
{
    public interface IFixyRepository<T, Ts> : IAdminRepository<T, Ts> where T : FixyModel where Ts : CoreList<T>, new()
    {
        bool FixById(int thisId, int correctId);
    }
}
