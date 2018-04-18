using BullsAndCows.Auth;
using BullsAndCows.Auth.Contracts;
using Ninject.Modules;

namespace BullsAndCows.Web.App_Start.NinjectModules
{
    public class AuthNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthenticationProvider>().To<AuthenticationProvider>().InSingletonScope();
        }
    }
}