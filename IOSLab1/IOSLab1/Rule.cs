using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSLab1
{
    public class Rule
    {
        public String IfText { get; set; }
        public String ThenText { get; set; }

        public Rule(String ifText, String thenText) 
        {
            IfText = ifText;
            ThenText = thenText;
        }
    }
}
