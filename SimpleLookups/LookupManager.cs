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

using SimpleLookups.Interfaces;
using SimpleLookups.Mutators;
using SimpleLookups.Mutators.Interfaces;
using SimpleLookups.Retrievers;
using SimpleLookups.Retrievers.Interfaces;
using System.Collections.Generic;

namespace SimpleLookups
{
    /// <summary>
    /// Manages database communication for a lookup type.
    /// </summary>
    /// <typeparam name="T">Any class object that inherits from ILookup.</typeparam>
    public class LookupManager<T> : ILookupManager<T> where T : class, ILookup, new()
    {        
		private readonly ILookupRetriever<T> _lookupRetriever;
        private readonly ILookupMutator<T> _lookupMutator;

        /// <summary>
        /// Creates a LookupManager for a given ILookup type
        /// </summary>
        public LookupManager()
        {
            _lookupRetriever = new DbLookupRetriever<T>();
            _lookupMutator = new DbLookupMutator<T>();

            if (SimpleLookups.Configuration.EnableCaching)
            {
                _lookupRetriever = new CacheLookupRetriever<T>(_lookupRetriever);
            }
        }
		
        /// <summary>
        /// Creates a lookup value.
        /// </summary>
        /// <param name="lookup">The lookup data to create.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Create(T lookup)
        {
            return Create(lookup, SimpleLookups.DefaultConnectionName);
        }
        
        /// <summary>
        /// Creates a lookup value.
        /// </summary>
        /// <param name="lookup">The lookup data to create.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Create(T lookup, string connectionName)
        {
            return _lookupMutator.Create(lookup, connectionName);
        }

        /// <summary>
        /// Updates a lookup value.
        /// </summary>
        /// <param name="lookup">The lookup value to update.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Update(T lookup)
        {
            return Update(lookup, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Updates a lookup value.
        /// </summary>
        /// <param name="lookup">The lookup value to update.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Update(T lookup, string connectionName)
        {
            return _lookupMutator.Update(lookup, connectionName);
        }
        
        /// <summary>
        /// Removes a lookup value, by it's code.
        /// </summary>
        /// <param name="id">The unique id of the lookup to delete.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(int id)
        {
            return Delete(id, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Removes a lookup value, by it's code.
        /// </summary>
        /// <param name="id">The unique id of the lookup to delete.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(int id, string connectionName)
        {
            return _lookupMutator.Delete(id, connectionName);
        }
        
        /// <summary>
        /// Removes several lookup values, by their ids.
        /// </summary>
        /// <param name="ids">The unique ids of the lookups to delete.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(IList<int> ids)
        {
            return Delete(ids, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Removes several lookup values, by their ids.
        /// </summary>
        /// <param name="ids">The unique ids of the lookups to delete.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(IList<int> ids, string connectionName)
        {
            return _lookupMutator.Delete(ids, connectionName);
        }

        /// <summary>
        /// Removes a lookup value, by it's code.
        /// </summary>
        /// <param name="code">The unique code of the lookup to delete.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(string code)
        {
            return Delete(code, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Removes a lookup value, by it's code.
        /// </summary>
        /// <param name="code">The unique code of the lookup to delete.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(string code, string connectionName)
        {
            return _lookupMutator.Delete(code, connectionName);
        }

        /// <summary>
        /// Removes several lookup values, by their ids.
        /// </summary>
        /// <param name="codes">The unique codes of the lookups to delete.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(IList<string> codes)
        {
            return Delete(codes, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Removes several lookup values, by their ids.
        /// </summary>
        /// <param name="codes">The unique ids of the lookups to delete.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A boolean value indicating whether the operation was a success.</returns>
        public bool Delete(IList<string> codes, string connectionName)
        {
            return _lookupMutator.Delete(codes, connectionName);
        }

        /// <summary>
        /// Get a lookup by its id.
        /// </summary>
        /// <param name="id">The id of the requested lookup.</param>
        /// <returns>The requested lookup value.</returns>
        public T Get(int id)
        {
            return Get(id, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Get a lookup by its id.
        /// </summary>
        /// <param name="id">The id of the requested lookup.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>The requested lookup value.</returns>
        public T Get(int id, string connectionName)
        {
            return _lookupRetriever.Get(id, connectionName);
        }

        /// <summary>
        /// Get several lookups by their ids.
        /// </summary>
        /// <param name="ids">The ids of the requested lookups.</param>
        /// <returns>A list of the requested lookup values.</returns>
        public IList<T> Get(IList<int> ids)
        {
            return Get(ids, SimpleLookups.DefaultConnectionName);
        }
        
        /// <summary>
        /// Get several lookups by their ids.
        /// </summary>
        /// <param name="ids">The ids of the requested lookups.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A list of the requested lookup values.</returns>
        public IList<T> Get(IList<int> ids, string connectionName)
        {
            return _lookupRetriever.Get(ids, connectionName);
        }
        
        /// <summary>
        /// Get a lookup by its code.
        /// </summary>
        /// <param name="code">The code of the requested lookup.</param>
        /// <returns>The requested lookup value.</returns>
        public T Get(string code)
        {
            return Get(code, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Get a lookup by its code.
        /// </summary>
        /// <param name="code">The code of the requested lookup.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>The requested lookup value.</returns>
        public T Get(string code, string connectionName)
        {
            return _lookupRetriever.Get(code, connectionName);
        }

        /// <summary>
        /// Get several lookups by their codes.
        /// </summary>
        /// <param name="codes">The codes of the requested lookups.</param>
        /// <returns>A list of the requested lookup values.</returns>
        public IList<T> Get(IList<string> codes)
        {
            return Get(codes, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Get several lookups by their codes.
        /// </summary>
        /// <param name="codes">The codes of the requested lookups.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A list of the requested lookup values.</returns>
        public IList<T> Get(IList<string> codes, string connectionName)
        {
            return _lookupRetriever.Get(codes, connectionName);
        }

        /// <summary>
        /// Gets a list of all of the lookups.
        /// </summary>
        /// <param name="activeOnly">Specifies whether or not only active lookups should be included.</param>
        /// <returns>A list of the requested lookup values.</returns>
        public IList<T> Get(bool activeOnly)
        {
            return Get(activeOnly, SimpleLookups.DefaultConnectionName);
        }

        /// <summary>
        /// Gets a list of all of the lookups.
        /// </summary>
        /// <param name="activeOnly">Specifies whether or not only active lookups should be included.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A list of the requested lookup values.</returns>
        public IList<T> Get(bool activeOnly, string connectionName)
        {
            return _lookupRetriever.Get(activeOnly, connectionName);
        }
    }
}
