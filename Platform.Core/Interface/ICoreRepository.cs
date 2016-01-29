﻿using System.Collections.Generic;

namespace Platform.Core.Interface
{
    public interface ICoreRepository<T>
    {
        T GetById(int id);

        T GetByName(string name);

        IEnumerable<T> GetItems(string where = "");
    }
}
