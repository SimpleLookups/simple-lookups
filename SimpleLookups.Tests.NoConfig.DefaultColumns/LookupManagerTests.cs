using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleLookups.Tests.NoConfig.DefaultColumns
{
    [TestClass]
    public partial class LookupManagerTests
    {
        [TestInitialize]
        public void Init()
        {
            if (!SimpleLookups.IsInitialized)
            {
                SimpleLookups.Initialize(ConnectionStrings.Default);
                SimpleLookups.AddConnectionString("Other", ConnectionStrings.Other);
            }
        }
    }
}
