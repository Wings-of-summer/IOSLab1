using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLab1
{
    public class Rule
    {
        private bool isFirstLetter = false;
        private bool isSecondLetter = false;
        private string firstValue;
        private string secondValue;
        private string conditionValue;

        public String IfText { get; set; }
        public String ThenText { get; set; }

        public Rule(String ifText, String thenText) 
        {
            IfText = ifText;
            ThenText = thenText;
            ParseIfText();
        }

        private void ParseIfText() 
        {
            SetFirstValue();
            SetConditionValue();
            SetSecondValue();
        }

        private void SetFirstValue() 
        {
            string value = IfText.Substring(0, 1);

            int number = 0;
            Int32.TryParse(value, out number);

            if (number == 0)
            {
                isFirstLetter = true;
            }

            firstValue = value;
        }

        private void SetConditionValue()
        {
            string value = IfText.Substring(1, 2);

            if (Char.IsLetter(value.ToCharArray()[1]) || Char.IsDigit(value.ToCharArray()[1])) 
            {
                value = value.Substring(0, 1);
            }

            conditionValue = value;
        }

        private void SetSecondValue()
        {
            string value = IfText.Substring(IfText.IndexOf(conditionValue) + conditionValue.Length);

            int number = 0;
            Int32.TryParse(value, out number);

            if (number == 0)
            {
                isSecondLetter = true;
            }

            secondValue = value;
        }

        public bool ResultSubjectToRule(Dictionary<int, string> result) 
        {
            if (isFirstLetter && isSecondLetter) 
            {
                int firstNumber = result.Select(r => r.Value.Equals(firstValue)).ToList().Count;
                int secondNumber = result.Select(r => r.Value.Equals(secondValue)).ToList().Count;
                return CompareValue(firstNumber, secondNumber);
            }
            else if (isFirstLetter && !isSecondLetter) 
            {
                int firstNumber = result.Count(r => r.Value.Equals(firstValue));
                int secondNumber = Int32.Parse(secondValue);
                return CompareValue(firstNumber, secondNumber);
            }
            else if (!isFirstLetter && isSecondLetter && conditionValue.Equals("=="))
            {
                int firstNumber = Int32.Parse(firstValue);
                return result[firstNumber].Equals(secondValue);
            }

            return false;
        }

        private bool CompareValue(int first, int second) 
        {
            switch (conditionValue) 
            {
                case ">":
                    return first > second;
                case "<":
                    return first < second;
                case ">=":
                    return first >= second;
                case "<=":
                    return first <= second;
                case "==":
                    return first == second;
                default:
                    return false;
            }
        }
    }
}
