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
        }// end GetNotes


        [HttpPost]
        [Route("AddNote")]
        public JsonResult AddNote([FromForm] string newNote) {

            string query = "insert into dbo.notes values(@newNote)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ToDoDBCon");

            SqlDataReader myReader;
            using (SqlConnection myconnection = new SqlConnection(sqlDataSource)) {
                myconnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, myconnection)) {

                    sqlCommand.Parameters.AddWithValue("@newNote", newNote);

                    myReader = sqlCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myconnection.Close();


                }
            }

            return new JsonResult("New Note Added Successfully.");
        }// end AddNote


        [HttpDelete]
        [Route("DeleteNote")]
        public JsonResult DeleteNote([FromForm] int id) {

            string query = "delete from dbo.notes where id = @id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ToDoDBCon");

            SqlDataReader myReader;
            using (SqlConnection myconnection = new SqlConnection(sqlDataSource)) {
                myconnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, myconnection)) {

                    sqlCommand.Parameters.AddWithValue("@id", id);

                    myReader = sqlCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myconnection.Close();


                }
            }

            return new JsonResult("Note Deleted Successfully.");
        }// end DeleteNote


        public IActionResult Index() {
            return View();
        }
    }
}
