using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;

namespace Services.Cache
{
    public class CacheService : ICacheService
    {
        public CacheService()
        {
        }

        private IBlobCache SecureBlob => Akavache.BlobCache.LocalMachine;

        public async Task DeleteAsync(PageDataState dataState)
        {
            try
            {
                var foundCache = await GetCachedDataAsync(dataState.PageName);
                if (foundCache == null)
                    return;

                await Task.Run(() => SecureBlob.InvalidateObject<PageDataState>(dataState.PageName));
            }
            catch (Exception ex)
            {
            }
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                await SecureBlob.InvalidateAll();
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<string> GetCachedDataAsync(string pageName)
        {
            try
            {
                var cachedData = await SecureBlob.GetObject<string>(pageName);
                return cachedData;
            }
            catch (KeyNotFoundException keyNotFound)
            {

                return string.Empty;
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }

        public async Task SaveCachedDataAsync(PageDataState cacheData)
        {
            try
            {
                await Task.Run(() => { SecureBlob.InsertObject(cacheData.PageName, cacheData.PageDataModel, DateTimeOffset.Now.AddDays(10000)); });
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<IEnumerable<string>> GetAllPagesAsync()
        {
            try
            {
                var cachedData = await SecureBlob.GetAllKeys();

                return cachedData;
            }
            catch (Exception ex)
            {
            }
            return new List<string>();
        }
    }
}
