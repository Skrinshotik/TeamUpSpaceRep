using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeamUpSpace.Models;

namespace TeamUpSpace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IdeaGeneratorService.IdeaGenerator ideaGenerator = new IdeaGeneratorService.IdeaGenerator();
            string idea = ideaGenerator.GetIdea().Result;
            string name = ideaGenerator.GetIdeaName(idea).Result;
            Console.WriteLine(name+"\n"+idea);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}