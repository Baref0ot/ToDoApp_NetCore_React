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
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ToDoDBCon");

            SqlDataReader myReader;
            using (SqlConnection myconnection = new SqlConnection(sqlDataSource)) {
                myconnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, myconnection)) {
                    myReader = sqlCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myconnection.Close();


                }
            }

                return new JsonResult(table);
        }

        public IActionResult Index() {
            return View();
        }
    }
}
