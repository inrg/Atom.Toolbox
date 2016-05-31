using System;

namespace Atom.Toolbox
{
	/// <summary>
	/// Implements Base64 for URL encoding.
	/// </summary>
	public static class Base64Url
	{
		/// <summary>
		/// Encodes byte array to Base64 string.
		/// </summary>
		public static string Encode(byte[] data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			var base64 = Convert.ToBase64String(data);
			return base64
				.TrimEnd('=')
				.Replace("+", "-")
				.Replace("/", "_");
		}

		/// <summary>
		/// Decodes Base64 string to byte array.
		/// </summary>
		public static byte[] Decode(string text)
		{
			if (text == null)
				throw new ArgumentNullException(nameof(text));

			var base64 = text
				.Replace("-", "+")
				.Replace("_", "/");

			switch (text.Length % 4)
			{
				case 0:
					break;
				case 2:
					base64 = base64 + "==";
					break;
				case 3:
					base64 = base64 + "=";
					break;
				default:
					throw new InvalidOperationException("Invalid Base64 string length.");
			}

			return Convert.FromBase64String(base64);
		}
	}
}
