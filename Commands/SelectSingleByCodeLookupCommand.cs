// Simple Lookups
// Copyright (c) 2013-2014, Russell Patterson <russellpatterson@outlook.com>
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
// 3. Neither the name of Russell Patterson nor the names of other contributors may be used to endorse or
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

using SimpleLookups.Commands.SqlServer;
using SimpleLookups.Commands.SqlServer.Interfaces;
using SimpleLookups.Interfaces;
using System.Data;
using System.Data.Common;

namespace SimpleLookups.Commands
{
    internal class SelectSingleByCodeLookupCommand<T> : SelectLookupCommand<T> where T : class, ILookup, new()
    {
        private readonly ISqlStatement _selectByCodeStatement = new SelectSingleByCodeSqlStatement<T>();
        private readonly string _codeToSelect;

        public T Result = null;

        internal SelectSingleByCodeLookupCommand(string code)
            : base("Select")
        {
            _codeToSelect = code;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="connection">The connection to execute on.</param>
        /// <returns>A boolean indicating success.</returns>
        public override bool Execute(DbConnection connection)
        {
            var command = connection.CreateCommand();

            command.CommandText = _selectByCodeStatement.GetQuery();

            AddParameterToCommand(command, "Code", _codeToSelect, DbType.String);

            var reader = command.ExecuteReader();

            // Convert reader into object
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Result = CreateEntityFromDataReader(reader);
                }
            }

            reader.Close();
            return true;
        }
    }
}
