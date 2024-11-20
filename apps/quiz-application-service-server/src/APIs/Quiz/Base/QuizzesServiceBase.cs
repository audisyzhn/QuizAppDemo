using Microsoft.EntityFrameworkCore;
using QuizApplicationService.APIs;
using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;
using QuizApplicationService.APIs.Errors;
using QuizApplicationService.APIs.Extensions;
using QuizApplicationService.Infrastructure;
using QuizApplicationService.Infrastructure.Models;

namespace QuizApplicationService.APIs;

public abstract class QuizzesServiceBase : IQuizzesService
{
    protected readonly QuizApplicationServiceDbContext _context;

    public QuizzesServiceBase(QuizApplicationServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Quiz
    /// </summary>
    public async Task<Quiz> CreateQuiz(QuizCreateInput createDto)
    {
        var quiz = new QuizDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            quiz.Id = createDto.Id;
        }

        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<QuizDbModel>(quiz.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Quiz
    /// </summary>
    public async Task DeleteQuiz(QuizWhereUniqueInput uniqueId)
    {
        var quiz = await _context.Quizzes.FindAsync(uniqueId.Id);
        if (quiz == null)
        {
            throw new NotFoundException();
        }

        _context.Quizzes.Remove(quiz);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Quizzes
    /// </summary>
    public async Task<List<Quiz>> Quizzes(QuizFindManyArgs findManyArgs)
    {
        var quizzes = await _context
            .Quizzes.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return quizzes.ConvertAll(quiz => quiz.ToDto());
    }

    /// <summary>
    /// Meta data about Quiz records
    /// </summary>
    public async Task<MetadataDto> QuizzesMeta(QuizFindManyArgs findManyArgs)
    {
        var count = await _context.Quizzes.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Quiz
    /// </summary>
    public async Task<Quiz> Quiz(QuizWhereUniqueInput uniqueId)
    {
        var quizzes = await this.Quizzes(
            new QuizFindManyArgs { Where = new QuizWhereInput { Id = uniqueId.Id } }
        );
        var quiz = quizzes.FirstOrDefault();
        if (quiz == null)
        {
            throw new NotFoundException();
        }

        return quiz;
    }

    /// <summary>
    /// Update one Quiz
    /// </summary>
    public async Task UpdateQuiz(QuizWhereUniqueInput uniqueId, QuizUpdateInput updateDto)
    {
        var quiz = updateDto.ToModel(uniqueId);

        _context.Entry(quiz).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Quizzes.Any(e => e.Id == quiz.Id))
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
