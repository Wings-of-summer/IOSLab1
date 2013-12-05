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
    /// Interaction logic for RulesWindow.xaml
    /// </summary>
    public partial class RulesWindow : Window
    {
        public SociologicalTest Test { get; set; }
        private int rulesNumber = 0;

        public RulesWindow(SociologicalTest test)
        {
            Test = test;
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void addRuleButton_Click(object sender, RoutedEventArgs e)
        {
            string ifText = ifRule.Text;
            string thenText = thenRule.Text;

            if (ifText.Equals(String.Empty) || thenText.Equals(String.Empty)) 
            {
                return;
            }

            rulesNumber++;
            rulesNumberLabel.Content = rulesNumber.ToString();

            if (rulesNumber > 0) 
            {
                finishButton.IsEnabled = true;
            }

            Test.AddRule(new Rule(ifText, thenText));
            RestoreOriginalState();
        }

        private void RestoreOriginalState()
        {
            ifRule.Clear();
            thenRule.Clear();
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }
    }
}
