using System.Text;
using System.Security.Cryptography;

namespace Bike_Rental
{
	public static class Encryptor
	{
		public static string MD5Hash(string password)
		{
			MD5 md5 = new MD5CryptoServiceProvider();

			//Colpmute hash from the bytes of the text
			md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

			//get hash result after computing it
			byte[] result = md5.Hash;

			StringBuilder hash = new StringBuilder();
			for (int i = 0; i < result.Length; i++)
			{
				//Change it into 2 hexadecimal digits for each byte
				hash.Append(result[i].ToString("x2"));
			}

			return hash.ToString();
		}
	}
}
