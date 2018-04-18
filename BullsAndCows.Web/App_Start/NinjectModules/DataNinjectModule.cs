using BullsAndCows.Data;
using BullsAndCows.Data.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace BullsAndCows.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IBullsAndCowsDbContext>().To<BullsAndCowsDbContext>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
        }
    }
}