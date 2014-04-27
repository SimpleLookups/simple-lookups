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

namespace SimpleLookups.Interfaces
{
    /// <summary>
    /// Defines the definition of a lookup value.
    /// </summary>
    public interface ILookup
    {
        /// <summary>
        /// A unique id associated with the lookup value. This is how the value should be referenced in other tables.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// The name of the lookup value.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// A brief description of the lookup value.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// A unique, user-readable string that represents this lookup.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// A boolean value indicating whether the lookup is marked active.
        /// </summary>
        bool Active { get; set; }
    }
}
