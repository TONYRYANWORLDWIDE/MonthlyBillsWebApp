using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IO;
using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using System.Configuration;

//using System.Data.Entity;

[assembly: OwinStartup(typeof(MonthlyBillsWebApp.Startup))]

namespace MonthlyBillsWebApp
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var cookieOptions = new CookieAuthenticationOptions
            //{
            //    LoginPath = new PathString("/Account/Login")
            //};

            //app.UseCookieAuthentication(cookieOptions);

            //app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

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


        //public void Configuration(IAppBuilder app)
        //{

        //app.UseGoogleAuthentication(
        //clientId: "461861078491-ma9ei04pm3s47393alado1j92f4n28m2.apps.googleusercontent.com",
        //clientSecret: "efqJJgac5XXj37dIgL2ST3pq");

        //app.Run(context =>
        //{
        //    string t = DateTime.Now.Millisecond.ToString();
        //    return context.Response.WriteAsync(t + " Owin App");
        //});
    }
        //ApplicationDbContext dbcont = new ApplicationDbContext();

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        // Configure the db context and user manager to use a single instance per request
        //app.CreatePerOwinContext(ApplicationDbContext.Create);
        //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

        // Enable the application to use a cookie to store information for the signed in user
        // and to use a cookie to temporarily store information about a user logging in with a third party login provider
        // Configure the sign in cookie

        //app.UseCookieAuthentication(new CookieAuthenticationOptions
        //{
        //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        //    LoginPath = new PathString("/Account/Login"),
        //    Provider = new CookieAuthenticationProvider
        //    {
        //        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
        //            validateInterval: TimeSpan.FromMinutes(30),
        //            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        //    }
        //});

        // app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        // Uncomment the following lines to enable logging in with third party login providers
        //app.UseMicrosoftAccountAuthentication(
        //    clientId: "",
        //    clientSecret: "");

        //app.UseTwitterAuthentication(
        //   consumerKey: "",
        //   consumerSecret: "");

        //app.UseFacebookAuthentication(
        //   appId: "",
        //   appSecret: "");




        

    
}


