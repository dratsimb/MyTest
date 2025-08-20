using Microsoft.AspNetCore.Mvc;
using Safran.Data.Users;

namespace Safran.Api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUserRepository _userRepository;

        public User CurrentUser { get; private set; }

        public BaseController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public void OnActionExecuting(HttpContext context)
        {
            // analyser le json ici

            CurrentUser = new()
            {
                Id =  Guid.NewGuid(),
                Email = "toto.@a.b",
                LastName = "a",
                Login = "dd",
                Name = "b",
            };
        }
    }
}
