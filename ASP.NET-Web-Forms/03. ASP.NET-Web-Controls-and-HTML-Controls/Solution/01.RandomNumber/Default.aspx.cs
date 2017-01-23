using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.RandomNumber
{
    public partial class _Default : Page
    {
        private static Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnButtonRandomClick(object sender, EventArgs e)
        {
            var min = 0;
            var first = int.TryParse(this.MinNumberInput.Value, out min);

            var max = 0;
            var second = int.TryParse(this.MaxNumberInput.Value, out max);

            if (first && second)
            {
                var num = random.Next(min, max + 1);
                this.Sum.InnerText = num.ToString();
            }
            else
            {
                this.Sum.InnerText = "Invalid input";
            }
        }

        protected void OnServerButtonClick(object sender, EventArgs e)
        {
            var min = 0;
            var first = int.TryParse(this.MinInputServer.Text, out min);

            var max = 0;
            var second = int.TryParse(this.MaxInputServer.Text, out max);

            if (first && second)
            {
                var num = random.Next(min, max + 1);
                this.ServerRandomResult.Text = num.ToString();
            }
            else
            {
                this.ServerRandomResult.Text = "Invalid input";
            }
        }
    }
}