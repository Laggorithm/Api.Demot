using Microsoft.EntityFrameworkCore;

public class QuestDbContext : DbContext
{
    public QuestDbContext(DbContextOptions<QuestDbContext> options) : base(options) { }

    public DbSet<Quest> Quests { get; set; }
}
