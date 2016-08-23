using System;
using System.Configuration;
using Newtonsoft.Json;

namespace Atom.Toolbox
{
	/// <summary>
	/// Parses configuration values.
	/// </summary>
	public static class ConfigParserJson
	{
		/// <summary>
		/// Gets configuration value of specified type, assuming its value serialized using JSON.
		/// Returns default value if specified value is not set.
		/// </summary>
		public static T GetJson<T>(this IConfigReader reader, string name, T defaultValue)
		{
			var value = reader.GetValue(name);
			if (value == null)
				return defaultValue;

			return ParseJson<T>(name, value);
		}

		/// <summary>
		/// Gets configuration value of specified type, assuming its value serialized using JSON.
		/// Throws exception if specified value is not set.
		/// </summary>
		public static T GetJson<T>(this IConfigReader reader, string name)
		{
			var value = reader.GetValue(name);
			if (value == null)
			{
				string message = $"Configuration parameter '{name}' is not found.";
				throw new ConfigurationErrorsException(message);
			}

			return ParseJson<T>(name, value);
		}

		/// <summary>
		/// Parses configuration value of specified type, assuming its value serialized using JSON.
		/// </summary>
		private static T ParseJson<T>(string name, string value)
		{
			if (value == null)
				throw new ArgumentNullException(nameof(value));

			try
			{
				return JsonConvert.DeserializeObject<T>(value);
			}
			catch
			{
				throw new ConfigurationErrorsException(
					$"Configuration parameter '{name}' should contain JSON value of type {typeof(T).Name}.");
			}
		}
	}
}
