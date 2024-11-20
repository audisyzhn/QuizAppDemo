using Microsoft.AspNetCore.Mvc;

namespace QuizApplicationService.APIs;

[ApiController()]
public class QuestionsController : QuestionsControllerBase
{
    public QuestionsController(IQuestionsService service)
        : base(service) { }
}
