using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BuildTools
{
	public class ModPack
	{
		public string Name { get; set; }
		public string RelativePath { get; set; }
		public Project Parent { get; set; }
		[XmlArrayItem("PboFolder")]
		public List<PboFolder> PboFolders { get; set; }

		public ModPack() { }

		public ModPack(string path, string name)
		{
			//Path = Directory.Exists(path) ? path : throw new DirectoryNotFoundException();
			RelativePath = path;
			Name = name;

			PboFolders = new List<PboFolder>();
		}

		public void AddPboFolder(PboFolder pboFolder)
		{
			PboFolders.Add(pboFolder);
			pboFolder.Parent = this;
		}

		public void RemovePboFolder(PboFolder pboFolder)
		{
			PboFolders.Remove(pboFolder);
		}

		public string GetAbsolutePath()
		{
			return Path.Join(Parent.ProjectPath, RelativePath);
		}
	}
}
