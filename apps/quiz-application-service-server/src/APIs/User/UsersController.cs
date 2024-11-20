using Microsoft.AspNetCore.Mvc;

namespace QuizApplicationService.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
