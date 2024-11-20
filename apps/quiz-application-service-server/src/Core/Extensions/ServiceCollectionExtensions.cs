using QuizApplicationService.APIs;

namespace QuizApplicationService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IQuestionsService, QuestionsService>();
        services.AddScoped<IQuizzesService, QuizzesService>();
        services.AddScoped<IResultsService, ResultsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
