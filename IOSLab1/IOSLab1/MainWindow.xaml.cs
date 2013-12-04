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
        private List<SociologicalTest> tests = new List<SociologicalTest>();
        private SociologicalTest SelectedTest;

        public MainWindow()
        {
            Parser parser = new Parser();
            tests = parser.GetTests();
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
            RestoreOriginalState();

            tests.Add(sociologicalTest);
            testsComboBox.Items.Add(sociologicalTest.Name);
        }

        private void RestoreOriginalState()
        {
            testName.Clear();
            testDescription.Clear();
        }

        private void testsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            string value = comboBox.SelectedItem as string;

            SelectedTest = tests.FirstOrDefault(t => t.Name.Equals(value));
            descriptionLabel.Content = SelectedTest.Description;
        }

        private void testsComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var testsComboBox = sender as ComboBox;

            List<string> data = new List<string>();

            foreach (var test in tests)
            {
                data.Add(test.Name);
            }

            testsComboBox.ItemsSource = data;

            testsComboBox.SelectedIndex = 0;
            descriptionLabel.Content = tests[0].Description;
        }

        private void executeTestButton_Click(object sender, RoutedEventArgs e)
        {
            TestExecutionWindow testExecutionWindow = new TestExecutionWindow(SelectedTest);
            testExecutionWindow.ShowDialog();
            List<string> results = SelectedTest.GetResults();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (string result in results) 
            {
                stringBuilder.Append(result + '\n');
            }

            resultLabel.Content = stringBuilder.ToString();
        }
    }
}
