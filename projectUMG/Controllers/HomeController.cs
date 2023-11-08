using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using projectUMG.Data;
using projectUMG.Models;


namespace projectUMG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext? _context;
    
        public HomeController(ILogger<HomeController> logger, DbContext? context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult Privacy()
        {
          
            return View();
        }
    
        public IActionResult Decrypt()
        {
            return View();
        }
    
        public ActionResult Auth()
        {
            return View();
        }
    
        
    
        public IActionResult TableUser()
        {
           
            return View();
        }
    
        public IActionResult Add()
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

