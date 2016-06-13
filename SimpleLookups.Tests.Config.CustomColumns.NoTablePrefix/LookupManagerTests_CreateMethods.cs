using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLookups.Exceptions;
using SimpleLookups.Interfaces;
using SimpleLookups.Tests.Config.CustomColumns.Types;

namespace SimpleLookups.Tests.Config.CustomColumns.NoTablePrefix
{
    public partial class LookupManagerTests
    {
        [TestMethod]
        public void LookupManager_Create_CreateALookupEntity_CreatedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var id =
                manager.Create(new BusinessTypeCC2()
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
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var id =
                manager.Create(new BusinessTypeCC2()
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
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var id = manager.Create(null);

            Assert.Fail("Should have thrown exception!");
        }

        [TestMethod]
        [ExpectedException(typeof(SimpleLookupsException), "Error occurred during Create operation.")]
        public void LookupManager_Create_CreateALookupEntityUsingInvalidConnectionStringName_ThrowsException()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var id =
                manager.Create(new BusinessTypeCC2()
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
