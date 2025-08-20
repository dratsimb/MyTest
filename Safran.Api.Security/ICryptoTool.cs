namespace Safran.Api.Security
{
    /// <summary>
    /// This interface defines the methods required to safely cypher / decypher a string value
    /// </summary>
    public interface ICryptoTool
    {
        /// <summary>
        /// Cyphers the input value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        byte[] Cypher(string value);

        /// <summary>
        /// Decypher the input value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Decypher(byte[] value);
    }
}
