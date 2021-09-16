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
		private int versionMajor, versionMinor, versionBuild;
		private bool autoIncrement = true;

		public BuildVersionWindow()
		{
			InitializeComponent();
		}

		#region Helper Functions
		private void ValidateVersionField(object sender, ref TextCompositionEventArgs e)
		{
			TextBox txtBox = sender as TextBox;
			e.Handled = int.TryParse(txtBox.Text, out _);
		}
		private void EditVersionField(TextBox txtBox, bool inc)
		{
			if (int.TryParse(txtBox.Text, out int curVal))
			{
				if (inc)
				{
					txtBox.Text = (curVal + 1).ToString();
				}
				else
				{
					txtBox.Text = (curVal - 1).ToString();
				}
			}
		}
		#endregion

		#region Events
		private void BtnOK_Click(object sender, RoutedEventArgs e)
		{
			int.TryParse(txtBox_version_major.Text, out versionMajor);
			int.TryParse(txtBox_version_minor.Text, out versionMinor);
			int.TryParse(txtBox_version_build.Text, out versionBuild);

			autoIncrement = (bool)checkbox_autoIncrement.IsChecked;

			DialogResult = true;
		}

		private void BtnCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}

		private void TxtBox_version_major_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			//ValidateVersionField(sender, ref e);
		}

		private void TxtBox_version_minor_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			//ValidateVersionField(sender, ref e);
		}

		private void TxtBox_version_build_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			//ValidateVersionField(sender, ref e);
		}
		private void Btn_VersionMajor_Decrement_Click(object sender, RoutedEventArgs e)
		{
			EditVersionField(txtBox_version_major, false);
		}

		private void Btn_VersionMajor_Increment_Click(object sender, RoutedEventArgs e)
		{
			EditVersionField(txtBox_version_major, true);
		}

		private void Btn_VersionMinor_Decrement_Click(object sender, RoutedEventArgs e)
		{
			EditVersionField(txtBox_version_minor, false);
		}

		private void Btn_VersionMinor_Increment_Click(object sender, RoutedEventArgs e)
		{
			EditVersionField(txtBox_version_minor, true);
		}

		private void Btn_VersionBuild_Decrement_Click(object sender, RoutedEventArgs e)
		{
			EditVersionField(txtBox_version_build, false);
		}

		private void Btn_VersionBuild_Increment_Click(object sender, RoutedEventArgs e)
		{
			EditVersionField(txtBox_version_build, true);
		}
		#endregion


	}
}
