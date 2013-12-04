using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLab1
{
    class Parser
    {
        private const string RULE = "Rules:";
        private const string QUESTION = "Questions:";

        private string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sociological tests\";

        public List<SociologicalTest> GetTests()
        {
            List<SociologicalTest> tests = new List<SociologicalTest>();

            int testsNumber = 0;

            using (StreamReader numberStreamReader = new StreamReader(parentPath + @"testsNumber.txt"))
            {
                String number = numberStreamReader.ReadToEnd();
                if (!number.Equals(String.Empty))
                {
                    Int32.TryParse(number, out testsNumber);
                }
            }

            for (int i = 1; i <= testsNumber; i++)
            {
                tests.Add(GetTest(parentPath + @"test" + i + ".txt"));
            }

            return tests;
        }

        private SociologicalTest GetTest(string path)
        {
            string line;

            bool isQuestions = false;
            bool isRules = false;

            Dictionary<int, Dictionary<string, string>> questions = new Dictionary<int, Dictionary<string, string>>();
            List<Rule> rules = new List<Rule>();
            int currentQestionNumber = 0;

            string name = null;
            string description = null;
            int number = 0;

            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Equals(QUESTION)) 
                    {
                        isQuestions = true;
                        continue;
                    }
                    else if (line.Equals(RULE)) 
                    {
                        isRules = true;
                        isQuestions = false;
                        continue;
                    }

                    if (isQuestions) 
                    {
                        currentQestionNumber = AddQuestionData(currentQestionNumber, line, questions);
                    }
                    else if (isRules)
                    {
                        AddRulesData(line, rules);
                    }
                    else 
                    {
                        string[] splitingText = line.Split('/');
                        if (splitingText[0].Equals("number")) 
                        {
                            number = Int32.Parse(splitingText[1]);
                        }
                        else if (splitingText[0].Equals("name")) 
                        {
                            name = splitingText[1];
                        }
                        else if (splitingText[0].Equals("description"))
                        {
                            description = splitingText[1];
                        }
                    }
                }
            }

            return CreateTest(name, description, number, questions, rules);
        }

        private int AddQuestionData(int currentQestionNumber, string line, Dictionary<int, Dictionary<string, string>> questions) 
        {
            string[] splitingText = line.Split('/');
            if (splitingText[0].Equals("n"))
            {
                currentQestionNumber = Int32.Parse(splitingText[1]);
                Dictionary<string, string> questionLines = new Dictionary<string, string>();
                questions.Add(currentQestionNumber, questionLines);
            }
            else
            {
                Dictionary<string, string> questionLines = questions[currentQestionNumber];
                string[] questionSplitingText = line.Split('/');
                questionLines.Add(questionSplitingText[0], questionSplitingText[1]);
            }

            return currentQestionNumber;
        }

        private void AddRulesData(string line, List<Rule> rules) 
        {
            string[] splitingText = line.Split('/');

            Rule rule = new Rule(splitingText[1], splitingText[3]);

            rules.Add(rule);
        }

        private SociologicalTest CreateTest(string name, string description, int number,
            Dictionary<int, Dictionary<string, string>> questions, List<Rule> rules) 
        {
            SociologicalTest test = new SociologicalTest(number, name, description);

            test.rules = rules;

            foreach (int key in questions.Keys) 
            {
                string text = null;
                Dictionary<string, string> values = questions[key];
                Dictionary<string, string> answers = new Dictionary<string, string>();
                foreach (var value in values) 
                {
                    if (value.Key.Equals("q"))
                    {
                        text = value.Value;
                    }
                    else 
                    {
                        answers.Add(value.Key, value.Value);
                    }
                }

                Question question = new Question(text, key);
                question.Answers = answers;

                test.Questions.Add(key, question);
            }

            return test;
        }
    }
}
