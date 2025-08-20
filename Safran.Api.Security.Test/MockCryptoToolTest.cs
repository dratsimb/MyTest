namespace Safran.Api.Security.Test
{
    [TestClass]
    public sealed class MockCryptoToolTest
    {
        static readonly ICryptoTool tool = new MockCryptoTool();

        [TestMethod]
        public void TestCypher()
        {
            var notExpected = Guid.NewGuid().ToString();

            var actual = tool.Cypher("a");
            Assert.IsNotNull(actual, "the cyphered value should not be null");


        }

        [TestMethod]
        public void TestCypherDeCypher()
        {
            var expected = Guid.NewGuid().ToString();
            var tmp = tool.Cypher(expected);
            var actual = tool.Decypher(tmp);
            Assert.AreEqual(expected, actual, "the cyphered value should have been decyphered back to the initial value");
        }
    }
}
