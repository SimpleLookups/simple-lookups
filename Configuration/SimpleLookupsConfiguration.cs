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

using SimpleLookups.Configuration.Interfaces;
using SimpleLookups.Databases;
using SimpleLookups.Databases.Interfaces;
using SimpleLookups.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SimpleLookups.Configuration
{
    /// <summary>
    /// The current configuration of SimpleLookups.
    /// </summary>
    internal class SimpleLookupsConfiguration : ISimpleLookupsConfiguration
    {
        private static readonly object LockObj = new object();
        private IList<IConnectionInfo> ConnectionInfos { get; set; }
        
        internal SimpleLookupsConfiguration(ISimpleLookupsConfigurationSection configSection)
        {
            ConnectionInfos = new List<IConnectionInfo>();

            SetDefaultColumns();

            if(configSection != null)
            {
                var defaultConnectionStringSection = configSection.ConnectionStrings.GetDefault();

                if (defaultConnectionStringSection == null)
                    throw new SimpleLookupsException("More than one connection string was supplied, but there wasn't a default specified.", null);

                ValidateConnectionStringExists(defaultConnectionStringSection.ConnectionStringName);
                AddConnectionInfo(SimpleLookups.DefaultConnectionName, ConfigurationManager.ConnectionStrings[defaultConnectionStringSection.ConnectionStringName].ConnectionString);

                foreach (IConnectionStringConfigurationElement c in configSection.ConnectionStrings)
                {
                    ValidateConnectionStringExists(c.ConnectionStringName);
                    AddConnectionInfo(c.ConnectionStringName, ConfigurationManager.ConnectionStrings[c.ConnectionStringName].ConnectionString);
                }

                if (!string.IsNullOrEmpty(configSection.IdColumnSuffix))
                    IdColumnSuffix = configSection.IdColumnSuffix.Trim();

                if (!string.IsNullOrEmpty(configSection.NameColumnSuffix))
                    NameColumnSuffix = configSection.NameColumnSuffix.Trim();

                if (!string.IsNullOrEmpty(configSection.DescriptionColumnSuffix))
                    DescriptionColumnSuffix = configSection.DescriptionColumnSuffix.Trim();

                if (!string.IsNullOrEmpty(configSection.CodeColumnSuffix))
                    CodeColumnSuffix = configSection.CodeColumnSuffix.Trim();

                if (!string.IsNullOrEmpty(configSection.ActiveColumnName))
                    ActiveColumnName = configSection.ActiveColumnName.Trim();

                PrefixColumnsWithTableName = configSection.PrefixColumnsWithTableName;

                SimpleLookups.IsInitialized = true;
            }
        }

        /// <summary>
        /// Adds a connection string to the internal store.
        /// </summary>
        /// <param name="connectionName">The name of the connection.</param>
        /// <param name="connectionString">The actual connection string.</param>
        public void AddConnectionString(string connectionName, string connectionString)
        {
            lock (LockObj)
            {
                if (String.IsNullOrEmpty(connectionName) || connectionName.Trim() == String.Empty)
                    throw new ArgumentException("connectionName must be a valid, non-whitespace string.");

                if (String.IsNullOrEmpty(connectionString) || connectionString.Trim() == String.Empty)
                    throw new ArgumentException("connectionString must be a valid, non-whitespace string.");

                AddConnectionInfo(connectionName, connectionString);
            }
        }

        /// <summary>
        /// Retrieves a connection string from the internal store.
        /// </summary>
        /// <param name="connectionName">The name of the connection.</param>
        /// <returns>The matching connection string.</returns>
        public IConnectionInfo GetConnectionString(string connectionName)
        {
            foreach (var cs in ConnectionInfos)
            {
                if (cs.ConnectionName == connectionName)
                    return cs;
            }

            return null;
        }

        public string IdColumnSuffix { get; set; }
        public string NameColumnSuffix { get; set; }
        public string DescriptionColumnSuffix { get; set; }
        public string CodeColumnSuffix { get; set; }
        public string ActiveColumnName { get; set; }
        public bool PrefixColumnsWithTableName { get; set; }

        private static void ValidateConnectionStringExists(string connectionName)
        {
            if (ConfigurationManager.ConnectionStrings[connectionName] == null)
            {
                throw new SimpleLookupsException(string.Format("Connection string named \"{0}\" was not found in the configuration file.", connectionName), null);
            }
        }

        private void AddConnectionInfo(string connectionName, string connectionString)
        {
            var connInfo = new ConnectionInfo(connectionName, connectionString);

            ConnectionInfos.Add(connInfo);
        }

        private void SetDefaultColumns()
        {
            IdColumnSuffix = "Id";
            NameColumnSuffix = "Name";
            DescriptionColumnSuffix = "Description";
            CodeColumnSuffix = "Code";
            ActiveColumnName = "Active";
            PrefixColumnsWithTableName = true;
        }
    }
}
