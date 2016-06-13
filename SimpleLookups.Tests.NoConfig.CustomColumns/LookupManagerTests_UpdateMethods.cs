using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLookups.Interfaces;
using SimpleLookups.Tests.NoConfig.CustomColumns.Types;

namespace SimpleLookups.Tests.NoConfig.CustomColumns
{
    public partial class LookupManagerTests
    {
        [TestMethod]
        public void LookupManager_Update_UpdateALookupEntity_UpdatedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ1818",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result =
                manager.Update(new BusinessTypeCC()
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
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ1818",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result =
                manager.Update(new BusinessTypeCC()
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
