using System.Web;

namespace _03.HttpHandler
{
    public class ImageHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "image/png";
        }

        public bool IsReusable => false;
    }
}