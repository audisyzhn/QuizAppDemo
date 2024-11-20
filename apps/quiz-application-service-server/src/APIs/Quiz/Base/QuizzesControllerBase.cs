using Microsoft.AspNetCore.Mvc;
using QuizApplicationService.APIs;
using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;
using QuizApplicationService.APIs.Errors;

namespace QuizApplicationService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class QuizzesControllerBase : ControllerBase
{
    protected readonly IQuizzesService _service;

    public QuizzesControllerBase(IQuizzesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Quiz
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Quiz>> CreateQuiz(QuizCreateInput input)
    {
        var quiz = await _service.CreateQuiz(input);

        return CreatedAtAction(nameof(Quiz), new { id = quiz.Id }, quiz);
    }

    /// <summary>
    /// Delete one Quiz
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteQuiz([FromRoute()] QuizWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteQuiz(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Quizzes
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Quiz>>> Quizzes([FromQuery()] QuizFindManyArgs filter)
    {
        return Ok(await _service.Quizzes(filter));
    }

    /// <summary>
    /// Meta data about Quiz records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> QuizzesMeta([FromQuery()] QuizFindManyArgs filter)
    {
        return Ok(await _service.QuizzesMeta(filter));
    }

    /// <summary>
    /// Get one Quiz
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Quiz>> Quiz([FromRoute()] QuizWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Quiz(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Quiz
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateQuiz(
        [FromRoute()] QuizWhereUniqueInput uniqueId,
        [FromQuery()] QuizUpdateInput quizUpdateDto
    )
    {
        try
        {
            await _service.UpdateQuiz(uniqueId, quizUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
