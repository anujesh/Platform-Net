using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface ICoreRepo<T>
    {
        T GetById(int id);

        T GetByName(int name);

        IEnumerable<T> GetAll();
    }
}
