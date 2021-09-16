using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildTools
{
	class UserData
	{
		public bool autoIncrementBuildVersion { get; set; }
		public int versionMajor { get; set; }
		public int versionMinor { get; set; }
		public int versionBuild { get; set; }

		List<string> packs { get; set; }
	}
}
