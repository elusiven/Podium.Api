using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Podium.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        public BaseTest()
        {
        }

        [TestInitialize]
        private void Init()
        {
        }
    }
}