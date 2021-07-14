﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Raymaker.RedisTutorial.Services
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        
        public Task<string> GetCacheValueAsync(string key)
        {
            return Task.FromResult(this._cache.Get<string>(key));
        }

        public Task SetCacheValueAsync(string key, string value)
        {
            this._cache.Set(key, value);
            return Task.CompletedTask;
        }
    }
}
