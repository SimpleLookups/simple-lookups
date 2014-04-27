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

        /// <summary>
        /// Initializes SimpleLookups for use.
        /// </summary>
        /// <param name="defaultConnectionString">The connection string that should be used when another isn't supplied.</param>
        public static void Initialize(string defaultConnectionString)
        {
            lock (LockObj)
            {
                if (IsInitialized)
                    throw new InvalidOperationException("SimpleLookups is already initialized.");

                Configuration.AddConnectionString(DefaultConnectionName, defaultConnectionString);
                IsInitialized = true;
            }
        }

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
