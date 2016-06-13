using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLookups.Interfaces;
using SimpleLookups.Tests.NoConfig.CustomColumns.Types;

namespace SimpleLookups.Tests.NoConfig.CustomColumns.NoTablePrefix
{
    public partial class LookupManagerTests
    {
        [TestMethod]
        public void LookupManager_Update_UpdateALookupEntity_UpdatedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var t = manager.Create(new BusinessTypeCC2()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ1818",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result =
                manager.Update(new BusinessTypeCC2()
                    {
                        Id = all[0].Id,
                        Name = "Some Other Business",
                        Description = "Some Business Description 24",
                        Code = "SOMEBIZ4546",
                        Active = false
                    });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Update_UpdateALookupEntityUsingAltConnectionName_UpdatedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var t = manager.Create(new BusinessTypeCC2()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ1818",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result =
                manager.Update(new BusinessTypeCC2()
                {
                    Id = all[0].Id,
                    Name = "Some Other Business",
                    Description = "Some Business Description 24",
                    Code = "SOMEBIZ4547",
                    Active = false
                }, "Other");

            Assert.IsTrue(result);
        }
    }
}
