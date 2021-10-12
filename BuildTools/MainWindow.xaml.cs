using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

/*
 *	Remote: Project root
 *		.buildtools (xml text file)
 *			
 *			
 *	Local: AppData/usaf-build-tools
 *		projects.xml
 *			Last Project
 *			Project List
 *				Local Path
 *	
 *	Supported Mod structures:
 *		ACE/CBA (Single mod - need to support mod at root level)
 *			project/addons/pbos
 *			project/mod.cpp
 *		USAF (Multiple Mods)
 *			project/@USAF_Pack1
 *				/addons/pbos
 *				/mod.cpp
 *			project/@USAF_Pack2
 *				/addons/pbos
 *				/mod.cpp
 *	
 */

namespace BuildTools
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string appDataXmlPath;
		private Project project;

		public MainWindow()
		{
			InitializeComponent();

			appDataXmlPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				"data.xml"
			);

			//ReadData();

			project = new();

			_ = Directory.CreateDirectory(appDataXmlPath);

			ModPack modPack1 = new(@"@USAF_Fighters", "USAF Fighters");
			ModPack modPack2 = new(@"@USAF_Utility", "USAF Utility");

			PboFolder pboFolder1 = new(@"@USAF_Fighters\addons\USAF_F22", "F-22", true, true);
			PboFolder pboFolder2 = new(@"@USAF_Fighters\addons\USAF_F35A", "F-35A", true, false);
			PboFolder pboFolder3 = new(@"@USAF_Utility\addons\USAF_MQ9", "B-1B", false, true);
			PboFolder pboFolder4 = new(@"@USAF_Utility\addons\USAF_RQ4", "B-2", false, false);
			modPack1.PboFolders.Add(pboFolder1);
			modPack1.PboFolders.Add(pboFolder2);
			modPack2.PboFolders.Add(pboFolder3);
			modPack2.PboFolders.Add(pboFolder4);

			project.Version = new VersionData(1, 2, 3, 4);

			project.ModPacks.Add(modPack1);
			project.ModPacks.Add(modPack2);

			WriteSaveData(project);

		}

		//private void ReadData()
		//{

		//}

		public void LoadProject()
		{
			ClearProject();
		}

		public void ClearProject()
		{
			if(project != null)
			{
				project = null;
			}
		}

		public void WriteSaveData(Project proj)
		{
			XmlSerializer aSerializer = new(typeof(Project));
			StringBuilder sb = new();
			StringWriter sw = new(sb);
			aSerializer.Serialize(sw, proj);
			string xmlResult = sw.GetStringBuilder().ToString();
			File.WriteAllText(Path.Join(proj.Path,".buildtools.xml"), xmlResult);
		}

		private void MenuItemVersion_Click(object sender, RoutedEventArgs e)
		{
			BuildVersionWindow win = new(project.Version);
			if ((bool)win.ShowDialog())
			{

			}
			

		}

		private void MenuItemClick(object sender, RoutedEventArgs e)
		{

		}
	}

	[XmlRoot(ElementName = "SaveData")]
	public class Project
	{
		public string Name;
		public string Path;
		public List<ModPack> ModPacks;
		public VersionData Version;

		public Project()
		{
			Name = "";
			Path = "";
			ModPacks = new();
			Version = new();
		}
		public Project(string name, string path)
		{
			Name = name;
			Path = path;
			ModPacks = new();
			Version = new();
		}
	}

	public class LocalSaveData
	{
		public string Path;
	}

	public class ModPack
	{
		public string Name;
		public string Path;
		[XmlArrayItem("PboFolder")]
		public List<PboFolder> PboFolders;

		public ModPack() { }

		public ModPack(string path, string name)
		{
			//Path = Directory.Exists(path) ? path : throw new DirectoryNotFoundException();

			Path = path;
			Name = name;

			PboFolders = new List<PboFolder>();
		}
	}


	public class PboFolder
	{
		public string Title;
		public string Path;
		public bool Dev;
		public bool Release;

		public PboFolder() {
			Path = "";
			Title = "";
			Dev = false;
			Release = false;
		}

		public PboFolder(string path, string title)
		{
			Path = Directory.Exists(path) ? path : throw new DirectoryNotFoundException();
			Title = title;
			Dev = false;
			Release = false;
		}

		public PboFolder(string path, string title, bool dev, bool release)
		{
			Path = Directory.Exists(path) ? path : throw new DirectoryNotFoundException();
			Title = title;
			Dev = dev;
			Release = release;
		}
	}
	
	public class VersionData
	{
		public int Major;
		public int Minor;
		public int Patch;
		public int Build;
		public bool AutoIncrement;
		
		public VersionData() {
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
