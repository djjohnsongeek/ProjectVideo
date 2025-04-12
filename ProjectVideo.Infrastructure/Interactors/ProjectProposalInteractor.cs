using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVideo.Infrastructure.Interactors
{
	public class ProjectProposalInteractor
	{
		private ProjectVideoDbContext _dbContext;

		public ProjectProposalInteractor(ProjectVideoDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
