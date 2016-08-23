using System;
using System.Collections.Generic;
using System.Linq;

namespace Atom.Toolbox
{
	/// <summary>
	/// Stores configuration values as in-memory dictionary.
	/// Can optionally use case-insensitive names, but doesn't perform any name normalization (see MemoryConfigReader for that feature).
	/// Values cannot be null.
	/// </summary>
	public class DictionaryConfigReader : IConfigReader
	{
		private readonly Dictionary<string, string> m_values;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public DictionaryConfigReader()
		{
			m_values = new Dictionary<string, string>();
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public DictionaryConfigReader(bool ignoreCase)
		{
			m_values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Gets all property names.
		/// </summary>
		public List<string> Names => m_values.Keys.ToList();

		/// <summary>
		/// Adds a new property.
		/// </summary>
		public virtual void Add(string name, string value)
		{
			if (name == null)
				throw new ArgumentException("Property name cannot be null.");

			if (value == null)
				throw new ArgumentException("Property value cannot be null.");

			if (m_values.ContainsKey(name))
				throw new InvalidOperationException($"Another value was already specified for property name '{name}'.");

			m_values.Add(name, value);
		}

		/// <summary>
		/// Gets property value by specified name.
		/// Returns null if value does not exist.
		/// </summary>
		public virtual string GetValue(string name)
		{
			if (name == null)
				throw new ArgumentException("Property name cannot be null.");

			if (!m_values.ContainsKey(name))
				return null;

			return m_values[name];
		}

		/// <summary>
		/// Removes specified property.
		/// </summary>
		public virtual bool Remove(string name)
		{
			if (name == null)
				throw new ArgumentException("Property name cannot be null.");

			return m_values.Remove(name);
		}

		/// <summary>
		/// Removes all properties.
		/// </summary>
		public void Clear()
		{
			m_values.Clear();
		}
	}
}
