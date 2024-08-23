using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using WebApplication8.Models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;

namespace WebApplication8.DAL
{
    public class BookDAL
    {
        public IDbConnection connection;
        public BookDAL(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            IEnumerable<Book> books;
            using (IDbConnection conn = connection)
            {
                var queryString = "SELECT * FROM Book;";
                //conn.Open();
                books = await conn.QueryAsync<Book>(queryString);
               
            }
             return books;
        }
        
        public async Task CreateAsync(Book book)
        {
            using(IDbConnection conn = connection)
            {
                var Sql = @"INSERT INTO Book(Title, Author, Genre, Price, PublishDate)
                          VALUES (@Title, @Author, @Genre, @Price, @PublishDate) ";
                await conn.ExecuteAsync(Sql, book);
            }
        }
    }
}
