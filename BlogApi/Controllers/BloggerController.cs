using BlogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        private readonly string ConnectionString = "Server=localhost;Database=blog;User Id=root;Password=";
        [HttpGet]
        public List<Blogger> GetAllBloggers()
        {
            List<Blogger> bloggers = new();
            var connector = new MySqlConnection(ConnectionString);
            connector.Open();
            string sql = "SELECT * FROM blogger";
            var cmd = new MySqlCommand(sql, connector);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var blogger = new Blogger
                {
                    Id = dr.GetInt32("Id"),
                    Name = dr.GetString("Name"),
                    Email = dr.GetString("Email"),
                    Age = dr.GetInt32("Age"),
                    Password = dr.GetString("Password"),
                    RegistrationTime = dr.GetDateTime("RegistrationTime")
                };
                bloggers.Add(blogger);
            }
            connector.Close();
            return bloggers;
        }
        [HttpPost]
        public object AddNewBlogger(Blogger blogger)
        {
            return null;
        }
        [HttpPut]
        public object UpdateBlogger(int id, Blogger blogger)
        {
            return null;
        }
        [HttpDelete]
        public object DeleteBlogger(int id)
        {
            return null;
        }
    }
}
