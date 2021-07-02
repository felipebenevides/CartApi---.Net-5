using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T entry, TimeSpan absoluteExpiration);

        Task RemoveAsync(string key);

        Task RemoveAsync(params string[] keys);
    }
}
