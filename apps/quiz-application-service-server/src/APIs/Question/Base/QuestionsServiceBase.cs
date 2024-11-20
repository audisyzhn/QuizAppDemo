using Microsoft.EntityFrameworkCore;
using QuizApplicationService.APIs;
using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;
using QuizApplicationService.APIs.Errors;
using QuizApplicationService.APIs.Extensions;
using QuizApplicationService.Infrastructure;
using QuizApplicationService.Infrastructure.Models;

namespace QuizApplicationService.APIs;

public abstract class QuestionsServiceBase : IQuestionsService
{
    protected readonly QuizApplicationServiceDbContext _context;

    public QuestionsServiceBase(QuizApplicationServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Question
    /// </summary>
    public async Task<Question> CreateQuestion(QuestionCreateInput createDto)
    {
        var question = new QuestionDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            question.Id = createDto.Id;
        }

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<QuestionDbModel>(question.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Question
    /// </summary>
    public async Task DeleteQuestion(QuestionWhereUniqueInput uniqueId)
    {
        var question = await _context.Questions.FindAsync(uniqueId.Id);
        if (question == null)
        {
            throw new NotFoundException();
        }

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Questions
    /// </summary>
    public async Task<List<Question>> Questions(QuestionFindManyArgs findManyArgs)
    {
        var questions = await _context
            .Questions.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return questions.ConvertAll(question => question.ToDto());
    }

    /// <summary>
    /// Meta data about Question records
    /// </summary>
    public async Task<MetadataDto> QuestionsMeta(QuestionFindManyArgs findManyArgs)
    {
        var count = await _context.Questions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Question
    /// </summary>
    public async Task<Question> Question(QuestionWhereUniqueInput uniqueId)
    {
        var questions = await this.Questions(
            new QuestionFindManyArgs { Where = new QuestionWhereInput { Id = uniqueId.Id } }
        );
        var question = questions.FirstOrDefault();
        if (question == null)
        {
            throw new NotFoundException();
        }

        return question;
    }

    /// <summary>
    /// Update one Question
    /// </summary>
    public async Task UpdateQuestion(
        QuestionWhereUniqueInput uniqueId,
        QuestionUpdateInput updateDto
    )
    {
        var question = updateDto.ToModel(uniqueId);

        _context.Entry(question).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Questions.Any(e => e.Id == question.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
