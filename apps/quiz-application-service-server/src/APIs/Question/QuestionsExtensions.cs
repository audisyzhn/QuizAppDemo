using QuizApplicationService.APIs.Dtos;
using QuizApplicationService.Infrastructure.Models;

namespace QuizApplicationService.APIs.Extensions;

public static class QuestionsExtensions
{
    public static Question ToDto(this QuestionDbModel model)
    {
        return new Question
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static QuestionDbModel ToModel(
        this QuestionUpdateInput updateDto,
        QuestionWhereUniqueInput uniqueId
    )
    {
        var question = new QuestionDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            question.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            question.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return question;
    }
}
