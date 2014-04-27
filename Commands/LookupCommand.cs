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

using System.Collections.Generic;
using System.Data;
using System.Text;
using SimpleLookups.Commands.Interfaces;
using System.Data.Common;

namespace SimpleLookups.Commands
{
    internal abstract class LookupCommand : ILookupCommand
    {
        /// <summary>
        /// The name of the command to use in messages.
        /// </summary>
        public string CommandName { get; private set; }

        protected internal LookupCommand(string commandName)
        {
            CommandName = commandName;
        }
        
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="connection">The connection to execute on.</param>
        /// <returns>A boolean indicating success.</returns>
        public abstract bool Execute(DbConnection connection);

        /// <summary>
        /// Add Id parameters to DbCommand.
        /// </summary>
        /// <param name="command">The command instance.</param>
        /// <param name="ids">The list of ids</param>
        protected internal static void AddIdParameterValues(DbCommand command, IList<int> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                for (var i = 0; i < ids.Count; i++)
                {
                    AddParameterToCommand(command, "Id", i.ToString(), ids[i], DbType.Int32);
                }
            }
        }

        /// <summary>
        /// Add Code parameters to DbCommand.
        /// </summary>
        /// <param name="command">The command instance.</param>
        /// <param name="codes">The list of codes</param>
        protected internal static void AddCodeParameterValues(DbCommand command, IList<string> codes)
        {
            if (codes != null && codes.Count > 0)
            {
                for (var i = 0; i < codes.Count; i++)
                {
                    AddParameterToCommand(command, "Code", i.ToString(), codes[i], DbType.String);
                }
            }
        }

        /// <summary>
        /// Generates a string of parameter replacements.
        /// </summary>
        /// <param name="paramCount">The number to create.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <returns>A CSV string with the specified number of commands.</returns>
        protected internal static string GenerateCsvParameterNameString(int paramCount, string paramName)
        {
            var sb = new StringBuilder();

            if (paramCount > 0)
            {
                sb.Append(string.Format("@{0}0", paramName));

                for (var i = 1; i < paramCount; i++)
                {
                    sb.Append(string.Format(", @{0}{1}", paramName, i));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Adds a parameter to a command instance.
        /// </summary>
        /// <param name="command">The command to operate on.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="val">The value of the parameter.</param>
        /// <param name="type">The type of the parameter.</param>
        protected internal static void AddParameterToCommand(DbCommand command, string paramName, object val, DbType type)
        {
            AddParameterToCommand(command, paramName, null, val, type);
        }

        /// <summary>
        /// Adds a parameter to a command instance.
        /// </summary>
        /// <param name="command">The command to operate on.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="ordinal">The number of the parameter.</param>
        /// <param name="val">The value of the parameter.</param>
        /// <param name="type">The type of the parameter.</param>
        private static void AddParameterToCommand(DbCommand command, string paramName, string ordinal, object val, DbType type)
        {
            var param = command.CreateParameter();

            param.ParameterName = string.Format("@{0}{1}", paramName, ordinal ?? string.Empty);
            param.DbType = type;
            param.Value = val;

            command.Parameters.Add(param);
        }
    }
}
