using QuizApplicationService.Infrastructure;

namespace QuizApplicationService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(QuizApplicationServiceDbContext context)
        : base(context) { }
}
