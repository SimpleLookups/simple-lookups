using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleLookups.Tests.NoConfig.CustomColumns.NoTablePrefix
{
    [TestClass]
    public partial class LookupManagerTests
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
    }
}
