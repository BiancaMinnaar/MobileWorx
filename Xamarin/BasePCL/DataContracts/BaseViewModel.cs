using System;
using System.Text;
using Xamarin.Forms;

namespace CorePCL
{
    public class BaseViewModel
    {
		public string Encrypt(string toEncrypt)
		{
            if (toEncrypt != null)
            {
                var crypto = DependencyService.Get<ICrypto>();
                var cryptoString = crypto.GetCryptoString(toEncrypt);
                return cryptoString;
            }
            else
            {
                return "";
            }

            //byte[] keyArray;
            //byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

			//string key = "M3asur3Pr0Secur1tyK3y";
			//MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
			//keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			//hashmd5.Clear();

			//TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
			//tdes.Key = keyArray;
			//tdes.Mode = CipherMode.ECB;
			//tdes.Padding = PaddingMode.PKCS7;

			//ICryptoTransform cTransform = tdes.CreateEncryptor();
			//byte[] resultArray = cTransform.TransformFinalBlock
			//		(toEncryptArray, 0, toEncryptArray.Length);
			//tdes.Clear();

			//return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}
    }
}
