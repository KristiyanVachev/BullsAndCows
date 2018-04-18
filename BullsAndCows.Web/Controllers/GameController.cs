using System.Web.Mvc;
using Bytes2you.Validation;
using BullsAndCows.Services.Contracts;
using BullsAndCows.Web.Models;
using BullsAndCows.Web.Models.Game;

namespace BullsAndCows.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService gameService;
        private readonly IViewModelFactory viewModelFactory;

        public GameController(IGameService gameService, IViewModelFactory viewModelFactory)
        {
            Guard.WhenArgument(gameService, "GameService cannot be null").IsNull().Throw();
            Guard.WhenArgument(viewModelFactory, "ViewModelFactory cannot be null").IsNull().Throw();

            this.gameService = gameService;
            this.viewModelFactory = viewModelFactory;
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Game(GameViewModel viewModel)
        {
            var userIsOwner = this.gameService.UserIsOwner(viewModel.Id);

            //TODO Redirect to unauthorized page (create one first)
            if (!userIsOwner)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var game = this.gameService.GetGameById(viewModel.Id);

            var gameViewModel = this.viewModelFactory.CreateDetailedGameViewModel(game.Id, 
                game.IsFinished,
                game.IsPlayerWinner,
                game.Turn,
                game.PlayerNumber,
                game.ComputerNumber,
                game.Guesses);

            return View("Game", gameViewModel);
        }

        public ActionResult New(NewGameViewModel viewModel)
        {
            //Validation - number must be 4 digits 

            var newGame = this.gameService.NewGame(viewModel.Number);

            var gameViewModel = this.viewModelFactory.CreateGameViewModel(newGame.Id);

            return View("Game", gameViewModel);
        }

        public RedirectToRouteResult Guess(GameViewModel viewModel)
        {
            if (viewModel.Guess != null)
            {
                //Check player's guess
                var playerGuess = this.gameService.MakeAGuess(viewModel.Id, viewModel.Guess, true);

                //TODO: Extract constant
                //If the player has 4 bulls, he wins
                if (playerGuess.Bulls == 4)
                {
                    this.gameService.FinishGame(viewModel.Id, true);
                }
                //If the player hasn't won, generate a guess for the computer
                else
                {
                    var generatedComputerGuess = this.gameService.GenerateGuess();

                    var computerGuess = this.gameService.MakeAGuess(viewModel.Id, generatedComputerGuess, false);

                    if (computerGuess.Bulls == 4)
                    {
                        this.gameService.FinishGame(viewModel.Id, false);
                    }
                }
            }

            var gameViewModel = this.viewModelFactory.CreateGameViewModel(viewModel.Id);

            return this.RedirectToAction("Game", gameViewModel);
        }
    }
}