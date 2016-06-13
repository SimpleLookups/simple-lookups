using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLookups.Interfaces;
using SimpleLookups.Tests.Config.CustomColumns.Types;
using System.Collections.Generic;
using System.Linq;

namespace SimpleLookups.Tests.Config.CustomColumns
{
    public partial class LookupManagerTests
    {
        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityById_DeletedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ1919",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result = manager.Delete(all[0].Id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByInvalidId_ReturnsFalse()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();
            
            var result = manager.Delete(-495);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByIdUsingAltConnectionName_DeletedSuccessfully()
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

            var result = manager.Delete(all[0].Id, "Other");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByIds_DeletedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
                {
                    Name = "Some Business",
                    Description = "Some Business Description",
                    Code = "SOMEBIZ1717",
                    Active = true
                });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result = manager.Delete(all.Select(d => d.Id).Take(1).ToList());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByIdsUsingAltConnectionName_DeletedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ1616",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result = manager.Delete(all.Select(d => d.Id).Take(1).ToList(), "Other");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByCode_DeletedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ5454",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result = manager.Delete("SOMEBIZ5454");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByCodeUsingAltConnectionName_DeletedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ9898",
                Active = true
            });

            Assert.IsTrue(t);
            var all = manager.Get(false);

            var result = manager.Delete("SOMEBIZ9898", "Other");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByCodes_DeletedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ2424",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result = manager.Delete(new List<string>() { "SOMEBIZ2424" });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LookupManager_Delete_DeleteALookupEntityByCodesUsingAltConnectionName_DeletedSuccessfully()
        {
            ILookupManager<BusinessTypeCC> manager = new BusinessTypeManager();

            var t = manager.Create(new BusinessTypeCC()
            {
                Name = "Some Business",
                Description = "Some Business Description",
                Code = "SOMEBIZ757",
                Active = true
            });

            Assert.IsTrue(t);

            var all = manager.Get(false);

            var result = manager.Delete(new List<string>() { "SOMEBIZ757" }, "Other");

            Assert.IsTrue(result);
        }
    }
}
