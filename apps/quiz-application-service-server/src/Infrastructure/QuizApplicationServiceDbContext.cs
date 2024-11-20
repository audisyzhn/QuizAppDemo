using Microsoft.EntityFrameworkCore;
using QuizApplicationService.Infrastructure.Models;

namespace QuizApplicationService.Infrastructure;

public class QuizApplicationServiceDbContext : DbContext
{
    public QuizApplicationServiceDbContext(
        DbContextOptions<QuizApplicationServiceDbContext> options
    )
        : base(options) { }

    public DbSet<QuestionDbModel> Questions { get; set; }

    public DbSet<QuizDbModel> Quizzes { get; set; }

    public DbSet<ResultDbModel> Results { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
