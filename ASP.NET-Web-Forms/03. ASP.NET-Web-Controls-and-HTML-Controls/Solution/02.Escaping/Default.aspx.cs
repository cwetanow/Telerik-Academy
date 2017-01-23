using System;
using System.Web.UI;

namespace _02.Escaping
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmitClick(object sender, EventArgs e)
        {
            var text = this.Input.Text;
            text = this.Server.HtmlEncode(text);

            this.ResultInput.Text = text;
            this.ResultLabel.Text = text;
        }
    }
}