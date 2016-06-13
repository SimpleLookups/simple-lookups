using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleLookups.Tests.NoConfig.CustomColumns
{
    [TestClass]
    public partial class LookupManagerTests
    {
        [TestInitialize]
        public void Init()
        {
            if (!SimpleLookups.IsInitialized)
            {
                SimpleLookups.Initialize(ConnectionStrings.Default, "Id2", "Name2", "Description2", "Code2", "Active2", true, true, 1800);
                SimpleLookups.AddConnectionString("Other", ConnectionStrings.Other);
            }
        }
    }
}
