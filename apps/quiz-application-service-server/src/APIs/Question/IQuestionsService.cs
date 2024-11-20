using QuizApplicationService.APIs.Common;
using QuizApplicationService.APIs.Dtos;

namespace QuizApplicationService.APIs;

public interface IQuestionsService
{
    /// <summary>
    /// Create one Question
    /// </summary>
    public Task<Question> CreateQuestion(QuestionCreateInput question);

    /// <summary>
    /// Delete one Question
    /// </summary>
    public Task DeleteQuestion(QuestionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Questions
    /// </summary>
    public Task<List<Question>> Questions(QuestionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Question records
    /// </summary>
    public Task<MetadataDto> QuestionsMeta(QuestionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Question
    /// </summary>
    public Task<Question> Question(QuestionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Question
    /// </summary>
    public Task UpdateQuestion(QuestionWhereUniqueInput uniqueId, QuestionUpdateInput updateDto);
}
