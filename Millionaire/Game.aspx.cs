using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Code;
using Millionaire.Code.Enums;
using Millionaire.Code.Keys;

namespace Millionaire
{
    public partial class Game : System.Web.UI.Page
    {
        private Question[] _questions;
        private Button[] _btnAnswers;
        private int _currentStep;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[SessionKeys.USER_KEY] == null )
            {
                InitSession();
            }
            InitButtons();
            string text = (string)Session[SessionKeys.USER_KEY];
            this._questions = (Question[])Session[SessionKeys.QUESTIONS_KEY];
            this._currentStep = (int)Session[SessionKeys.STEP_KEY];
            LoadNextQuestion(this._currentStep);
        }

        void LoadNextQuestion(int step)
        {
            if (step < 15)
            {
                MarkScore(step);
                lblQuest.Text = _questions[step].Text;
                btnA.Text = _questions[step].Answers[0].Text;
                btnB.Text = _questions[step].Answers[1].Text;
                btnC.Text = _questions[step].Answers[2].Text;
                btnD.Text = _questions[step].Answers[3].Text;
            }
            else
            {
                GameWin();
            }
        }

        private void InitSession()
        {
            var xml = new XmlQuestionRepository(Server.MapPath("/App_Data/Questions.xml"));
            Session[SessionKeys.USER_KEY] = System.Guid.NewGuid().ToString();
            Session[SessionKeys.QUESTIONS_KEY] = xml.GetQuestions();
            Session[SessionKeys.STEP_KEY] = 0;
        }

        private void MarkScore(int step)
        {
            if (step != 0)
            {
                if (step != 15)
                {
                    scoretable.Rows[15 - step + 1].Attributes.Clear();
                }
                scoretable.Rows[15 - step + 1].Attributes.Add("class", "passedscore");
                scoretable.Rows[15 - step].Attributes.Add("class", "currentscore");
            }
            else
            {
                scoretable.Rows[15].Attributes.Add("class", "currentscore");
            }
        }

        private void InitButtons()
        {
            _btnAnswers = new Button[] { btnA, btnB, btnC, btnD };
            foreach (var btn in _btnAnswers)
                btn.Enabled = true;
        }

        private void InitHelpButtons()
        {
            btnHelp1.Enabled = true;
            btnHelp1.CssClass = "help help1 unfocus";
            btnHelp2.Enabled = true;
            btnHelp2.CssClass = "help help2 unfocus";
            btnHelp3.Enabled = true;
            btnHelp3.CssClass = "help help3 unfocus";
        }

        private void GameLose()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", String.Format("alert('Гру закінчено. Ваш виграш: {0}');", GiveMoney()), true);
            Restart();
        }

        private void GameWin()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви виграли 1 000 000!');", true);
            Restart();
        }

        private void Restart()
        {
            Session[SessionKeys.USER_KEY] = null;
            ClearScoreTable();
            InitHelpButtons();
            Page_Load(this, EventArgs.Empty);
        }

        protected void btnA_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.A) == true)
            {
                Session[SessionKeys.STEP_KEY] = ++this._currentStep;
                LoadNextQuestion(_currentStep);
            }
            else
            {
                GameLose();
            }
        }
        protected void btnB_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.B) == true)
            {
                Session[SessionKeys.STEP_KEY] = ++this._currentStep;
                LoadNextQuestion(_currentStep);
            }
            else
            {
                GameLose();
            }
        }
        protected void btnC_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.C) == true)
            {
                Session[SessionKeys.STEP_KEY] = ++this._currentStep;
                LoadNextQuestion(_currentStep);
            }
            else
            {
                GameLose();
            }
        }
        protected void btnD_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.D) == true)
            {
                Session[SessionKeys.STEP_KEY] = ++this._currentStep;
                LoadNextQuestion(_currentStep);
            }
            else
            {
                GameLose();
            }
        }

        protected void btnHelp1_Click(object sender, EventArgs e)
        {
            btnHelp1.Enabled = false;
            btnHelp1.CssClass = "help help1u unfocus";
            DeleteTwoIncorrectAnswers();
        }

        protected void btnHelp2_Click(object sender, EventArgs e)
        {
            btnHelp2.Enabled = false;
            btnHelp2.CssClass = "help help2u unfocus";
        }
        protected void btnHelp3_Click(object sender, EventArgs e)
        {
            btnHelp3.Enabled = false;
            btnHelp3.CssClass = "help help3u unfocus";
            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua/search?q=" + _questions[this._currentStep].Text + "')", true);
        }

        private bool CheckAnswer(AnswerType answer)
        {
            return _questions[_currentStep].Answers[(int)answer].IsCorrect == true;
        }

        private void ClearScoreTable()
        {
            for (int i = 0; i <= 15; i++)
            {
                scoretable.Rows[15 - i].Attributes.Clear();
            }
            scoretable.Rows[1].Attributes.Add("class", "fire");
            scoretable.Rows[6].Attributes.Add("class", "fire");
            scoretable.Rows[11].Attributes.Add("class", "fire");
        }

        private void DeleteTwoIncorrectAnswers()
        {
            Random rnd;
            int answer1, answer2;
            do
            {
                rnd = new Random();
                answer1 = rnd.Next(0, 3);
                do
                {
                    rnd = new Random();
                    answer2 = rnd.Next(0, 3);
                } while ( ((_questions.ElementAt(this._currentStep).Answers[answer2].IsCorrect) || (answer1 == answer2)) );

            } while (_questions.ElementAt(this._currentStep).Answers[answer1].IsCorrect);
            _btnAnswers[answer1].Text = string.Empty;
            _btnAnswers[answer1].Enabled = false;
            _btnAnswers[answer2].Text = string.Empty;
            _btnAnswers[answer2].Enabled = false;
        }

        private int GiveMoney()
        {
            int money = 0;
            if (this._currentStep < 5)
            {
                money = 0;
            }
            else if (this._currentStep >= 5 & this._currentStep < 10)
            {
                money = 1000;
            }
            else if (this._currentStep >= 10 & this._currentStep < 15)
            {
                money = 32000;
            }
            else
            {
                money = 1000000;
            }
            return money;
        }
    }
}