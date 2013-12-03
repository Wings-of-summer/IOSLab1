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
        public Dictionary<String, String> Answers = null;
        public int Number { get; set; }

        public Question(string questionText, int number) 
        {
            QuestionText = questionText;
            Number = number;
        }

        public void AddAnswer(string name, string text) 
        {
            if (Answers == null) 
            {
                Answers = new Dictionary<string, string>();
            }
            Answers.Add(name, text);
        }
    }
}
