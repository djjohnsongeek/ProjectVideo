using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Data
{
	public class ProjectVideoDbContext : DbContext
	{
		public DbSet<ProjectProposal> ProjectProposals { get; set; }
		public DbSet<ProjectProposalLink> ProjectProposalLinks { get; set; }
		public DbSet<ProjectProposalTeamMember> ProjectProposalTeamMembers { get; set; }
	}
}
