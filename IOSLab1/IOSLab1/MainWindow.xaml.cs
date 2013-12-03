using System;
using System.Collections.Generic;
using System.IO;
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

namespace IOSLab1
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

        private void createTest_Click(object sender, RoutedEventArgs e)
        {
            string name = testName.Text;
            string description = testDescription.Text;

            if (name.Equals(String.Empty) || description.Equals(String.Empty)) 
            {
                return;
            }

            SociologicalTest sociologicalTest = new SociologicalTest(name, description);
            CreateTest createTestWindow = new CreateTest(sociologicalTest);
            createTestWindow.ShowDialog();
        }
    }
}
