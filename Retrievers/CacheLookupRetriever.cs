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
using SimpleLookups.Cache;
using SimpleLookups.Cache.Interfaces;
using SimpleLookups.Interfaces;
using SimpleLookups.Retrievers.Interfaces;

namespace SimpleLookups.Retrievers
{
    internal class CacheLookupRetriever<T> : ILookupRetriever<T> where T : class, ILookup, new()
    {
        private readonly ILookupRetriever<T> _backupLookupRetriever;
        private readonly ILookupCache _lookupCache;

        // We need an instance of DbLookupRetriever and an instance of LookupCache
        internal CacheLookupRetriever(ILookupRetriever<T> backupLookupRetriever)
        {
            _backupLookupRetriever = backupLookupRetriever;
            _lookupCache = LookupCache.Instance;
        }

        public T Get(int id, string connectionName)
        {
            var cachedItems = GetFromCache();

            if (cachedItems == null)
            {
                cachedItems = GetFromDb(connectionName);
                StoreInCache(cachedItems);
            }
            
            foreach (var item in cachedItems)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        public IList<T> Get(IList<int> ids, string connectionName)
        {
            var cachedItems = GetFromCache();

            if (cachedItems == null)
            {
                cachedItems = GetFromDb(connectionName);
                StoreInCache(cachedItems);
            }

            var retItems = new List<T>();

            if (ids != null && ids.Count > 0)
            {
                foreach (var item in cachedItems)
                {
                    if (ids.Contains(item.Id))
                        retItems.Add(item);
                }
            }
            
            return retItems;
        }

        public T Get(string code, string connectionName)
        {
            var cachedItems = GetFromCache();

            if (cachedItems == null)
            {
                cachedItems = GetFromDb(connectionName);
                StoreInCache(cachedItems);
            }

            foreach (var item in cachedItems)
            {
                if (item.Code == code)
                    return item;
            }

            return null;
        }

        public IList<T> Get(IList<string> codes, string connectionName)
        {
            var cachedItems = GetFromCache();

            if (cachedItems == null)
            {
                cachedItems = GetFromDb(connectionName);
                StoreInCache(cachedItems);
            }

            var retItems = new List<T>();

            if (codes != null && codes.Count > 0)
            {
                foreach (var item in cachedItems)
                {
                    if (codes.Contains(item.Code))
                        retItems.Add(item);
                }
            }

            return retItems;
        }

        public IList<T> Get(bool activeOnly, string connectionName)
        {
            var cachedItems = GetFromCache();

            if (cachedItems == null)
            {
                cachedItems = GetFromDb(connectionName);
                StoreInCache(cachedItems);
            }

            if(activeOnly)
            { 
                var retItems = new List<T>();
                foreach (var item in cachedItems)
                {
                    if (item.Active)
                        retItems.Add(item);
                }

                return retItems;
            }

            return cachedItems;
        }

        private IList<T> GetFromCache()
        {
            if (_lookupCache != null)
            {
                var cacheItems = _lookupCache.GetCachedItems(typeof(T));
                if (cacheItems == null)
                    return null;

                var retItems = new List<T>();
                foreach (var cacheItem in cacheItems)
                {
                    retItems.Add((T) cacheItem);
                }

                return retItems;
            }

            return null;
        }

        private IList<T> GetFromDb(string connectionName)
        {
            return _backupLookupRetriever.Get(false, connectionName);
        }

        private void StoreInCache(IList<T> lookups)
        {
            var iLookups = new List<ILookup>();

            foreach (var lookup in lookups)
            {
                iLookups.Add(lookup);
            }

            _lookupCache.AddTypeToCache(typeof(T), iLookups, GetExpirationTime());
        }

        private DateTime GetExpirationTime()
        {
            return DateTime.Now.AddSeconds(SimpleLookups.Configuration.CacheRefreshPeriod);
        }
    }
}
