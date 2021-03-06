﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLab1
{
    public class SociologicalTest
    {
        public const int DICHOTOMIC_TEST_TYPE = 1;
        public const int MULT_TEST_TYPE = 2;
        public const int OPEN_TEST_TYPE = 3;

        public Dictionary<int, Question> Questions = new Dictionary<int, Question>();
        public FileInfo TestFile { get; set; }
        public static string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sociological tests\";
        public List<Rule> rules = null;
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<int, string> result = new Dictionary<int, string>();
        public int Type { get; set; }

        public SociologicalTest(int number, string name, string description, int type)
        {
            Number = number;
            Name = name;
            Description = description;
            Type = type;
        }

        public SociologicalTest(string name, string description, int type) 
        {
            Name = name;
            Description = description;
            Type = type;

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
                    streamWriter.WriteLine("type/" + type);
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

        public List<string> GetResults() 
        {
            List<string> results = new List<string>();

            foreach (Rule rule in rules) 
            {
                if ((rule.Type == MULT_TEST_TYPE || rule.Type ==DICHOTOMIC_TEST_TYPE) && rule.ResultSubjectToRule(result)) 
                {
                    results.Add(rule.ThenText);
                }
                else if (rule.Type == OPEN_TEST_TYPE && rule.ResultSubjectForOpenRule(result)) 
                {
                    results.Add(rule.ThenText);
                }
            }

            return results;
        }

        private void AddQuestionToFile(Question question) 
        {
            if (!TestFile.Exists)
            {
                using (StreamWriter streamWriter = TestFile.AppendText())
                {
                    streamWriter.WriteLine("n/" + question.Number);
                    streamWriter.WriteLine("q/" + question.QuestionText);
                    streamWriter.WriteLine("measure/" + question.Measure);
                    streamWriter.WriteLine("example/" + question.Example);
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
