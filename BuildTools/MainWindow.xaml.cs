using System;
using System.IO;
using System.Windows;
using System.Xml;

namespace BuildTools
{
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
		}

		private void ReadData()
		{
			
		}

		public void WriteData()
		{
			XmlDocument xml = new XmlDocument();
			xml.
		}

		public void WriteVersionData()
		{

		}

		private void MenuItemVersion_Click(object sender, RoutedEventArgs e)
		{
			BuildVersionWindow win = new();
			win.ShowDialog();
		}
	}
}
