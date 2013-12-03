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
        public FileInfo TestFile { get; set; }
        public string parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sociological tests\";
        public Dictionary<int, Question> questions = null;

        public SociologicalTest(string name, string description) 
        {
            int testsNumber = 0;

            using (StreamReader numberStreamReader = new StreamReader(parentPath + @"testsNumber.txt"))
            {
                String number = numberStreamReader.ReadToEnd();
                if (!number.Equals(String.Empty)) 
                {
                    testsNumber = Int32.Parse(number);
                }
            }

            testsNumber++;

            TestFile = new FileInfo(parentPath + "test" + testsNumber.ToString() + ".txt");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(parentPath + @"testsNumber.txt", false))
            {
                file.WriteLine(testsNumber);
            }

            if (!TestFile.Exists)
            {
                using (StreamWriter streamWriter = TestFile.CreateText())
                {
                    streamWriter.WriteLine(testsNumber.ToString());
                    streamWriter.WriteLine(name);
                    streamWriter.WriteLine(description);
                }
            }
        }

        public SociologicalTest(FileInfo testFile)
        {
            TestFile = testFile;
        }

        public void AddQuestion(Question question) 
        {
            if (questions == null) 
            {
                questions = new Dictionary<int, Question>();
            }

            if (!questions.ContainsKey(question.Number)) 
            {
                questions.Add(question.Number, question);
                AddQuestionToFile(question);
            }
        }

        private void AddQuestionToFile(Question question) 
        {
            if (!TestFile.Exists)
            {
                using (StreamWriter streamWriter = TestFile.AppendText())
                {
                    streamWriter.WriteLine("q/" + question.Number + "/" + question);
                    foreach (var answer in question.Answers) 
                    {
                        streamWriter.WriteLine(answer.Key + "/" + answer.Value);
                    }
                }
            }
        }
    }
}
