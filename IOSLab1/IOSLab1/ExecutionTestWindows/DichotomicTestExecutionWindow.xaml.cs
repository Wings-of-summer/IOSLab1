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

namespace IOSLab1.ExecutionTestWindows
{
    /// <summary>
    /// Interaction logic for DichotomicTestExecutionWindow.xaml
    /// </summary>
    public partial class DichotomicTestExecutionWindow : Window
    {
        private int questionNumber = 1;
        private string answerVariant = "yes";

        public SociologicalTest Test { get; set; }

        public DichotomicTestExecutionWindow(SociologicalTest test)
        {
            Test = test;
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitQuestion();
        }

        private void InitQuestion()
        {
            Question question = Test.Questions[questionNumber];

            questionLabel.Text = question.QuestionText;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            Test.result.Add(questionNumber, answerVariant);

            questionNumber++;

            if (questionNumber > Test.Questions.Count)
            {
                this.Close();
                return;
            }

            InitQuestion();
        }

        private void radioButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            answerVariant = radioButton.Name;
        }
    }
}
