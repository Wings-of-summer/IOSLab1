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
using System.Windows.Shapes;

namespace IOSLab1
{
    /// <summary>
    /// Interaction logic for DescriptionWindow.xaml
    /// </summary>
    public partial class DescriptionWindow : Window
    {
        public DescriptionWindow(int testType, string testTypeName)
        {
            InitializeComponent();
            theoryTitle.Content = testTypeName;
            SetCcntentValueByTestType(testType);
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetCcntentValueByTestType(int testType) 
        {
            using (StreamReader theoryStreamReader = new StreamReader(SociologicalTest.parentPath + "theory" + testType + ".txt"))
            {
                String theory = theoryStreamReader.ReadToEnd();
                theoryText.Text = theory;
            }
        }
    }
}
