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

using SimpleLookups.Configuration;
using SimpleLookups.Configuration.Interfaces;
using System;

namespace SimpleLookups
{
    /// <summary>
    /// The main class of the SimpleLookups system.
    /// </summary>
    public static class SimpleLookups
    {
        internal const string DefaultConnectionName = "Default";

        private static readonly object LockObj;
        internal static ISimpleLookupsConfiguration Configuration { get; private set; }
        
        /// <summary>
        /// A boolean indicating whether or not Initialize() has been called.
        /// </summary>
        public static bool IsInitialized { get; internal set; }
        
        static SimpleLookups()
        {
            IsInitialized = false;
            LockObj = new object();

            Configuration = new SimpleLookupsConfiguration(SimpleLookupsConfigurationSection.Instance);
        }

        #region Initialize Methods

        /// <summary>
        /// Initializes SimpleLookups for use.
        /// </summary>
        /// <param name="defaultConnectionString">The connection string that should be used when another isn't supplied.</param>
        public static void Initialize(string defaultConnectionString)
        {
            Initialize(defaultConnectionString, Defaults.IdColumnSuffix, Defaults.NameColumnSuffix,
                Defaults.DescriptionColumnSuffix, Defaults.CodeColumnSuffix, Defaults.ActiveColumnName,
                Defaults.PrefixColumnsWithTableName, Defaults.EnableCaching, Defaults.CacheRefreshPeriod);
        }

        /// <summary>
        /// Initializes SimpleLookups for use.
        /// </summary>
        /// <param name="defaultConnectionString">The connection string that should be used when another isn't supplied.</param>
        /// <param name="enableCaching">A bool indicating whether or not lookup values should be cached locally.</param>
        /// <param name="cacheRefreshPeriod">The number of seconds before the cached value is invalidated. Minimum of 30 seconds.</param>
        public static void Initialize(string defaultConnectionString, bool enableCaching, int cacheRefreshPeriod)
        {
            Initialize(defaultConnectionString, Defaults.IdColumnSuffix, Defaults.NameColumnSuffix,
                Defaults.DescriptionColumnSuffix, Defaults.CodeColumnSuffix, Defaults.ActiveColumnName,
                Defaults.PrefixColumnsWithTableName, enableCaching, cacheRefreshPeriod);
        }  
        
        /// <summary>
        /// Initializes SimpleLookups for use.
        /// </summary>
        /// <param name="defaultConnectionString">The connection string that should be used when another isn't supplied.</param>
        /// <param name="idColumnPrefix">The suffix of the Id column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="nameColumnPrefix">The suffix of the Name column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="descriptionColumnPrefix">The suffix of the Description column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="codeColumnPrefix">The suffix of the Code column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="activeColumnName">The name of the Active column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="prefixColumnNamesWithTableName">A bool indicating whether or not column names (except Active) should be prefixed with the table name.</param>
        public static void Initialize(string defaultConnectionString, string idColumnPrefix, string nameColumnPrefix, string descriptionColumnPrefix,
                                      string codeColumnPrefix, string activeColumnName, bool prefixColumnNamesWithTableName)
        {
            Initialize(defaultConnectionString, idColumnPrefix, nameColumnPrefix, descriptionColumnPrefix,
                codeColumnPrefix, activeColumnName, prefixColumnNamesWithTableName, Defaults.EnableCaching, Defaults.CacheRefreshPeriod);
        }

        /// <summary>
        /// Initializes SimpleLookups for use.
        /// </summary>
        /// <param name="defaultConnectionString">The connection string that should be used when another isn't supplied.</param>
        /// <param name="idColumnPrefix">The suffix of the Id column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="nameColumnPrefix">The suffix of the Name column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="descriptionColumnPrefix">The suffix of the Description column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="codeColumnPrefix">The suffix of the Code column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="activeColumnName">The name of the Active column. Passing a null or an empty string will cause the default value to be used.</param>
        /// <param name="prefixColumnNamesWithTableName">A bool indicating whether or not column names (except Active) should be prefixed with the table name.</param>
        /// <param name="enableCaching">A bool indicating whether or not lookup values should be cached locally.</param>
        /// <param name="cacheRefreshPeriod">The number of seconds before the cached value is invalidated. Minimum of 30 seconds.</param>
        public static void Initialize(string defaultConnectionString, string idColumnPrefix, string nameColumnPrefix, string descriptionColumnPrefix,
                                      string codeColumnPrefix, string activeColumnName, bool prefixColumnNamesWithTableName, bool enableCaching, int cacheRefreshPeriod)
        {
            lock (LockObj)
            {
                if (IsInitialized)
                    throw new InvalidOperationException("SimpleLookups is already initialized.");

                if (!string.IsNullOrEmpty(idColumnPrefix))
                    Configuration.IdColumnSuffix = idColumnPrefix;

                if (!string.IsNullOrEmpty(nameColumnPrefix))
                    Configuration.NameColumnSuffix = nameColumnPrefix;

                if (!string.IsNullOrEmpty(descriptionColumnPrefix))
                    Configuration.DescriptionColumnSuffix = descriptionColumnPrefix;

                if (!string.IsNullOrEmpty(codeColumnPrefix))
                    Configuration.CodeColumnSuffix = codeColumnPrefix;

                if (!string.IsNullOrEmpty(activeColumnName))
                    Configuration.ActiveColumnName = activeColumnName;

                Configuration.PrefixColumnsWithTableName = prefixColumnNamesWithTableName;
                Configuration.EnableCaching = enableCaching;

                if (enableCaching)
                {
                    if(cacheRefreshPeriod < 30)
                        throw new ArgumentException("Cache Refresh Interval must be at least 30 seconds.", "cacheRefreshPeriod");
               
                    Configuration.CacheRefreshPeriod = cacheRefreshPeriod;
                }

                Configuration.AddConnectionString(DefaultConnectionName, defaultConnectionString);
                IsInitialized = true;
            }
        }

        #endregion

        /// <summary>
        /// Adds a connection string to the internal store so that the connection string can be used later by LookupManager.
        /// </summary>
        /// <param name="connectionName">The name of the connection.</param>
        /// <param name="connectionString">The actual connection string.</param>
        public static void AddConnectionString(string connectionName, string connectionString)
        {
            lock (LockObj)
            {
                if (!IsInitialized)
                    throw new InvalidOperationException("SimpleLookups is not initialized.");

                Configuration.AddConnectionString(connectionName, connectionString);
            }
        }
    }
}
