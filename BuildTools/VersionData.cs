using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildTools
{
	public class VersionData
	{
		public int Major;
		public int Minor;
		public int Patch;
		public int Build;
		public bool AutoIncrement;

		public VersionData()
		{
			Major = 0;
			Minor = 0;
			Patch = 0;
			Build = 0;
			AutoIncrement = false;
		}

		public VersionData(int majorInput, int minorInput, int patchInput, int buildInput)
		{
			Major = majorInput;
			Minor = minorInput;
			Patch = patchInput;
			Build = buildInput;
			AutoIncrement = false;
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
	}
}
