using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.PageEvents
{
    public partial class _Default : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_PreInit." + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_Init." + "<br/>");
        }

        protected void Page_InitComplete(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_InitComplete." + "<br/>");
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_PreLoad." + "<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_Load." + "<br/>");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_LoadComplete." + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_PreRender." + "<br/>");
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_SaveStateComplete." + "<br/>");
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_Render." + "<br/>");
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            this.Response.Write("Invoke Page_PreRenderComplete." + "<br/>");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // this.Response.Write("Invoke Page_Unload." + "<br/>");
        }

        protected void OnButtonInit(object sender, EventArgs e)
        {
            this.Response.Write("OnButtonInit." + "<br/>");
        }

        protected void OnButtonLoad(object sender, EventArgs e)
        {
            this.Response.Write("OnButtonLoad." + "<br/>");
        }

        protected void OnButtonClicked(object sender, EventArgs e)
        {
            this.Response.Write("OnButtonClicked." + "<br/>");
        }

        protected void OnButtonPreRender(object sender, EventArgs e)
        {
            this.Response.Write("OnButtonPreRender." + "<br/>");
        }
    }
}