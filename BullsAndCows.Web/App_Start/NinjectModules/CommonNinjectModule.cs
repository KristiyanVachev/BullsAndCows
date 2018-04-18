using BullsAndCows.Commom;
using BullsAndCows.Commom.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace BullsAndCows.Web.App_Start.NinjectModules
{
    public class CommonNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDateTimeProvider>().To<DateTimeProvider>().InRequestScope();
            this.Bind<IHttpContextProvider>().To<HttpContextProvider>().InSingletonScope();
        }
    }
}