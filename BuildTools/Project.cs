using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BuildTools
{
	[XmlRoot(ElementName = "SaveData")]
	public class Project
	{
		public string Name;
		public string ProjectPath;
		public List<ModPack> ModPacks;
		public VersionData Version;
		public bool AutoIncrement;

		public Project()
		{
			Name = "";
			ProjectPath = "";
			ModPacks = new();
			Version = new();
			AutoIncrement = false;
		}
		public Project(string name, string path)
		{
			Name = name;
			ProjectPath = path;
			ModPacks = new();
			Version = new();
			AutoIncrement = false;
		}
		public void AddModpack(ModPack modPack)
		{
			ModPacks.Add(modPack);
			modPack.Parent = this;
		}

		public void RemoveModPack(ModPack modPack)
		{
			_ = ModPacks.Remove(modPack);
		}

		public void Save(string path)
		{
			XmlSerializer aSerializer = new(typeof(Project));
			StringBuilder sb = new();
			StringWriter sw = new(sb);
			aSerializer.Serialize(sw, this);
			string xml = sw.GetStringBuilder().ToString();
			File.WriteAllText(Path.Join(ProjectPath, ".buildtools.xml"), xml);
		}

		public static Project GetTestProject()
		{
			Project project = new("USAF", @"C:\Dev\USAFBuildTest");

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

			project.ModPacks.Add(modPack1);
			project.ModPacks.Add(modPack2);

			project.Version = new VersionData(1, 2, 3, 4);

			return project;
		}
	}
}
