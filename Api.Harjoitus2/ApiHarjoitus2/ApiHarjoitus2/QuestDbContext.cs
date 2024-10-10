using Microsoft.EntityFrameworkCore;

public class QuestDbContext : DbContext
{
    public QuestDbContext(DbContextOptions<QuestDbContext> options) : base(options) { }

    public DbSet<Quest> Quests { get; set; }

    private void SeedData(QuestDbContext context)
    {
        if (!context.Quests.Any())
        {
            context.Quests.Add(new Quest { Id = 1, Name = "Tuhoa rotat", Description = "Tapa 3 rottaa ja tuo nahat minulle.", Reward = 50 });
            context.Quests.Add(new Quest { Id = 2, Name = "Etsi Viljo", Description = "Onkos Viljoo näkyny.", Reward = 100 });
            context.SaveChanges();
        }
    }

}
