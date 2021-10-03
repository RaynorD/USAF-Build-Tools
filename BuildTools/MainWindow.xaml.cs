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
 */

namespace BuildTools
{
	public enum PboFolderState { inactive, debug, release };
	
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string appDataPath;

		public MainWindow()
		{
			InitializeComponent();

			appDataPath = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				"data.xml"
			);

			ReadData();

			

			//Directory.CreateDirectory(dirAppData);

			//ModPack modPack1 = new(@"C:\Dev\USAF\TestModPack1", "USAF Fighters");
			//ModPack modPack2 = new(@"C:\Dev\USAF\TestModPack2", "USAF Bombers");
			//PboFolder pboFolder1 = new(@"C:\Dev\USAF\TestModPack1\TestPboFolder1", PboFolderState.debug);
			//PboFolder pboFolder2 = new(@"C:\Dev\USAF\TestModPack1\TestPboFolder2", PboFolderState.inactive);
			//PboFolder pboFolder3 = new(@"C:\Dev\USAF\TestModPack2\TestPboFolder1", PboFolderState.debug);
			//PboFolder pboFolder4 = new(@"C:\Dev\USAF\TestModPack2\TestPboFolder2", PboFolderState.release);
			//modPack1.AddPboFolder(pboFolder1);
			//modPack1.AddPboFolder(pboFolder2);
			//modPack2.AddPboFolder(pboFolder3);
			//modPack2.AddPboFolder(pboFolder4);

			//SaveData saveData = new ();
			//saveData.version = new VersionData(1, 2, 3, 4);

			//saveData.AddModpack(modPack1);
			//saveData.AddModpack(modPack2);

			//WriteData(saveData);

		}

		private void ReadData()
		{

		}

		public void WriteData(SaveData saveData)
		{
			var aSerializer = new XmlSerializer(typeof(SaveData));
			StringBuilder sb = new StringBuilder();
			StringWriter sw = new StringWriter(sb);
			aSerializer.Serialize(sw, saveData); 
			string xmlResult = sw.GetStringBuilder().ToString();
			File.WriteAllText(appDataPath, xmlResult);
		}

		private void MenuItemVersion_Click(object sender, RoutedEventArgs e)
		{
			BuildVersionWindow win = new();
			win.ShowDialog();
		}

		private void MenuItemClick(object sender, RoutedEventArgs e)
		{

		}
	}

	[XmlRoot(ElementName = "SaveData")]
	public class SaveData
	{
		[XmlArray("Modpacks")]
		public List<ModPack> modPacks;
		[XmlElement("Version")]
		public VersionData version;

		public SaveData()
		{
			modPacks = new List<ModPack>();

		}
		public void AddModpack(ModPack modpack)
		{
			modPacks.Add(modpack);
		}
		public void RemoveModpack(ModPack modpack)
		{
			modPacks.Remove(modpack);
		}
	}

	public class ModPack
	{
		[XmlElement("Path")]
		public string _path;
		[XmlElement("Name")]
		public string _name;
		[XmlArray("PboFolderList")]
		[XmlArrayItem("PboFolder")]
		public List<PboFolder> _pboFolders;

		public ModPack() { }

		public ModPack(string path, string name)
		{
			_path = Directory.Exists(path) ? path : throw new DirectoryNotFoundException();

			_name = name;

			_pboFolders = new List<PboFolder>();
		}

		public void AddPboFolder(PboFolder folder)
		{
			_pboFolders.Add(folder);
		}
		public void RemovePboFolder(PboFolder folder)
		{
			_pboFolders.Remove(folder);
		}
	}


	public class PboFolder
	{
		[XmlElement("Path")]
		public string _title;
		[XmlElement("Path")]
		public string _path;
		[XmlElement("State")]
		public PboFolderState _state;

		public PboFolder() { }

		public PboFolder(string path, PboFolderState state)
		{
			_path = Directory.Exists(path) ? path : throw new DirectoryNotFoundException();

			_state = state;
		}
	}

	
	public class VersionData
	{
		[XmlElement("Major")]
		public int major;
		[XmlElement("Minor")]
		public int minor;
		[XmlElement("Patch")]
		public int patch;
		[XmlElement("Build")]
		public int build;
		
		public VersionData() { }

		public VersionData(int majorInput, int minorInput, int patchInput, int buildInput)
		{
			major = majorInput;
			minor = minorInput;
			patch = patchInput;
			build = buildInput;
		}

		public override string ToString()
		{
			return ("" + major + "." + minor + "." + patch + "." + build);
		}
	}
}
