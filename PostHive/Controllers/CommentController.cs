using Microsoft.AspNetCore.Mvc;
using PostHive.Data;
using PostHive.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostHive.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CommentController(AppDbContext db)
        {
            _db = db;
        }
        // GET: <CommentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Comments);
        }

        // GET <CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.Comments.Find(id));
        }

        // POST <CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] CommentPostModel model)
        {
            var comment = model.RepliedToCommentId is null or 0 
                ? new Comment(model.Content, model.AuthorId, model.PostId) 
                : new Comment(model.Content, model.AuthorId, model.PostId, model.RepliedToCommentId);
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return Ok(comment);
        }

        // // PUT <CommentController>/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE <CommentController>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
