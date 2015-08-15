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

using SimpleLookups.Configuration.Interfaces;
using System.Configuration;

namespace SimpleLookups.Configuration
{
    /// <summary>
    /// Handles configuration in the configuration file.
    /// </summary>
    public class SimpleLookupsConfigurationSection : ConfigurationSection, ISimpleLookupsConfigurationSection
    {
        private SimpleLookupsConfigurationSection()
        {
        }

        /// <summary>
        /// Get the configuration section.
        /// </summary>
        public static ISimpleLookupsConfigurationSection Instance
        {
            get 
            {
                try
                {
                    return (ISimpleLookupsConfigurationSection)ConfigurationManager.GetSection("simpleLookups");
                }
                catch (ConfigurationErrorsException)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Id Column Suffix
        /// </summary>
        [ConfigurationProperty("idColumnSuffix", IsRequired = false, DefaultValue = "Id")]
        public string IdColumnSuffix
        {
            get { return (string)base["idColumnSuffix"]; }
            set { base["idColumnSuffix"] = value; }
        }

        /// <summary>
        /// Name Column Suffix
        /// </summary>
        [ConfigurationProperty("nameColumnSuffix", IsRequired = false, DefaultValue = "Name")]
        public string NameColumnSuffix
        {
            get { return (string)base["nameColumnSuffix"]; }
            set { base["nameColumnSuffix"] = value; }
        }

        /// <summary>
        /// Description Column Suffix
        /// </summary>
        [ConfigurationProperty("descriptionColumnSuffix", IsRequired = false, DefaultValue = "Description")]
        public string DescriptionColumnSuffix
        {
            get { return (string)base["descriptionColumnSuffix"]; }
            set { base["descriptionColumnSuffix"] = value; }
        }

        /// <summary>
        /// Code Column Suffix
        /// </summary>
        [ConfigurationProperty("codeColumnSuffix", IsRequired = false, DefaultValue = "Code")]
        public string CodeColumnSuffix
        {
            get { return (string)base["codeColumnSuffix"]; }
            set { base["codeColumnSuffix"] = value; }
        }

        /// <summary>
        /// Active Column Name
        /// </summary>
        [ConfigurationProperty("activeColumnName", IsRequired = false, DefaultValue = "Active")]
        public string ActiveColumnName
        {
            get { return (string)base["activeColumnName"]; }
            set { base["activeColumnName"] = value; }
        }
        
        /// <summary>
        /// A bool indicating whether the column names will be prefixed with the table name. (not including Active column)
        /// </summary>
        [ConfigurationProperty("prefixColumnsWithTableName", IsRequired = false, DefaultValue = true)]
        public bool PrefixColumnsWithTableName
        {
            get { return (bool)base["prefixColumnsWithTableName"]; }
            set { base["prefixColumnsWithTableName"] = value; }
        }

        /// <summary>
        /// A bool indicating whether caching is enabled.
        /// </summary>
        [ConfigurationProperty("enableCaching", IsRequired = false, DefaultValue = true)]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        /// <summary>
        /// Number of seconds before cache information is refreshed.
        /// </summary>
        [ConfigurationProperty("cacheRefreshPeriod", IsRequired = false, DefaultValue = 1800)]
        public int CacheRefreshPeriod
        {
            get { return (int)base["cacheRefreshPeriod"]; }
            set { base["cacheRefreshPeriod"] = value; }
        }

        /// <summary>
        /// The collection of connection string objects.
        /// </summary>
        [ConfigurationProperty("connectionStrings", IsRequired = true)]
        public virtual ConnectionStringsConfigurationElementCollection ConnectionStrings
        {
            get { return (ConnectionStringsConfigurationElementCollection) base["connectionStrings"]; }
            set { base["connectionStrings"] = value; }
        }
    }
}
