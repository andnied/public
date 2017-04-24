using Microsoft.Owin.Security.OAuth;
using Owin;
using WebAPI.Host.App_Start;

namespace WebAPI.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = WebApiConfig.Register();

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {

            });
            app.UseWebApi(config);
        }
    }
}