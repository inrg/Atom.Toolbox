using System;
using System.Text;

namespace Atom.Toolbox
{
	/// <summary>
	/// Stores configuration values as in-memory dictionary.
	/// Names are stored without whitespace characters in a case-insensitive way.
	/// Values cannot be null.
	/// </summary>
	public class MemoryConfigReader : DictionaryConfigReader
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public MemoryConfigReader()
			: base(true)
		{
		}

		/// <summary>
		/// Normalizes name before using it as a dictionary key.
		/// </summary>
		protected virtual string ConvertName(string name)
		{
			var sb = new StringBuilder();
			foreach (var c in name)
			{
				if (Char.IsWhiteSpace(c))
					continue;

				sb.Append(c);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Adds a new property.
		/// </summary>
		public override void Add(string name, string value)
		{
			if (name == null)
				throw new ArgumentException("Property name cannot be null.");

			var norm = ConvertName(name);
			if (String.IsNullOrEmpty(norm))
				throw new ArgumentException($"Specified value '{name}' cannot be used as property name.");

			Add(name, value);
		}

		/// <summary>
		/// Gets property value by specified name.
		/// Returns null if value does not exist.
		/// </summary>
		public override string GetValue(string name)
		{
			if (name == null)
				throw new ArgumentException("Property name cannot be null.");

			var norm = ConvertName(name);
			return GetValue(norm);
		}

		/// <summary>
		/// Removes specified property.
		/// </summary>
		public override bool Remove(string name)
		{
			if (name == null)
				throw new ArgumentException("Property name cannot be null.");

			var norm = ConvertName(name);
			return Remove(norm);
		}
	}
}
