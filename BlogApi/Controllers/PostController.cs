using BlogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using BlogApi.Models.DTOs;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly string ConnectionString = "Server=localhost;Database=blog;User Id=root;Password=";
        [HttpGet]
        public List<Post> GetAllPost()
        {
            List<Post> posts = new();
            var connector = new MySqlConnection(ConnectionString);
            connector.Open();
            string sql = "SELECT * FROM blogpost";
            var cmd = new MySqlCommand(sql, connector);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var post = new Post
                {
                    Id = dr.GetInt32("Id"),
                    Title = dr.GetString("Title"),
                    Content = dr.GetString("Content"),
                    postTime = dr.GetDateTime("postTime"),
                    updateTime = dr.GetDateTime("updateTime"),
                    blogId = dr.GetInt32("blogId")
                };
                posts.Add(post);
            }
            connector.Close();
            return posts;
        }
    }
}
