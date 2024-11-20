using QuizApplicationService.Infrastructure;

namespace QuizApplicationService.APIs;

public class QuestionsService : QuestionsServiceBase
{
    public QuestionsService(QuizApplicationServiceDbContext context)
        : base(context) { }
}
