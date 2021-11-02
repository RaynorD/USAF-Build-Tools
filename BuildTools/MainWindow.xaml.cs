using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

/*
 * TODO: Serialize stuff 
 * 
 *	Remote: Project root
 *		.buildtools (xml text file)
 *			
 *			
 *	Local: AppData/usaf-build-tools
 *		projects.xml
 *			Last Project
 *			Project List
 *				Local Path
 *	
 *	Supported Mod structures:
 *		ACE/CBA (Single mod - need to support mod at root level)
 *			project/addons/pbos
 *			project/mod.cpp
 *		USAF (Multiple Mods)
 *			project/@USAF_Pack1
 *				/addons/pbos
 *				/mod.cpp
 *			project/@USAF_Pack2
 *				/addons/pbos
 *				/mod.cpp
 *	
 */

namespace BuildTools
{
	public partial class MainWindow : Window
	{
		private ProjectManager Manager;

		public MainWindow()
		{
			InitializeComponent();

			Manager = new();

			//ReadData();

			Manager.Save();

		}

		private void MenuItemVersion_Click(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
