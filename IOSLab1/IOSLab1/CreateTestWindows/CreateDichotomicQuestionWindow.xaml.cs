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
    /// Interaction logic for CreateDichotomicQuestionWindow.xaml
    /// </summary>
    public partial class CreateDichotomicQuestionWindow : Window
    {
        public SociologicalTest Test { get; set; }
        private int questionsNumber = 0;

        public CreateDichotomicQuestionWindow(SociologicalTest test)
        {
            this.Test = test;
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void addQuestion_Click(object sender, RoutedEventArgs e)
        {
            string questionString = questionTextBox.Text;

            if (questionString.Equals(String.Empty))
            {
                return;
            }

            questionsNumber++;

            Question question = new Question(questionString, questionsNumber, Test.Type);

            Test.AddQuestion(question);

            questionsNumberLabel.Content = questionsNumber.ToString();

            if (questionsNumber > 0)
            {
                specifyRules.IsEnabled = true;
            }

            RestoreOriginalState();
        }

        private void specifyRules_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            RulesWindow rulesWindow = new RulesWindow(Test);
            rulesWindow.ShowDialog();
        }

        private void RestoreOriginalState()
        {
            questionTextBox.Clear();
        }
    }
}
