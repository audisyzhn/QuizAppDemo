using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;

namespace QuizApplicationService.APIs;

public interface IQuizzesService
{
    /// <summary>
    /// Create one Quiz
    /// </summary>
    public Task<Quiz> CreateQuiz(QuizCreateInput quiz);

    /// <summary>
    /// Delete one Quiz
    /// </summary>
    public Task DeleteQuiz(QuizWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Quizzes
    /// </summary>
    public Task<List<Quiz>> Quizzes(QuizFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Quiz records
    /// </summary>
    public Task<MetadataDto> QuizzesMeta(QuizFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Quiz
    /// </summary>
    public Task<Quiz> Quiz(QuizWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Quiz
    /// </summary>
    public Task UpdateQuiz(QuizWhereUniqueInput uniqueId, QuizUpdateInput updateDto);
}
