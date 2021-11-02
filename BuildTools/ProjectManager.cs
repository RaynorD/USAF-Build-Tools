using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildTools
{
	public class ProjectManager
	{
		public string LastProjectPath;
		public List<string> RecentProjectPaths;
		public Project CurrentProject;
		string AppDataXmlPath;

		public ProjectManager()
		{
			AppDataXmlPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				"data.xml"
			);
		}
		public void Save()
		{
			CurrentProject.Save(AppDataXmlPath);
		}

		public void ChangeVersion()
		{
			BuildVersionWindow win = new(CurrentProject.Version);

			bool result = (bool)win.ShowDialog();
			if (result)
			{
				Debug.WriteLine("Change version");
				CurrentProject.Version = win.OutputVersion;
				Project.AutoIncrement = win.AutoIncrement;
			}
			else
			{
				Debug.WriteLine("Do not change version");
			}
		}
	}
}
