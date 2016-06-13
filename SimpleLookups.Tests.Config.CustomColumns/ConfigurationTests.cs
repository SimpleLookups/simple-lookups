using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLookups.Configuration;

namespace SimpleLookups.Tests.Config.CustomColumns
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void TestLoadConfig()
        {
            var x = SimpleLookupsConfigurationSection.Instance;

            Assert.IsNotNull(x);

            var y = x.ConnectionStrings;

            Assert.IsNotNull(y);
            Assert.IsTrue(y.Count > 0);


            var numOfDefaults = 0;
            for (var i = 0; i < y.Count; i++)
            {
                if (y[i].IsDefault)
                {
                    numOfDefaults++;
                }

                Assert.IsTrue(!string.IsNullOrWhiteSpace(y[i].ConnectionStringName));
            }

            Assert.IsTrue(numOfDefaults == 1);
        }
    }
}
