using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstWebApp
{
    public partial class Money : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ageUserResult_TextChanged(object sender, EventArgs e)
        {
          
        
        }

        protected void fortuneResult_Click(object sender, EventArgs e)
        {
            string age = ageTextBox.Text;
            string funds = fortuneTextBox.Text;

            string result = "I would of expected more money at " + age + ",  you only have " + funds + " pathetic!";

            resultLabelText.Text = result;

        }
    }
}