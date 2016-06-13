using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLookups.Exceptions;
using SimpleLookups.Interfaces;
using SimpleLookups.Tests.NoConfig.DefaultColumns.Types;

namespace SimpleLookups.Tests.NoConfig.DefaultColumns
{
    public partial class LookupManagerTests
    {
        [TestMethod]
        public void LookupManager_Create_CreateALookupEntity_CreatedSuccessfully()
        {
            ILookupManager<BusinessType> manager = new BusinessTypeManager();

            var id =
                manager.Create(new BusinessType()
                    {
                        Name = "Some Business",
                        Description = "Some Business Description",
                        Code = "SOMEBIZ",
                        Active = true
                    });

            Assert.IsTrue(id);
        }

        [TestMethod]
        public void LookupManager_Create_CreateALookupEntityUsingAltConnectionStringName_CreatedSuccessfully()
        {
            ILookupManager<BusinessType> manager = new BusinessTypeManager();

            var id =
                manager.Create(new BusinessType()
                {
                    Name = "Some Business",
                    Description = "Some Business Description",
                    Code = "SOMEBIZ",
                    Active = true
                }, "Other");

            Assert.IsTrue(id);
        }

        [TestMethod]
        [ExpectedException(typeof(SimpleLookupsException), "Error occurred during Create operation.")]
        public void LookupManager_Create_CreateALookupEntityWithNullEntity_ThrowsException()
        {
            ILookupManager<BusinessType> manager = new BusinessTypeManager();

            var id = manager.Create(null);

            Assert.Fail("Should have thrown exception!");
        }

        [TestMethod]
        [ExpectedException(typeof(SimpleLookupsException), "Error occurred during Create operation.")]
        public void LookupManager_Create_CreateALookupEntityUsingInvalidConnectionStringName_ThrowsException()
        {
            ILookupManager<BusinessType> manager = new BusinessTypeManager();

            var id =
                manager.Create(new BusinessType()
                {
                    Name = "Some Business",
                    Description = "Some Business Description",
                    Code = "SOMEBIZ",
                    Active = true
                }, "SomeInvalidName");

            Assert.Fail("Should have thrown exception!");
        }
    }
}
