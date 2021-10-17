using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildTools
{
	public class ProjectManager
	{
		public string lastProjectPath;
		public List<string> recentProjectPaths;
		public Project currentProject;

		public ProjectManager()
		{
			
		}
	}
}
