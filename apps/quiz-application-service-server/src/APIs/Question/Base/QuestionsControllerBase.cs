using Microsoft.AspNetCore.Mvc;
using QuizApplicationService.APIs;
using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;
using QuizApplicationService.APIs.Errors;

namespace QuizApplicationService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class QuestionsControllerBase : ControllerBase
{
    protected readonly IQuestionsService _service;

    public QuestionsControllerBase(IQuestionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Question
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Question>> CreateQuestion(QuestionCreateInput input)
    {
        var question = await _service.CreateQuestion(input);

        return CreatedAtAction(nameof(Question), new { id = question.Id }, question);
    }

    /// <summary>
    /// Delete one Question
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteQuestion([FromRoute()] QuestionWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteQuestion(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Questions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Question>>> Questions(
        [FromQuery()] QuestionFindManyArgs filter
    )
    {
        return Ok(await _service.Questions(filter));
    }

    /// <summary>
    /// Meta data about Question records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> QuestionsMeta(
        [FromQuery()] QuestionFindManyArgs filter
    )
    {
        return Ok(await _service.QuestionsMeta(filter));
    }

    /// <summary>
    /// Get one Question
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Question>> Question(
        [FromRoute()] QuestionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Question(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Question
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateQuestion(
        [FromRoute()] QuestionWhereUniqueInput uniqueId,
        [FromQuery()] QuestionUpdateInput questionUpdateDto
    )
    {
        try
        {
            await _service.UpdateQuestion(uniqueId, questionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
