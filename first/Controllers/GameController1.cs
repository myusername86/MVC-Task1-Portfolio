using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using first.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace first.Controllers
{
    public class GameController : Controller
    {
        private const string SessionKeyNumber = "_Number";
        private const int MinNumber = 1;
        private const int MaxNumber = 100;

        public IActionResult Index()
        {
            // Instantiate the GameModel
            var model = new GameModel();

            // Check if there is already a number in the session
            if (HttpContext.Session.GetInt32(SessionKeyNumber) == null)
            {
                // Generate a random number and save it in the session
                Random random = new Random();
                int number = random.Next(MinNumber, MaxNumber + 1);
                HttpContext.Session.SetInt32(SessionKeyNumber, number);
                model.Number = number;
            }
            else
            {
                model.Number = (int)HttpContext.Session.GetInt32(SessionKeyNumber);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(GameModel model)
        {
            int? number = HttpContext.Session.GetInt32(SessionKeyNumber);

            if (number == null)
            {
                // Redirect to Index if session is null
                return RedirectToAction("Index");
            }

            // Compare the user's guess with the number in session
            if (model.UserGuess == number)
            {
                model.Message = "Congratulations! You guessed the correct number.";
                // Generate a new number and save it in the session
                Random random = new Random();
                number = random.Next(MinNumber, MaxNumber + 1);
                HttpContext.Session.SetInt32(SessionKeyNumber, number.Value);
            }
            else if (model.UserGuess < number)
            {
                model.Message = "Your guess is too low.";
            }
            else
            {
                model.Message = "Your guess is too high.";
            }

            // Return the model to the view
            return View(model);
        }
    }
}
