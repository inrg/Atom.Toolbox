namespace Atom.Toolbox
{
	/// <summary>
	/// Common interface for reading configuration values as strings.
	/// </summary>
	public interface IConfigReader
	{
		/// <summary>
		/// Gets configuration value by specified name.
		/// Should return null if value does not exist.
		/// </summary>
		string GetValue(string name);
	}
}
