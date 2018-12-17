
using System; 
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BuDing.Common.Security
{
	public class SecurityHelper
	{
		public static string MD5Hash(string input)
		{
			using(var md5 = MD5.Create())
			{
				var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
				var strResult = BitConverter.ToString(result);
				return strResult.Replace("-", "");
			}
		}
	}
}
