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

namespace IOSLab1
{
    /// <summary>
    /// Interaction logic for TestExecutionWindow.xaml
    /// </summary>
    public partial class TestExecutionWindow : Window
    {
        private int questionNumber = 1;
        private string answerVriant = "a";

        public SociologicalTest Test { get; set; }

        public TestExecutionWindow(SociologicalTest test)
        {
            Test = test;
            InitializeComponent();
            InitQuestion();
        }

        private void InitQuestion() 
        {
            HideRadioButtons();

            Question question = Test.Questions[questionNumber];

            questionLabel.Content = question.QuestionText;

            foreach (var answer in question.Answers) 
            {
                if (answer.Key.Equals("a")) 
                {
                    a.Content = answer.Value;
                    a.Visibility = System.Windows.Visibility.Visible;
                }
                if (answer.Key.Equals("b"))
                {
                    b.Content = answer.Value;
                    b.Visibility = System.Windows.Visibility.Visible;
                }
                if (answer.Key.Equals("c"))
                {
                    c.Content = answer.Value;
                    c.Visibility = System.Windows.Visibility.Visible;
                }
                if (answer.Key.Equals("d"))
                {
                    d.Content = answer.Value;
                    d.Visibility = System.Windows.Visibility.Visible;
                }
            }

            a.IsChecked = true;
            answerVriant = "a";
        }

        private void HideRadioButtons() 
        {
            a.Visibility = System.Windows.Visibility.Hidden;
            b.Visibility = System.Windows.Visibility.Hidden;
            c.Visibility = System.Windows.Visibility.Hidden;
            d.Visibility = System.Windows.Visibility.Hidden;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            Test.result.Add(questionNumber, answerVriant);

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
            answerVriant = radioButton.Name;
        }
    }
}
