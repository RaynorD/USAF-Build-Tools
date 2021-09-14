using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BuildTools
{
	/// <summary>
	/// Interaction logic for BuildVersionWindow.xaml
	/// </summary>
	public partial class BuildVersionWindow : Window
	{
		public int versionMajor = 0;
		public int versionMinor = 0;
		public int versionBuild = 0;
		public bool autoIncrement = true;
		public BuildVersionWindow()
		{
			InitializeComponent();
		}

		private void BtnOK_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void BtnCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}
	}
}
