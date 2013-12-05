using IOSLab1.ExecutionTestWindows;
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
        private const int DICHOTOMIC_TEST_TYPE = 1;
        private const int MULT_TEST_TYPE = 2;
        private const int OPEN_TEST_TYPE = 3;

        private List<SociologicalTest> tests = new List<SociologicalTest>();
        private Dictionary<int, List<string>> testTypes = new Dictionary<int, List<string>>();
        private SociologicalTest SelectedTest;
        private int testType = 1;

        public MainWindow()
        {
            Parser parser = new Parser();
            tests = parser.GetTests();
            testTypes = parser.GetTestTypes();
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void createTest_Click(object sender, RoutedEventArgs e)
        {
            string name = testName.Text;
            string description = testDescription.Text;

            if (name.Equals(String.Empty) || description.Equals(String.Empty)) 
            {
                return;
            }

            SociologicalTest sociologicalTest = new SociologicalTest(name, description, testType);

            Window createTestWindow = null;

            if (testType == MULT_TEST_TYPE) 
            {
                createTestWindow = new CreateTest(sociologicalTest);
            }
            else if (testType == DICHOTOMIC_TEST_TYPE)
            {
                createTestWindow = new CreateDichotomicQuestionWindow(sociologicalTest);
            }
            else 
            {
                createTestWindow = new CreateOpenQuestionWindow(sociologicalTest);
            }

            createTestWindow.ShowDialog();

            RestoreOriginalState();

            tests.Add(sociologicalTest);
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
            Window testExecutionWindow = null;

            if (SelectedTest.Type == MULT_TEST_TYPE)
            {
                testExecutionWindow = new TestExecutionWindow(SelectedTest);
            }
            else if (SelectedTest.Type == DICHOTOMIC_TEST_TYPE)
            {
                testExecutionWindow = new TestExecutionWindow(SelectedTest);
            }
            else
            {
                testExecutionWindow = new OpenTestExecutionWindow(SelectedTest);
            }

            testExecutionWindow.ShowDialog();

            //List<string> results = SelectedTest.GetResults();

            //StringBuilder stringBuilder = new StringBuilder();

            //foreach (string result in results) 
            //{
            //    stringBuilder.Append(result + '\n');
            //}

            //resultLabel.Content = stringBuilder.ToString();
        }

        private void testTypesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var testTypesComboBox = sender as ComboBox;

            string value = testTypesComboBox.SelectedItem as string;

            testType = testTypes.FirstOrDefault(t => t.Value[0].Equals(value)).Key;

            descriptionTypeLabel.Text = testTypes[testType][1];
        }

        private void testTypesComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var testTypesComboBox = sender as ComboBox;

            List<string> data = new List<string>();

            foreach (var type in testTypes.Values)
            {
                data.Add(type[0]);
            }

            testTypesComboBox.ItemsSource = data;

            testTypesComboBox.SelectedIndex = 0;

            descriptionTypeLabel.Text = testTypes[1][1];
        }

        private void fullDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            DescriptionWindow descriptionWindow = new DescriptionWindow(testType, testTypes[testType][0]);
            descriptionWindow.ShowDialog();
        }
    }
}
