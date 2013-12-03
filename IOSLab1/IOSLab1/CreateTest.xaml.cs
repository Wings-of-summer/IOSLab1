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
    /// Interaction logic for CreateTest.xaml
    /// </summary>
    public partial class CreateTest : Window
    {
        public SociologicalTest test { get; set; }
        private int questionsNumber = 0;

        public CreateTest()
        {
            InitializeComponent();
        }

        public CreateTest(SociologicalTest test)
        {
            this.test = test;
            InitializeComponent();
        }

        private void addQuestion_Click(object sender, RoutedEventArgs e)
        {
            string questionString = questionTextBox.Text;
            string aString = aAnswerTextBox.Text;
            string bString = bAnswerTextBox.Text;

            if (questionString.Equals(String.Empty) || aString.Equals(String.Empty) || bString.Equals(String.Empty)) 
            {
                return;
            }

            Dictionary<String, String> answers = new Dictionary<string, string>();

            answers.Add("a", aString);
            answers.Add("b", bString);

            if (cAnswerTextBox.IsEnabled && !cAnswerTextBox.Text.Equals(String.Empty)) 
            {
                answers.Add("c", cAnswerTextBox.Text);
            }

            if (dAnswerTextBox.IsEnabled && !dAnswerTextBox.Text.Equals(String.Empty))
            {
                answers.Add("d", dAnswerTextBox.Text);
            }

            test.AddQuestion(questionString, answers);

            questionsNumber++;

            questionsNumberLabel.Content = questionsNumber.ToString();

            if (questionsNumber > 0) 
            {
                specifyRules.IsEnabled = true;
            }

            RestoreOriginalState();
        }

        private void RestoreOriginalState() 
        {
            questionTextBox.Clear();
            aAnswerTextBox.Clear();
            bAnswerTextBox.Clear();
            cAnswerTextBox.Clear();
            dAnswerTextBox.Clear();

            cAnswerTextBox.IsEnabled = false;
            dAnswerTextBox.IsEnabled = false;

            addD.IsEnabled = false;
        }
    }
}
