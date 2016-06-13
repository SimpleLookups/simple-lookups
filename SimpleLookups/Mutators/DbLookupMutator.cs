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

using SimpleLookups.Commands;
using SimpleLookups.Interfaces;
using SimpleLookups.Mutators.Interfaces;
using System.Collections.Generic;

namespace SimpleLookups.Mutators
{
    internal class DbLookupMutator<T> : ILookupMutator<T> where T : class, ILookup, new()
    {
        public bool Create(T lookup, string connectionName)
        {
            var command = new InsertLookupCommand<T>(lookup);

            return ExecuteCommand(command, connectionName);
        }

        public bool Delete(string code, string connectionName)
        {
            var command = new DeleteSingleByCodeLookupCommand<T>(code);

            return ExecuteCommand(command, connectionName);
        }

        public bool Delete(IList<string> codes, string connectionName)
        {
            var command = new DeleteMultipleByCodeLookupCommand<T>(codes);

            return ExecuteCommand(command, connectionName);
        }

        public bool Delete(IList<int> ids, string connectionName)
        {
            var command = new DeleteMultipleByIdLookupCommand<T>(ids);

            return ExecuteCommand(command, connectionName);
        }

        public bool Delete(int id, string connectionName)
        {
            var command = new DeleteSingleByIdLookupCommand<T>(id);

            return ExecuteCommand(command, connectionName);
        }

        public bool Update(T lookup, string connectionName)
        {
            var command = new UpdateLookupCommand<T>(lookup);

            return ExecuteCommand(command, connectionName);
        }
        
        private bool ExecuteCommand(Commands.Interfaces.ILookupCommand command, string connectionName)
        {
            var commandExecutor = new Execution.CommandExecutor(command);

            var retVal = commandExecutor.ExecuteCommand(connectionName);

            if(retVal == true && SimpleLookups.Configuration.EnableCaching)
            {
                // If we created/updated/deleted, let's refresh the cache for this type
                Cache.LookupCache.Instance.InvalidateCache(typeof(T));
            }

            return retVal;
        }
    }
}
