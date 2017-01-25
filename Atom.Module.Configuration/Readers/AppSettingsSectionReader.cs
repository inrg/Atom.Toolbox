using System;
using System.Configuration;

namespace Atom.Toolbox
{
	/// <summary>
	/// Reads configuration values from the specified instance of appSettings configuration section.
	/// This may be useful when the section was obtained manually (e.g. when reading a
	/// </summary>
	public class AppSettingsSectionReader : IConfigReader
	{
		private readonly AppSettingsSection m_section;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public AppSettingsSectionReader(AppSettingsSection section)
		{
			if (section == null)
				throw new ArgumentNullException(nameof(section));

			m_section = section;
		}

		/// <summary>
		/// Gets configuration value by specified name.
		/// Returns null if value does not exist.
		/// </summary>
		public virtual string GetValue(string name)
		{
			try
			{
				return m_section.Settings[name].Value;
			}
			catch
			{
				return null;
			}
		}
	}
}
