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
        public int Type { get; set; }

        public Rule(String ifText, String thenText, int type) 
        {
            IfText = ifText;
            ThenText = thenText;
            Type = type;
            ParseIfText();
        }

        private void ParseIfText() 
        {
            if (Type == SociologicalTest.MULT_TEST_TYPE || Type == SociologicalTest.OPEN_TEST_TYPE) 
            {
                SetFirstValue();
                SetConditionValue();
                SetSecondValue();
            }
            else if (Type == SociologicalTest.DICHOTOMIC_TEST_TYPE) 
            {
                SetFirstValueForDichotomicRules();
                SetConditionValueForDichotomicRules();
                SetSecondValueForDichotomicRules();
            }
        }

        private void SetFirstValue() 
        {
            string value = IfText.Substring(0, 1);

            int number = 0;
            bool isDigit = Int32.TryParse(value, out number);

            if (!isDigit)
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

        private void SetFirstValueForDichotomicRules()
        {
            if (IfText.StartsWith("yes")) 
            {
                firstValue = "yes";
                isFirstLetter = true;
            }
            else if (IfText.StartsWith("no"))
            {
                firstValue = "no";
                isFirstLetter = true;
            }
            else 
            {
                firstValue = IfText.Split('=')[0];
            }
        }

        private void SetConditionValueForDichotomicRules()
        {
            string value = IfText.Remove(IfText.IndexOf(firstValue), firstValue.Length).Substring(0, 2);

            if (Char.IsLetter(value.ToCharArray()[1]) || Char.IsDigit(value.ToCharArray()[1]))
            {
                value = value.Substring(0, 1);
            }

            conditionValue = value;
        }

        private void SetSecondValueForDichotomicRules()
        {
            if (IfText.EndsWith("yes"))
            {
                secondValue = "yes";
                isSecondLetter = true;
            }
            else if (IfText.EndsWith("no"))
            {
                secondValue = "no";
                isSecondLetter = true;
            }
            else
            {
                secondValue = IfText.Remove(0, firstValue.Length + conditionValue.Length);
            }
        }

        public bool ResultSubjectForOpenRule(Dictionary<int, string> result)
        {
            if (isFirstLetter)
            {
                return false;
            }
            else if (!isSecondLetter)
            {
                string first = result[Int16.Parse(firstValue)];
                int value = 0;

                bool isDigit = Int32.TryParse(first, out value);

                if (!isDigit) 
                {
                    return false;
                }

                int secondNumber = Int32.Parse(secondValue);
                return CompareValue(value, secondNumber);
            }
            else if (!isFirstLetter && isSecondLetter && conditionValue.Equals("=="))
            {
                int firstNumber = Int32.Parse(firstValue);
                return result[firstNumber].Equals(secondValue);
            }

            return false;
        }

    }
}
