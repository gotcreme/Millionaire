using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Millionaire.Code
{
    public class Question
    {
        [XmlElement("Text")]
        public string Text { get; set; }
        [XmlElement("Answers")]
        public Answer[] Answers { get; set; }

        public Question(string quest, Answer[] answers)
        {
            this.Answers = answers;
            this.Text = quest;
        }

        public Question()
        {
            Text = "";
            Answers = new Answer[15];
        }
    }
}