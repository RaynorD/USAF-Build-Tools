using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildTools
{
	public class PboFolder
	{
		public string Title;
		public string RelativePath;
		public ModPack Parent;
		public bool Dev;
		public bool Release;
		public PboFolder()
		{
			RelativePath = "";
			Title = "";
			Dev = false;
			Release = false;
		}

		public PboFolder(string path, string title)
		{
			RelativePath = path;
			Title = title;
			Dev = false;
			Release = false;
		}

		public PboFolder(string path, string title, bool dev, bool release)
		{
			RelativePath = path;
			Title = title;
			Dev = dev;
			Release = release;
		}

		public string GetAbsolutePath()
		{
			return Path.Join(Parent.Parent.ProjectPath, Parent.RelativePath, RelativePath);
		}
	}
}
