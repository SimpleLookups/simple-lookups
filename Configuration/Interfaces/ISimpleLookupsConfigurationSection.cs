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

namespace SimpleLookups.Configuration.Interfaces
{
    /// <summary>
    /// Interface for main configuration section.
    /// </summary>
    public interface ISimpleLookupsConfigurationSection
    {
        /// <summary>
        /// Id Column Suffix
        /// </summary>
        string IdColumnSuffix { get; set; }

        /// <summary>
        /// Name Column Suffix
        /// </summary>
        string NameColumnSuffix { get; set; }

        /// <summary>
        /// Description Column Suffix
        /// </summary>
        string DescriptionColumnSuffix { get; set; }

        /// <summary>
        /// Code Column Suffix
        /// </summary>
        string CodeColumnSuffix { get; set; }

        /// <summary>
        /// Active Column Name
        /// </summary>
        string ActiveColumnName { get; set; }

        /// <summary>
        /// A bool indicating whether the column names will be prefixed with the table name. (not including Active column)
        /// </summary>
        bool PrefixColumnsWithTableName { get; set; }

        /// <summary>
        /// A bool indicating whether caching is enabled.
        /// </summary>   
        bool EnableCaching { get; set; }

        /// <summary>
        /// Number of seconds before cache information is refreshed.
        /// </summary>
        int CacheRefreshPeriod { get; set; }
        
        /// <summary>
        /// Collection of connection strings.
        /// </summary>
        ConnectionStringsConfigurationElementCollection ConnectionStrings { get; set; }
    }
}
