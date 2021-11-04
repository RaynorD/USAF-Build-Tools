
namespace BuildTools
{
	public class VersionData
	{
		public int Major { get; set; }
		public int Minor { get; set; }
		public int Patch { get; set; }
		public int Build { get; set; }
		public bool AutoIncrement { get; set; }

		public VersionData()
		{
			Major = 0;
			Minor = 0;
			Patch = 0;
			Build = 0;
			AutoIncrement = true;
		}

		public VersionData(int majorInput, int minorInput, int patchInput, int buildInput)
		{
			Major = majorInput;
			Minor = minorInput;
			Patch = patchInput;
			Build = buildInput;
			AutoIncrement = true;
		}

		public VersionData(int majorInput, int minorInput, int patchInput, int buildInput, bool autoIncrement)
		{
			Major = majorInput;
			Minor = minorInput;
			Patch = patchInput;
			Build = buildInput;
			AutoIncrement = autoIncrement;
		}

		public override string ToString()
		{
			return "" + Major + "." + Minor + "." + Patch + "." + Build;
		}

		public void IncrementBuildNumber()
		{
			if (AutoIncrement)
			{
				++Build;
			}
		}
	}
}
