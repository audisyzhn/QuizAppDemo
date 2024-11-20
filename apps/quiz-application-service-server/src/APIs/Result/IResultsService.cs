using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;

namespace QuizApplicationService.APIs;

public interface IResultsService
{
    /// <summary>
    /// Create one Result
    /// </summary>
    public Task<Result> CreateResult(ResultCreateInput result);

    /// <summary>
    /// Delete one Result
    /// </summary>
    public Task DeleteResult(ResultWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Results
    /// </summary>
    public Task<List<Result>> Results(ResultFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Result records
    /// </summary>
    public Task<MetadataDto> ResultsMeta(ResultFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Result
    /// </summary>
    public Task<Result> Result(ResultWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Result
    /// </summary>
    public Task UpdateResult(ResultWhereUniqueInput uniqueId, ResultUpdateInput updateDto);
}
