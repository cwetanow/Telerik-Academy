using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Sumator_WebForms
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                var firstNum = decimal.Parse(this.TextBoxFirstNum.Text);
                var secondNum = decimal.Parse(this.TextBoxSecondNum.Text);
                var sum = firstNum + secondNum;
                this.TextBoxSum.Text = sum.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                this.TextBoxSum.Text = "Invalid.";
            }
        }
    }
}