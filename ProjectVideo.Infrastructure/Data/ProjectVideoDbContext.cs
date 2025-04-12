using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data.Entities;

namespace ProjectVideo.Infrastructure.Data
{
	public class ProjectVideoDbContext : DbContext
	{
		public DbSet<Proposal> Proposals { get; set; }
		public DbSet<ProposalLink> ProposalLinks { get; set; }
		public DbSet<ProposalTeamMember> ProposalTeamMembers { get; set; }
	}
}
