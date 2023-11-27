using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Trivia_Stage1.UI
{
    class AddQuestionScreen:Screen
    {
        public AddQuestionScreen():base("Add Question")
        {


        }
        //
        public override void Show()
        {
            base.Show();
            Program.ui.Screens.ShowAddQuestion();
        }
    }
}
