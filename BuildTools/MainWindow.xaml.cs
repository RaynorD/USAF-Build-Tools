using System.Windows;

namespace BuildTools
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MenuItemVersion_Click(object sender, RoutedEventArgs e)
		{
			BuildVersionWindow win = new();
			win.Show();
		}
	}
}
