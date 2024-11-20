using Microsoft.AspNetCore.Mvc;

namespace QuizApplicationService.APIs;

[ApiController()]
public class ResultsController : ResultsControllerBase
{
    public ResultsController(IResultsService service)
        : base(service) { }
}
