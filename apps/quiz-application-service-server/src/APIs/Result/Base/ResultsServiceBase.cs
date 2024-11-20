using Microsoft.EntityFrameworkCore;
using QuizApplicationService.APIs;
using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;
using QuizApplicationService.APIs.Errors;
using QuizApplicationService.APIs.Extensions;
using QuizApplicationService.Infrastructure;
using QuizApplicationService.Infrastructure.Models;

namespace QuizApplicationService.APIs;

public abstract class ResultsServiceBase : IResultsService
{
    protected readonly QuizApplicationServiceDbContext _context;

    public ResultsServiceBase(QuizApplicationServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Result
    /// </summary>
    public async Task<Result> CreateResult(ResultCreateInput createDto)
    {
        var result = new ResultDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            result.Id = createDto.Id;
        }

        _context.Results.Add(result);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ResultDbModel>(result.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Result
    /// </summary>
    public async Task DeleteResult(ResultWhereUniqueInput uniqueId)
    {
        var result = await _context.Results.FindAsync(uniqueId.Id);
        if (result == null)
        {
            throw new NotFoundException();
        }

        _context.Results.Remove(result);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Results
    /// </summary>
    public async Task<List<Result>> Results(ResultFindManyArgs findManyArgs)
    {
        var results = await _context
            .Results.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return results.ConvertAll(result => result.ToDto());
    }

    /// <summary>
    /// Meta data about Result records
    /// </summary>
    public async Task<MetadataDto> ResultsMeta(ResultFindManyArgs findManyArgs)
    {
        var count = await _context.Results.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Result
    /// </summary>
    public async Task<Result> Result(ResultWhereUniqueInput uniqueId)
    {
        var results = await this.Results(
            new ResultFindManyArgs { Where = new ResultWhereInput { Id = uniqueId.Id } }
        );
        var result = results.FirstOrDefault();
        if (result == null)
        {
            throw new NotFoundException();
        }

        return result;
    }

    /// <summary>
    /// Update one Result
    /// </summary>
    public async Task UpdateResult(ResultWhereUniqueInput uniqueId, ResultUpdateInput updateDto)
    {
        var result = updateDto.ToModel(uniqueId);

        _context.Entry(result).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Results.Any(e => e.Id == result.Id))
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
