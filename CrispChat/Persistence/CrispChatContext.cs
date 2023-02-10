using CrispChat.Configurations;
using CrispChat.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CrispChat.Persistence
{
    public class CrispChatContext : DbContext
    {
        public CrispChatContext(DbContextOptions<CrispChatContext> options) : base(options)
        {
        }

        public DbSet<Config> Configs { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Routing> Routings { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Visitor> Visitors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ConversationsConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new MetaConfiguration());
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new RoutingConfiguration());
            modelBuilder.ApplyConfiguration(new SegmentConfiguration());
            modelBuilder.ApplyConfiguration(new VisitorConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            var modified = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified ||
                            e.State == EntityState.Added ||
                            e.State == EntityState.Deleted);

            foreach (var item in modified)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        if (item.Entity is IAuditTable addedEntity)
                        {
                            addedEntity.CreatedDate = DateTime.UtcNow;
                            item.State = EntityState.Added;
                        }
                        break;

                    case EntityState.Modified:
                        Entry(item.Entity).Property("Id").IsModified = false;
                        if (item.Entity is IAuditTable modifiedEntity)
                        {
                            modifiedEntity.ModifiedDate = DateTime.UtcNow;
                            item.State = EntityState.Modified;
                        }
                        break;
                }
            }

            var result = base.SaveChangesAsync(cancellationToken).Result;

            return result;
        }
    }
}
