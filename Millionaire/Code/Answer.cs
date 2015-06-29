using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millionaire.Code
{
    public class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer()
        {
            Text = "";
            IsCorrect = false;
        }

        public Answer(string ans, bool res)
        {
            this.Text = ans;
            this.IsCorrect = res;
        }
    }
}