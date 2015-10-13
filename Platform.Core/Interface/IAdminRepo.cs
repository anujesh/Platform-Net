using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface IAdminRepo<T>
    {
        bool SetStatusTo();

        bool ValidateStatusChange();

        IList<T> GetForModeration();
    }
}
