using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication8.DAL;

namespace WebApplication8.Controllers
{

    public class BookController : Controller
    {
        public BookDALADO BookDALADO { get; set; }
        public BookDAL BookDAL {  get; set; }
        public BookController(IConfiguration configuration)
        {
              //BookDALADO = new BookDALADO(configuration);
              BookDAL = new BookDAL(configuration);
        }
        

        public async Task<IActionResult> Index()
        {
            var books = await BookDAL.GetAll();
          
            return View(books);
        }
    }
}
