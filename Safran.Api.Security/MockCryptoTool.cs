using System.Text;

namespace Safran.Api.Security
{
    public class MockCryptoTool:ICryptoTool
    {
        public byte[] Cypher(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        public string Decypher(byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }
    }
}
