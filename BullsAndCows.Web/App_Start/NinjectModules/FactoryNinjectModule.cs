using Ninject.Modules;
using BullsAndCows.Factories;
using BullsAndCows.Web.Models;
using Ninject.Extensions.Factory;

namespace BullsAndCows.Web.App_Start.NinjectModules
{
    public class FactoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IGameFactory>().ToFactory().InSingletonScope();
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();

            this.Bind<IViewModelFactory>().ToFactory().InSingletonScope();
        }
    }
}