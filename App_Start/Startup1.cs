using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartup(typeof(MonthlyBillsWebApp.App_Start.Startup1))]

namespace MonthlyBillsWebApp.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/Login")
            };

            app.UseCookieAuthentication(cookieOptions);

            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                //ClientId = ConfigurationManager.AppSettings["461861078491-ma9ei04pm3s47393alado1j92f4n28m2.apps.googleusercontent.com"],
                //ClientSecret = ConfigurationManager.AppSettings["efqJJgac5XXj37dIgL2ST3pq"]
                ClientId = "461861078491-ma9ei04pm3s47393alado1j92f4n28m2.apps.googleusercontent.com",
                ClientSecret = "efqJJgac5XXj37dIgL2ST3pq"
            });
            //app.UseFacebookAuthentication(new FacebookOptions()
            //{
            //    AppId = "1777159912535412", //use the exact AppId
            //    AppSecret = "dd45f83d439c8be2fe6050e72029103e" //Use the exact AppSecret
            //});
        }

    }
}
