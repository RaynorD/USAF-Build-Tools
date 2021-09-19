using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace BuildTools
{
	public enum PboFolderState { inactive, debug, release };
	
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string dirAppData;

		public MainWindow()
		{
			InitializeComponent();
			ReadData();

			dirAppData = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name
			);

			Directory.CreateDirectory(dirAppData);

			ModPack modPack1 = new(@"C:\Dev\USAF\TestModPack1", "USAF Fighters");
			ModPack modPack2 = new(@"C:\Dev\USAF\TestModPack2", "USAF Bombers");
			PboFolder pboFolder1 = new(@"C:\Dev\USAF\TestModPack1\TestPboFolder1", PboFolderState.debug);
			PboFolder pboFolder2 = new(@"C:\Dev\USAF\TestModPack1\TestPboFolder2", PboFolderState.inactive);
			PboFolder pboFolder3 = new(@"C:\Dev\USAF\TestModPack2\TestPboFolder1", PboFolderState.debug);
			PboFolder pboFolder4 = new(@"C:\Dev\USAF\TestModPack2\TestPboFolder2", PboFolderState.release);
			modPack1.AddPboFolder(pboFolder1);
			modPack1.AddPboFolder(pboFolder2);
			modPack2.AddPboFolder(pboFolder3);
			modPack2.AddPboFolder(pboFolder4);

			SaveData saveData = new SaveData();
			saveData.version[0] = 1;
			saveData.version[1] = 2;
			saveData.version[2] = 10;
			saveData.version[3] = 137;

			saveData.AddModpack(modPack1);
			saveData.AddModpack(modPack2);

			WriteData(saveData);
		}

		private void ReadData()
		{

		}

		public void WriteData(SaveData saveData)
		{
			var aSerializer = new XmlSerializer(typeof(SaveData));
			StringBuilder sb = new StringBuilder();
			StringWriter sw = new StringWriter(sb);
			aSerializer.Serialize(sw, saveData); // pass an instance of A
			string xmlResult = sw.GetStringBuilder().ToString();

			File.WriteAllText("xml.txt", xmlResult);

			//// Insert code to set properties and fields of the object.  
			//XmlSerializer mySerializer = new
			//XmlSerializer(typeof(SaveData));
			//// To write to a file, create a StreamWriter object.  
			//StreamWriter myWriter = new StreamWriter("myFileName.xml");
			//mySerializer.Serialize(myWriter, saveData);
			//myWriter.Close();
		}

		public void WriteVersionData()
		{

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
	public class ModPack
	{
		[XmlElement("Path")]
		public string _path;
		[XmlElement("Name")]
		public string _name;
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

	[XmlRoot(ElementName = "SaveData")]
	public class SaveData
	{
		[XmlArrayItem("Modpacks")]
		public List<ModPack> modPacks;
		[XmlElement("Version")]
		public int[] version;

		public SaveData()
		{
			modPacks = new List<ModPack>();
			version = new int[4];
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
}
