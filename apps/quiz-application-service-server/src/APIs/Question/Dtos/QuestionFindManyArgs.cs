using Microsoft.AspNetCore.Mvc;
using QuizApplicationService.APIs.Common;
using QuizApplicationService.Infrastructure.Models;

namespace QuizApplicationService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class QuestionFindManyArgs : FindManyInput<Question, QuestionWhereInput> { }