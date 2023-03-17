using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PostHive.Data;
using PostHive.Model;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PostHive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }

        // GET: <User>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Users);
        }


        // GET <User>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_db.Users.Find(id));
        }

        // POST api/<User>
        [HttpPost]
        public IActionResult Post([FromBody] UserPostModel userModel)
        {
            var user = new User(userModel.Id, userModel.Name);
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        // // PUT api/<User>/5
        // [HttpPut]
        // public void Put(string id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE api/<User>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
