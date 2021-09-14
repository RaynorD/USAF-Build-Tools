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
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;

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

		private double versionMajorScrollValue = 0;
		private double versionMinorScrollValue = 0;
		private double versionBuildScrollValue = 0;

		private static readonly Regex _regex = new("[0-9]");

		public BuildVersionWindow()
		{
			InitializeComponent();
		}

		#region Helper Functions
		private void ValidateVersionField(object sender, ref TextCompositionEventArgs e)
		{
			e.Handled = !_regex.IsMatch(e.Text);
		}

		private void HandleScrollBar(ref object sender, ref ScrollEventArgs e, ref double value, ref TextBox txtBox)
		{
			if (e.NewValue > value)
			{
				txtBox.Text = txtBox.Text + 1;
			}
			else
			{

			}
			Console.WriteLine(e.NewValue);
			Console.WriteLine(value);
		}
		#endregion

		#region Events
		private void BtnOK_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void BtnCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}

		private void TxtBox_version_major_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			ValidateVersionField(sender, ref e);
		}

		private void TxtBox_version_minor_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			ValidateVersionField(sender, ref e);
		}

		private void TxtBox_version_build_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			ValidateVersionField(sender, ref e);
		}

		private void ScrollBar_Major_Scroll(object sender, ScrollEventArgs e)
		{
			HandleScrollBar(ref sender, ref e, ref versionMajorScrollValue, ref txtBox_version_build);
		}
		#endregion
	}
}
