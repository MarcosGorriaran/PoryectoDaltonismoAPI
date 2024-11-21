using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace KillerRobot_Api.Utils
{
    public static class Hasher
    {
        /// <summary>
        /// This method hashes a byte array using the SHA256 algorythm
        /// </summary>
        /// <param name="data">The array of bytes of data to be hashed</param>
        /// <returns>The hashed data from the parameter data as another byte array</returns>
        public static byte[] SHA256Hashing(byte[] data)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                return hasher.ComputeHash(data);
            }
        }
        /// <summary>
        /// This method hashes a string of data and returns a string containing the Hex result of the hash
        /// </summary>
        /// <param name="dataString">The text to be hashed</param>
        /// <returns>A string containing a hexadecimal number of the hashed text</returns>
        public static string SHA256Hashing(string dataString)
        {
            byte[] hashedData = SHA256Hashing(System.Text.Encoding.UTF8.GetBytes(dataString));
            return ByteToHex(hashedData);
        }
        /// <summary>
        /// Will transform bytes of data into hexadecimal format
        /// </summary>
        /// <param name="bytes">The bytes of data to be transformed</param>
        /// <returns>The string containing the hexadecimal equivalent of the bytes that have been provided on data</returns>
        public static string ByteToHex(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder();
            foreach (byte b in bytes)
            {
                hex.Append(b.ToString("x2"));
            }
            return hex.ToString();
        }
    }
}