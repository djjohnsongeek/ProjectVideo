using Microsoft.EntityFrameworkCore;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Infrastructure.Data;

namespace ProjectVideo.Infrastructure.Interactors;

public class Interactor
{
	protected readonly ProjectVideoDbContext _dbContext;

	public Interactor(ProjectVideoDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	protected async Task UpdateChanges(InteractorResult result, string errorContext)
	{
		try
		{
			int changeCount = await _dbContext.SaveChangesAsync();
			if (changeCount == 0)
			{
				result.AddError($"Unknown error. {errorContext}");
			}
		}
		catch (DbUpdateException ex)
		{
			result.AddError($"Database error. {errorContext}");
			// TODO Log ex
		}
	}
}
