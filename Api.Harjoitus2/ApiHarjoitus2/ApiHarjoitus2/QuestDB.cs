using Microsoft.EntityFrameworkCore;

namespace ApiHarjoitus2
{
    public class QuestDB : DbContext // Inherit from DbContext
    {
        public QuestDB(DbContextOptions<QuestDB> options)
            : base(options) { }

        public DbSet<Quest> Todos { get; set; } // Use 'DbSet' correctly
    }
}
