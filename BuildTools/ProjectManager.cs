using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace BuildTools
{
	public class ProjectManager
	{
		public string LastProjectPath { get; set; }
		public List<string> RecentProjectPaths { get; set; }
		public Project CurrentProject { get; set; }
		public string AppDataXmlPath { get; set; }

		public ProjectManager()
		{
			AppDataXmlPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				"data.xml"
			);

			CurrentProject = Project.GetTestProject();

			SaveProject();
		}
		public void SaveProject()
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
				CurrentProject.AutoIncrement = win.AutoIncrement;
			}
			else
			{
				Debug.WriteLine("Do not change version");
			}
		}
	}
}
