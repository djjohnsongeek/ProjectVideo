using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class ProposalUpdateInteractor
	{
		private ProjectVideoDbContext _dbContext;

		public ProposalUpdateInteractor(ProjectVideoDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
