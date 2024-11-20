using Microsoft.AspNetCore.Mvc;

namespace QuizApplicationService.APIs;

[ApiController()]
public class QuizzesController : QuizzesControllerBase
{
    public QuizzesController(IQuizzesService service)
        : base(service) { }
}
