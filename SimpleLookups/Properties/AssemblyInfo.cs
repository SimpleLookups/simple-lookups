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

using System.Reflection;
using System.Runtime.InteropServices;

#if NET200
    [assembly: AssemblyTitle("SimpleLookups for .NET 2.0")]
#elif NET300
    [assembly: AssemblyTitle("SimpleLookups for .NET 3.0")]
#elif NET350
    [assembly: AssemblyTitle("SimpleLookups for .NET 3.5")]
#elif NET400
    [assembly: AssemblyTitle("SimpleLookups for .NET 4.0")]
#elif NET401
    [assembly: AssemblyTitle("SimpleLookups for .NET 4.0.1")]
#elif NET402
    [assembly: AssemblyTitle("SimpleLookups for .NET 4.0.2")]
#elif NET403
    [assembly: AssemblyTitle("SimpleLookups for .NET 4.0.3")]
#elif NET450
    [assembly: AssemblyTitle("SimpleLookups for .NET 4.5")]
#elif NET451
    [assembly: AssemblyTitle("SimpleLookups for .NET 4.5.1")]
#elif NET452
    [assembly: AssemblyTitle("SimpleLookups for .NET 4.5.2")]
#elif NET460
    [assembly: AssemblyTitle("SimpleLookups")]    // Current Version, so no additional info given
#else
    #error Please update AssemblyInfo.cs for new .NET version.
#endif

[assembly: AssemblyDescription("Easy database type lookup and management.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SimpleLookups")]
[assembly: AssemblyCopyright("Copyright © 2013-2015 Russell Patterson")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ebb8ebb4-a92a-40dc-8457-910f64d25c75")]

[assembly: AssemblyVersion("2.0.0.0")]
[assembly: AssemblyFileVersion("2.0.0.0")]
