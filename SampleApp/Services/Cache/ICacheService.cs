using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Cache
{
    public interface ICacheService
    {
        Task<string> GetCachedDataAsync(string pageName);

        Task SaveCachedDataAsync(PageDataState cacheData);

        Task DeleteAsync(PageDataState cacheData);

        Task DeleteAllAsync();

        Task<IEnumerable<string>> GetAllPagesAsync();
    }
}
