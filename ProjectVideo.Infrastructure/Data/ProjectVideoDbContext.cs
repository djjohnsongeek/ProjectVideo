using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.IdentityModel.Tokens;
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
        public DbSet<ProjectProposalFormLocalization> ProjectProposalFormLocalizations { get; set; }

        // Users
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Role> Roles { get; set; }
        public DbSet<EthnicTeamRole> EthnicTeamRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposal>(Configure);
            modelBuilder.Entity<User>(Configure);
            modelBuilder.Entity<UserRole>(Configure);
            modelBuilder.Entity<Role>(Configure);
        }

        private void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
        }

        private void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasOne(x => x.User)
                .WithMany();

            builder.HasOne(x => x.Role)
                .WithMany();
        }

        private void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasMany(x => x.Roles)
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
