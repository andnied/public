using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Web.Http;
using Unity.WebApi;
using WebAPI.BLL.Services;

[assembly: OwinStartup(typeof(WebAPI.IdServer.Startup))]
namespace WebAPI.IdServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = Register();
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new AuthorizationServerProvider((ApplicationUserManager)config.DependencyResolver.GetService(typeof(ApplicationUserManager)))
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseWebApi(config);
        }

        private static HttpConfiguration Register()
        {
            var config = new HttpConfiguration();
            var container = new UnityContainer();
        
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.DependencyResolver = new UnityDependencyResolver(container);

            return config;
        }
    }
}