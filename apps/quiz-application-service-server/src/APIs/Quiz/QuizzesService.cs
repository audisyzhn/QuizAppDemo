using QuizApplicationService.Infrastructure;

namespace QuizApplicationService.APIs;

public class QuizzesService : QuizzesServiceBase
{
    public QuizzesService(QuizApplicationServiceDbContext context)
        : base(context) { }
}
