namespace Safran.Api.Security.Test
{
    [TestClass]
    public sealed class AesCryptoToolTest
    {
        static readonly AesCryptoTool tool = new ("Qm9uan91ciBsZSBtb25kZSAh");

        [TestMethod]
        public void TestCypher()
        {
            var notExpected = Guid.NewGuid().ToString();

            var actual = tool.Cypher("a");
            Assert.IsNotNull(actual, "the cyphered value should not be null");
            Assert.IsTrue(actual.Count() > 16, "the cyphered value should not be empty or only of the length of the IV");

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
