using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BuildTools
{
	public class ModPack
	{
		public string Name;
		public string RelativePath;
		public Project Parent;
		[XmlArrayItem("PboFolder")]
		public List<PboFolder> PboFolders;

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
