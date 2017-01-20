using System;
using System.Web.UI;

namespace _01.Hello
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangeName_OnClick(object sender, EventArgs e)
        {
            var name = this.NameBox.Text;
            this.Name.Text = name;
        }
    }
}