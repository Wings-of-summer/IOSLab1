using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLab1
{
    public class Question
    {
        public String QuestionText { get; set; }
        public Dictionary<String, String> Answers = new Dictionary<string,string>();
        public int Number { get; set; }
        public int Type { get; set; }
        public string Example { get; set; }
        public string Measure { get; set; }

        public Question(string questionText, int number, int type) 
        {
            QuestionText = questionText;
            Number = number;
            Type = type;
        }

        public void AddAnswer(string name, string text) 
        {
            Answers.Add(name, text);
        }
    }
}
