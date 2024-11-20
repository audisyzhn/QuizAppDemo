using QuizApplicationService.APIs.Dtos;
using QuizApplicationService.Infrastructure.Models;

namespace QuizApplicationService.APIs.Extensions;

public static class QuizzesExtensions
{
    public static Quiz ToDto(this QuizDbModel model)
    {
        return new Quiz
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static QuizDbModel ToModel(this QuizUpdateInput updateDto, QuizWhereUniqueInput uniqueId)
    {
        var quiz = new QuizDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            quiz.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            quiz.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return quiz;
    }
}
