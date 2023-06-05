using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    public class ErrorsController : ControllerBase
    {
        //Add this so that you will not get error
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
