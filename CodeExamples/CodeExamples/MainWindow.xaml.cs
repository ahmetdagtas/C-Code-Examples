using CodeExamples.Models;
using CodeExamples.Serialization.XML;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeExamples
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			List<DummyModels> dummyList = new List<DummyModels>();
			for (int i = 0; i < 10; i++)
			{
				dummyList.Add(new DummyModels { id = i, name = i.ToString() });
			}
			XMLOperations.Instance.Write(dummyList);

			List<DummyModels> dummies = XMLOperations.Instance.Read(new List<DummyModels>());

			Console.WriteLine(dummyList == dummies);
		}
	}
}
