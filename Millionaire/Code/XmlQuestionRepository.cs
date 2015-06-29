using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Millionaire.Code
{
    public class XmlQuestionRepository : IQuestionRepository
    {

        private readonly string _fileName;

        public XmlQuestionRepository(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<Question> GetQuestions()
        {
            Question[] questions;
            var xmlFormat = new XmlSerializer(typeof(Question[]));
            using ( var fstream = new FileStream(this._fileName, FileMode.Open, FileAccess.Read, FileShare.None) )
            {
                questions = (Question[])xmlFormat.Deserialize(fstream);
            }
            return questions;  
        }
    }
}