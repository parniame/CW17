using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication8.Controllers
{
    public class BookController : Controller
    {
        public IDbConnection connection;
        public BookController(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
