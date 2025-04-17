using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Data
{
	public class ProjectVideoDbContext : DbContext
	{
		public ProjectVideoDbContext(DbContextOptions<ProjectVideoDbContext> options) : base(options) { }

		public DbSet<Proposal> Proposals { get; set; }
		public DbSet<ProposalLink> ProposalLinks { get; set; }
		public DbSet<ProposalTeamMember> ProposalTeamMembers { get; set; }

		public DbSet<EthnicTeamRole> EthnicTeamRoles { get; set; }

	}
}
