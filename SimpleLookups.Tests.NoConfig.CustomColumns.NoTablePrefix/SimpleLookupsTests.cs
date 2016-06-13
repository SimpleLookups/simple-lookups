using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimpleLookups.Tests.NoConfig.CustomColumns.NoTablePrefix;

namespace SimpleLookups.Tests.NoConfig.CustomColumns.NoTablePrefix
{ 
    [TestClass]
    public class SimpleLookupsTests
    {
        [TestInitialize]
        public void Init()
        {
            if (!SimpleLookups.IsInitialized)
            {
                SimpleLookups.Initialize(ConnectionStrings.Default, "Id4", "Name4", "Description4", "Code4", "Active4", false, true, 1800);
                SimpleLookups.AddConnectionString("Other", ConnectionStrings.Other);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SimpleLookups_Initialize_AlreadyInitializedTryToInitializeAgain_ThrowsInvalidOperationException()
        {
            SimpleLookups.Initialize(ConnectionStrings.Default);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SimpleLookups_Initialize_ProvideNullConnectionString_ThrowsInvalidOperationException()
        {
            SimpleLookups.Initialize(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SimpleLookups_Initialize_ProvideBlankConnectionString_ThrowsInvalidOperationException()
        {
            SimpleLookups.Initialize("");

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SimpleLookups_Initialize_ProvideWhitespaceConnectionString_ThrowsInvalidOperationException()
        {
            SimpleLookups.Initialize("         ");

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SimpleLookups_AddConnectionString_ProvideNullConnectionName_ThrowsArgumentException()
        {
            SimpleLookups.AddConnectionString(null, "this is a test");

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SimpleLookups_AddConnectionString_ProvideEmptyConnectionName_ThrowsArgumentException()
        {
            SimpleLookups.AddConnectionString("", "this is a test");

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SimpleLookups_AddConnectionString_ProvideWhitespaceConnectionName_ThrowsArgumentException()
        {
            SimpleLookups.AddConnectionString("      ", "this is a test");

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SimpleLookups_AddConnectionString_ProvideNullConnectionString_ThrowsArgumentException()
        {
            SimpleLookups.AddConnectionString("TestConnString", null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SimpleLookups_AddConnectionString_ProvideEmptyConnectionString_ThrowsArgumentException()
        {
            SimpleLookups.AddConnectionString("TestConnString", "");

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SimpleLookups_AddConnectionString_ProvideWhitespaceConnectionString_ThrowsArgumentException()
        {
            SimpleLookups.AddConnectionString("TestConnString", "        ");

            Assert.Fail();
        }
    }
}
