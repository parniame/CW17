using System.Data.SqlClient;
using System.Data;
using WebApplication8.Models;

namespace WebApplication8.DAL
{
    public class BookDALADO
    {
        public IDbConnection connection;
        public BookDALADO(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public IEnumerable<Book> GetAll()
        {
            var books = new List<Book>();
            using(SqlConnection conn = new SqlConnection(connection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Book;",conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var book = new Book();
                    book.BookID = Convert.ToInt32(reader["BookID"]);
                    book.Title = reader["Title"].ToString();
                    book.Author = reader["Author"].ToString();
                    book.Genre = reader["Genre"].ToString();
                    book.Price = Convert.ToDecimal(reader["Price"]);
                    book.PublishDate = Convert.ToDateTime(reader["PublishDate"]);

                    books.Add(book);
                }
                return books;
            }
        }
    }
}
