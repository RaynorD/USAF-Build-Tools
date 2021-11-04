using System.IO;

namespace BuildTools
{
	public class PboFolder
	{
		public string Title { get; set; }
		public string RelativePath { get; set; }
		public ModPack Parent { get; set; }
		public bool Dev { get; set; }
		public bool Release { get; set; }
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
