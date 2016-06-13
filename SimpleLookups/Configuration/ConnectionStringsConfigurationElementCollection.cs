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
    /// The collection of connection strings.
    /// </summary>
    [ConfigurationCollection(typeof(ConnectionStringConfigurationElement), AddItemName = "connectionStrings")]
    public class ConnectionStringsConfigurationElementCollection : ConfigurationElementCollection, IConnectionStringsConfigurationElementCollection
    {
        /// <summary>
        /// Creates a new element.
        /// </summary>
        /// <returns>A new element.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringConfigurationElement();
        }

        /// <summary>
        /// Get the key value of a configuration element.
        /// </summary>
        /// <param name="element">The configuration element.</param>
        /// <returns>An object that describes the configuration element.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionStringConfigurationElement)(element)).ConnectionStringName;
        }

        /// <summary>
        /// Defines the collection type for this collection.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }

        /// <summary>
        /// Defines the element name for each element.
        /// </summary>
        protected override string ElementName
        {
            get { return "connectionString"; }
        }

        /// <summary>
        /// Checks to see if an element name matches.
        /// </summary>
        /// <param name="elementName">The element name to check.</param>
        /// <returns>A boolean indicating if the element name matches.</returns>
        protected override bool IsElementName(string elementName)
        {
            return elementName == ElementName;
        }

        /// <summary>
        /// Indexer by order.
        /// </summary>
        /// <param name="index">The index of the connection string.</param>
        /// <returns>The connection string.</returns>
        public IConnectionStringConfigurationElement this[int index]
        {
            get
            {
                return ((IConnectionStringConfigurationElement)(BaseGet(index)));
            }
        }

        /// <summary>
        /// Indexer by connection string name.
        /// </summary>
        /// <param name="refName">The name of the connection string.</param>
        /// <returns>The connection string.</returns>
        public IConnectionStringConfigurationElement this[object refName]
        {
            get
            {
                return ((IConnectionStringConfigurationElement)(BaseGet(refName)));
            }
        }

        /// <summary>
        /// Retrieves the default (or the only) connection string provided in the configuration file.
        /// </summary>
        /// <returns>The connection string.</returns>
        public IConnectionStringConfigurationElement GetDefault()
        {
            if (Count == 1)
                return this[0];

            foreach (var c in this)
            {
                var c2 = c as IConnectionStringConfigurationElement;

                if (c2 == null)
                    continue;

                if (c2.IsDefault)
                    return c2;
            }

            return null;
        }
    }
}
