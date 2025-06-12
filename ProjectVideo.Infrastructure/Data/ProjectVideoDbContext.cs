using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Data
{
	public class ProjectVideoDbContext : DbContext
	{
		public ProjectVideoDbContext(DbContextOptions<ProjectVideoDbContext> options) : base(options) { }

        // Proposals
		public DbSet<Proposal> Proposals { get; set; }
		public DbSet<ProposalLink> ProposalLinks { get; set; }
		public DbSet<ProposalMember> ProposalMembers { get; set; }

        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposal>(Configure);
            modelBuilder.Entity<User>(Configure);
        }

        private void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<UserRole>();
        }

        private void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.Property(x => x.Status).HasConversion(
                v => v.ToString(),
                v => (ProposalStatus)Enum.Parse(typeof(ProposalStatus), v));
        }
    }
}
