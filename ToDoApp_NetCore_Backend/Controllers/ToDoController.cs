using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ToDoApp_NetCore_Backend.Controllers {
    public class ToDoController : Controller {


        private IConfiguration _configuration;

        public ToDoController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes() {

            string query = "select * from dbo.notes";
            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ToDoDBCon");

            SqlDataReader myReader;


            return Json();
        }

        public IActionResult Index() {
            return View();
        }
    }
}
