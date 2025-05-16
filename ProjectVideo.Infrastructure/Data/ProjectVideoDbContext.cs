using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Infrastructure.Data.Entities;
using System.Data;

namespace ProjectVideo.Infrastructure.Data
{
	public class ProjectVideoDbContext : DbContext
	{
		public ProjectVideoDbContext(DbContextOptions<ProjectVideoDbContext> options) : base(options) { }

		public DbSet<Proposal> Proposals { get; set; }
		public DbSet<ProposalLink> ProposalLinks { get; set; }
		public DbSet<ProposalTeamMember> ProposalTeamMembers { get; set; }
		public DbSet<EthnicTeamRole> EthnicTeamRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposal>(Configure);
        }

        private void Configure(EntityTypeBuilder<Proposal> builder)
        {
            builder.Property(x => x.Status).HasConversion(
                v => v.ToString(),
                v => (ProposalStatus)Enum.Parse(typeof(ProposalStatus), v));
        }
    }
}
