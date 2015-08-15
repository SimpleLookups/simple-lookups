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

using System.Collections.Generic;
using SimpleLookups.Interfaces;

namespace SimpleLookups.Retrievers.Interfaces
{
    internal interface ILookupRetriever<T> where T : ILookup
    {
        /// <summary>
        /// Get a lookup by its id.
        /// </summary>
        /// <param name="id">The id of the requested lookup.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>The requested lookup value.</returns>
        T Get(int id, string connectionName);

        /// <summary>
        /// Get several lookups by their ids.
        /// </summary>
        /// <param name="ids">The ids of the requested lookups.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A list of the requested lookup values.</returns>
        IList<T> Get(IList<int> ids, string connectionName);

        /// <summary>
        /// Get a lookup by its code.
        /// </summary>
        /// <param name="code">The code of the requested lookup.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>The requested lookup value.</returns>
        T Get(string code, string connectionName);

        /// <summary>
        /// Get several lookups by their codes.
        /// </summary>
        /// <param name="codes">The codes of the requested lookups.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A list of the requested lookup values.</returns>
        IList<T> Get(IList<string> codes, string connectionName);

        /// <summary>
        /// Gets a list of all of the lookups.
        /// </summary>
        /// <param name="activeOnly">Specifies whether or not only active lookups should be included.</param>
        /// <param name="connectionName">The name of the connection to use.</param>
        /// <returns>A list of the requested lookup values.</returns>
        IList<T> Get(bool activeOnly, string connectionName);
    }
}
