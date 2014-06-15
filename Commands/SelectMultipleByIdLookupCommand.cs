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
using System.Collections.Generic;
using System.Data.Common;

namespace SimpleLookups.Commands
{
    internal class SelectMultipleByIdLookupCommand<T> : SelectLookupCommand<T> where T : class, ILookup, new()
    {
        private readonly ISqlStatement _sqlStatement;
        private readonly IList<int> _idsToSelect;

        public readonly IList<T> Result;

        internal SelectMultipleByIdLookupCommand(IList<int> ids)
            : base("Select")
        {
            _idsToSelect = ids;
            Result = new List<T>();

            _sqlStatement = new SelectMultipleByIdSqlStatement<T>();
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="connection">The connection to execute on.</param>
        /// <returns>A boolean indicating success.</returns>
        public override bool Execute(DbConnection connection)
        {
            var command = connection.CreateCommand();

            command.CommandText = string.Format(_sqlStatement.GetQuery(),
                                                GenerateCsvParameterNameString(_idsToSelect.Count, "Id"));

            AddIdParameterValues(command, _idsToSelect);

            var reader = command.ExecuteReader();

            // Convert reader into object
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Result.Add(CreateEntityFromDataReader(reader));
                }
            }

            reader.Close();
            return true;
        }
    }
}
