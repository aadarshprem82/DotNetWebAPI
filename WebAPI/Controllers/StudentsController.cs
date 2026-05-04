using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase{

        [HttpGet]
        public IActionResult GetAllStudent(){
            string[] studentNames = ["first", "second", "third"];
            return Ok(studentNames);
        }
    }
}