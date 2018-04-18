using BullsAndCows.Services;
using BullsAndCows.Services.Contracts;
using BullsAndCows.Services.Utilities;
using BullsAndCows.Services.Utilities.Contracts;
using Ninject.Modules;

namespace BullsAndCows.Web.App_Start.NinjectModules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IGameService>().To<GameService>();
            this.Bind<IRankListService>().To<RankListService>();

            this.Bind<IGameUtility>().To<GameUtility>();
            this.Bind<IUserUtility>().To<UserUtility>();
        }
    }
}