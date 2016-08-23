using System.Configuration;

namespace Atom.Toolbox
{
	/// <summary>
	/// Parses configuration values.
	/// </summary>
	public static partial class ConfigParser
	{
		/// <summary>
		/// Checks whether specified configuration value is null or absent.
		/// </summary>
		public static bool IsNull(this IConfigReader reader, string name)
		{
			var value = reader.GetValue(name);
			return value == null;
		}

		/// <summary>
		/// Gets configuration value of specified type.
		/// Returns default value if specified value is not set.
		/// </summary>
		public static T Get<T>(this IConfigReader reader, string name, T defaultValue)
		{
			var value = reader.GetValue(name);
			if (value == null)
				return defaultValue;

			return Parse<T>(name, value);
		}

		/// <summary>
		/// Gets configuration value of specified type.
		/// Throws exception if specified value is not set.
		/// </summary>
		public static T Get<T>(this IConfigReader reader, string name)
		{
			var value = reader.GetValue(name);
			if (value == null)
			{
				string message = $"Configuration parameter '{name}' is not found.";
				throw new ConfigurationErrorsException(message);
			}

			return Parse<T>(name, value);
		}
	}
}
