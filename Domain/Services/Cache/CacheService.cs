//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Services.Cache
//{
//    public class CacheService
//    {
//        private readonly IDistributedCache Cache;
//        private readonly ILogger Logger;
//        public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
//        {
//            Cache = cache;
//            Logger = logger;
//        }

//        public async Task<T> GetAsync<T>(string key)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(key))
//                    return default;

//                var entry = await Cache.GetStringAsync(key);
//                if (string.IsNullOrWhiteSpace(entry))
//                    return default;

//                return JsonConvert.DeserializeObject<T>(entry);
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError(ex, $"Não foi possível recuperar o cache: {key}");
//                return default;
//            }
//        }

//        public Task SetAsync<T>(string key, T entry) => SetAsync(key, entry, TimeSpan.FromMinutes(5));

//        public async Task SetAsync<T>(string key, T entry, TimeSpan absoluteExpiration)
//        {
//            try
//            {
//                if (entry == null)
//                    return;

//                var opcoesCache = new DistributedCacheEntryOptions();
//                opcoesCache.SetAbsoluteExpiration(absoluteExpiration);
//                await Cache.SetStringAsync(key, JsonConvert.SerializeObject(entry), opcoesCache);
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError(ex, $"Não foi possível recuperar o cache: {key}");
//            }
//        }

//        public async Task RemoveAsync(string key)
//        {
//            try
//            {
//                if (key != null)
//                    await Cache.RemoveAsync(key);
//            }
//            catch (Exception ex)
//            {
//                Logger.LogError(ex, $"Não foi possível excluir o cache: {key}");
//            }
//        }

//        public async Task RemoveAsync(params string[] keys)
//        {
//            try
//            {
//                if (keys != null && keys.Length > 0)
//                {
//                    foreach (var key in keys)
//                    {
//                        await Cache.RemoveAsync(key);
//                    }
//                }

//            }
//            catch (Exception ex)
//            {
//                Logger.LogError(ex, $"Não foi possível excluir o cache: {keys}");
//            }
//        }
//    }
//}
