using Microsoft.AspNetCore.Mvc;

namespace ENB.Students.Registration.Mvc.Controllers
{
    public class ErrorsController : Controller
    {
        
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
