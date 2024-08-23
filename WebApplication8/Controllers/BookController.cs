using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication8.DAL;
using WebApplication8.Models;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await BookDAL.CreateAsync(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
