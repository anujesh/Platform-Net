using Platform.Core.Enums;

namespace Platform.Core.Interface
{
    public interface IAdminRepository<T, Ts> : IAlonRepository<T, Ts> where T : AdminModel where Ts : CoreList<T>, new()
    {
        bool SetStatusTo(EntryStatus newStatus);

        Ts GetForModeration();
    }
}
