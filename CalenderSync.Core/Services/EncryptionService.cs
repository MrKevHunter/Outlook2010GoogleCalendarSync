using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace CalendarSync.Core.Services
{

	/// <summary>
	/// Shamelessly cribbed from http://weblogs.asp.net/jgalloway/archive/2008/04/13/encrypting-passwords-in-a-net-app-config-file.aspx
	/// </summary>
	public class EncryptionService
	{
		private static readonly byte[] Entropy = Encoding.Unicode.GetBytes("Salt Is Not A Password");

		public static string EncryptString(SecureString input)
		{
			byte[] encryptedData = ProtectedData.Protect(
				Encoding.Unicode.GetBytes(ToInsecureString(input)),
				Entropy,
				DataProtectionScope.CurrentUser);
			return Convert.ToBase64String(encryptedData);
		}

		public static SecureString DecryptString(string encryptedData)
		{
			try
			{
				byte[] decryptedData = ProtectedData.Unprotect(
					Convert.FromBase64String(encryptedData),
					Entropy,
					DataProtectionScope.CurrentUser);
				return ToSecureString(Encoding.Unicode.GetString(decryptedData));
			}
			catch
			{
				return new SecureString();
			}
		}

		public static SecureString ToSecureString(string input)
		{
			var secure = new SecureString();
			foreach (char c in input)
			{
				secure.AppendChar(c);
			}
			secure.MakeReadOnly();
			return secure;
		}

		public static string ToInsecureString(SecureString input)
		{
			string returnValue = string.Empty;
			IntPtr ptr = Marshal.SecureStringToBSTR(input);
			try
			{
				returnValue = Marshal.PtrToStringBSTR(ptr);
			}
			finally
			{
				Marshal.ZeroFreeBSTR(ptr);
			}
			return returnValue;
		}
	}
}