using QuizApplicationService.Infrastructure;

namespace QuizApplicationService.APIs;

public class ResultsService : ResultsServiceBase
{
    public ResultsService(QuizApplicationServiceDbContext context)
        : base(context) { }
}
