using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLookups.Interfaces;
using SimpleLookups.Tests.Config.CustomColumns.Types;

namespace SimpleLookups.Tests.Config.CustomColumns.NoTablePrefix
{
    public partial class LookupManagerTests
    {
        [TestMethod]
        public void LookupManager_Get_SelectALookupEntityById_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all[0].Id);

            Assert.IsTrue(result.Id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Name));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Description));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Code));
        }

        [TestMethod]
        public void LookupManager_Get_SelectALookupEntityByIdUsingAltConnectionName_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all[0].Id, "Other");

            Assert.IsTrue(result.Id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Name));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Description));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Code));
        }

        [TestMethod]
        public void LookupManager_Get_SelectLookupEntitiesByIds_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all.Select(o => o.Id).ToList());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
                Assert.IsTrue(r.Active);
            }
        }

        [TestMethod]
        public void LookupManager_Get_SelectLookupEntitiesByIdsUsingAltConnectionName_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all.Select(o => o.Id).ToList(), "Other");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
                Assert.IsTrue(r.Active);
            }
        }

        [TestMethod]
        public void LookupManager_Get_SelectAllLookups_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var result = manager.Get(false);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
            }
        }

        [TestMethod]
        public void LookupManager_Get_SelectAllLookupsUsingAltConnectionName_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var result = manager.Get(false, "Other");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
            }
        }

        [TestMethod]
        public void LookupManager_Get_SelectAllActiveLookups_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var result = manager.Get(true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
                Assert.IsTrue(r.Active);
            }
        }

        [TestMethod]
        public void LookupManager_Get_SelectAllActiveLookupsUsingAltConnectionName_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var result = manager.Get(true, "Other");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
                Assert.IsTrue(r.Active);
            }
        }

        [TestMethod]
        public void LookupManager_Get_SelectALookupEntityByCode_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all[0].Code);

            Assert.IsTrue(result.Id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Name));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Description));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Code));
        }

        [TestMethod]
        public void LookupManager_Get_SelectALookupEntityByCodeUsingAltConnectionName_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all[0].Code, "Other");

            Assert.IsTrue(result.Id > 0);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Name));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Description));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.Code));
        }

        [TestMethod]
        public void LookupManager_Get_SelectLookupEntitiesByCodes_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all.Select(o => o.Code).ToList());

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
                Assert.IsTrue(r.Active);
            }
        }

        [TestMethod]
        public void LookupManager_Get_SelectLookupEntitiesByCodesUsingAltConnectionName_RetrievedSuccessfully()
        {
            ILookupManager<BusinessTypeCC2> manager = new BusinessTypeCC2Manager();

            var all = manager.Get(true);
            var result = manager.Get(all.Select(o => o.Code).ToList(), "Other");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

            foreach (var r in result)
            {
                Assert.IsTrue(r.Id > 0);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Name));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Description));
                Assert.IsTrue(!string.IsNullOrWhiteSpace(r.Code));
                Assert.IsTrue(r.Active);
            }
        }
    }
}
