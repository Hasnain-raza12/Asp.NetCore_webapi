using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{

    //[Route("api/[controller]")]
    //[ApiController]
    //public class UsersController : ControllerBase
    //{
    //    private readonly UserService service;
    //    public UsersController(UserService userService)
    //    {

    //        service = userService;
    //    }

    //    [HttpGet]
    //    public ActionResult<List<User>> GetUsers()
    //    {
    //        return service.GetUsers();
    //    }

    //    [HttpGet("{id:length(24)}")]
    //    public ActionResult<User> Getuser(string id)
    //    {
    //        var user = service.GetUser(id);
    //        return user;

    //    }
    //    [HttpPost]
    //    public ActionResult<User> Create(User user)
    //    {
    //        service.Create(user);
    //        return user;

    //    }
    //    [AllowAnonymous]
    //    [HttpPost]
    //    [Route("authenticate")]
    //    public ActionResult Login([FromBody] User user)
    //    {
    //        var token = service.Authenticate(user.Email, user.Password);

    //        if (token==null)
    //        {
    //            return Unauthorized();
    //        }
    //        return Ok(new { token, user });
    //    }

    //}
}
