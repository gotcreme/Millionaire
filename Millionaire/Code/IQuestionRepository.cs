using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Code
{
    interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions();
    }
}
