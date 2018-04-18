using BullsAndCows.Services.Contracts;
using Bytes2you.Validation;
using System.Web.Mvc;

namespace BullsAndCows.Web.Controllers
{
    public class RankListController : Controller
    {
        private readonly IRankListService rankListService;

        public RankListController(IRankListService rankListService)
        {
            Guard.WhenArgument(rankListService, "RankListService cannot be null").IsNull().Throw();

            this.rankListService = rankListService;
        }

        // GET: RankList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Top()
        {
            var topGames = this.rankListService.GetTopPlayerGames(25);

            return View("Top", topGames);
        }
    }
}