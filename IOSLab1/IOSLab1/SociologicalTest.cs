using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLab1
{
    public class SociologicalTest
    {
        public Dictionary<int, Question> Questions = new Dictionary<int, Question>();
        public FileInfo TestFile { get; set; }
        public string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sociological tests\";
        public List<Rule> rules = null;
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SociologicalTest(int number, string name, string description)
        {
            Number = number;
            Name = name;
            Description = description;
        }

        public SociologicalTest(string name, string description) 
        {
            Name = name;
            Description = description;

            int testsNumber = 0;

            using (StreamReader numberStreamReader = new StreamReader(parentPath + @"testsNumber.txt"))
            {
                String number = numberStreamReader.ReadToEnd();
                if (!number.Equals(String.Empty)) 
                {
                    Int32.TryParse(number, out testsNumber);
                }
            }

            testsNumber++;

            Number = testsNumber;

            TestFile = new FileInfo(parentPath + "test" + testsNumber.ToString() + ".txt");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"testsNumber.txt", false))
            {
                file.WriteLine(testsNumber);
            }

            if (!TestFile.Exists)
            {
                using (StreamWriter streamWriter = TestFile.CreateText())
                {
                    streamWriter.WriteLine("number/" + testsNumber.ToString());
                    streamWriter.WriteLine("name/" + name);
                    streamWriter.WriteLine("description/" + description);
                }
            }
        }

        public void AddQuestion(Question question) 
        {
            if (Questions.Count == 0) 
            {
                if (!TestFile.Exists)
                {
                    using (StreamWriter streamWriter = TestFile.AppendText())
                    {
                        streamWriter.WriteLine("Questions:");
                    }
                }
            }

            if (!Questions.ContainsKey(question.Number)) 
            {
                Questions.Add(question.Number, question);
                AddQuestionToFile(question);
            }
        }

        private void AddQuestionToFile(Question question) 
        {
            if (!TestFile.Exists)
            {
                using (StreamWriter streamWriter = TestFile.AppendText())
                {
                    streamWriter.WriteLine("n/" + question.Number);
                    streamWriter.WriteLine("q/" + question.QuestionText);
                    foreach (var answer in question.Answers) 
                    {
                        streamWriter.WriteLine(answer.Key + "/" + answer.Value);
                    }
                }
            }
        }

        public void AddRule(Rule rule) 
        {
            if (rules == null) 
            {
                rules = new List<Rule>();
                if (!TestFile.Exists)
                {
                    using (StreamWriter streamWriter = TestFile.AppendText())
                    {
                        streamWriter.WriteLine("Rules:");
                    }
                }
            }

            rules.Add(rule);
            AddRuleToFile(rule);
        }

        private void AddRuleToFile(Rule rule) 
        {
            if (!TestFile.Exists)
            {
                using (StreamWriter streamWriter = TestFile.AppendText())
                {
                    streamWriter.WriteLine("if/" + rule.IfText + "/then/" + rule.ThenText);
                }
            }
        }
    }
}
