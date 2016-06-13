// Simple Lookups 2.0
// Copyright (c) 2013-2015, Russell Patterson <russellpatterson@outlook.com>
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, are permitted provided 
// that the following conditions are met:
//
// 1. Redistributions of source code must retain the above copyright notice, this list of conditions and 
//    the following disclaimer.
//
// 2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and 
//    the following disclaimer in the documentation and/or other materials provided with the distribution.
//
// 3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or
//    promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.
//

using System;
using System.Collections.Generic;
using SimpleLookups.Cache.Interfaces;
using SimpleLookups.Interfaces;
using System.Linq;

namespace SimpleLookups.Cache
{
    /// <summary>
    /// Type that manages the caching of Lookup types
    /// </summary>
    internal class LookupCache : ILookupCache
    {
        private static readonly object LockObj = new object();

        private static readonly ILookupCache _instance;

        static LookupCache()
        {
            _instance = new LookupCache();
        }

        #region Singleton
      //  private static ILookupCache _instance;

        public static ILookupCache Instance
        {
            get
            {
                //lock (LockObj)
                //{
                //    if (_instance == null)
                //    {
                //        _instance = new LookupCache();
                //    }
                //}

                return _instance;
            }
        }
        #endregion
        
        private readonly IList<ILookupCacheItem> _cache;

        private LookupCache()
        {
            _cache = new List<ILookupCacheItem>();
        }

        public void AddTypeToCache(Type type, IList<ILookup> lookups, DateTime expiration)
        {
            lock (LockObj)
            {
                var cachedType = GetByType(type);

                if (cachedType == null)
                {
                    cachedType = new LookupCacheItem
                    {
                        LookupType = type
                    };

                    _cache.Add(cachedType);
                }

                cachedType.LookupCache = lookups;
                cachedType.Expiration = expiration;
            }
        }

        public IList<ILookup> GetCachedItems(Type type)
        {
            // Returns a null if the type isn't in the cache or if the cache is expired
            lock (LockObj)
            {
                var cachedType = GetByType(type);

                // We don't return expired items. If it's expired, pretend we didn't find anything.
                if (cachedType != null && cachedType.Expiration > DateTime.Now)
                {
                    return cachedType.LookupCache;
                }
            }

            return null;
        }

        public void InvalidateCache(Type type)
        {
            lock (LockObj)
            {
                var cacheItem = GetByType(type);

                if(cacheItem != null)
                {
                    cacheItem.Expiration = DateTime.Now;
                }
            }
        }

        private ILookupCacheItem GetByType(Type type)
        {
            if (_cache == null)
                return null;
            
            return _cache.FirstOrDefault(c => c.LookupType == type);
        }
    }
}
