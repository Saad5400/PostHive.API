using Microsoft.AspNetCore.Mvc;
using PostHive.Data;
using PostHive.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostHive.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PostController(AppDbContext db)
        {
            _db = db;
        }
        // GET: <PostController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Posts);
        }

        // GET <PostController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.Posts.Find(id));
        }

        // POST <PostController>
        [HttpPost]
        public IActionResult Post([FromBody] PostPostModel model)
        {
            var post = new Post(model.Title, model.Content, model.AuthorId);
            _db.Posts.Add(post);
            _db.SaveChangesAsync();
            return Ok(post);
        }

        // // PUT <PostController>/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE <PostController>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
