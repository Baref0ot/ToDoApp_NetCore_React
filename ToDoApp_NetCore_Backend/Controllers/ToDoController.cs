using Microsoft.AspNetCore.Mvc;

namespace ToDoApp_NetCore_Backend.Controllers {
    public class ToDoController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
