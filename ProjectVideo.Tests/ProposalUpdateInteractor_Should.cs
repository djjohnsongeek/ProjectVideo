using Microsoft.EntityFrameworkCore;
using ProjectVideo.Core.Interactors;
using ProjectVideo.Core.Interactors.DataObjects;
using ProjectVideo.Core.Interactors.Proposal;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;
using ProjectVideo.Infrastructure.Interactors;
using ProjectVideo.Tests.Setup;

namespace ProjectVideo.Tests
{
	[Collection(nameof(RepoCollection))]
	public class ProposalUpdateInteractor_Should : IAsyncLifetime
	{
        private readonly RepoCollectionFixture _fixture;
        private readonly IProposalUpdateInteractor _updateInteractor;
		private readonly ProjectVideoDbContext _dbContext;

		public ProposalUpdateInteractor_Should(RepoCollectionFixture repofixture)
        {
            _fixture = repofixture;
            _dbContext = new ProjectVideoDbContext(_fixture.GetDbContextOptions());
            _updateInteractor = new ProposalUpdateInteractor(_dbContext);
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            await _fixture.RestoreToInitialState();
        }

        [Fact]
		public async Task Successfully_Create_Proposal()
		{
			var inputData = new CreateProposalInput
			{
				ContactEmail = "danieleejohnson@gmail.com",
				ContactName = "Daniel",
				OrganizationName = "Software For The King",
				ProjectTitle = "My Project",
				OrganizationHistory = "Here is our history ...",
				StaffArePaid = false,
				TargetAudience = "Missionay Organizations",
				KeyObjectives = "Support Gospel Ministries with Software.",
				ProjectTimeFrameTotal = 2,
				ProjectTimeFrameInterval = "Years",
				Methods = "Custom Coded Applications",
				PlannedVideos = "None so far.",
				CurrentEquipment = "Lenovo Laptop, Pixel 6 phone.",
				HasAudioSpace = true,
				AudioSpaceDescription = "Just my bedroom.",
				HasComputer = true,
				ComputerDescription = "Lenovo Loq Laptop. 8 cores, 16 processors and a RTX 4050 GPU.",
				EstimatedProjectCost = 5000,
				ContactPhoneNumber = "123-456-7890",

                Links = [
					new ProposalLinkDetails
					{
						Name = "Google Link",
						Url = "https://www.google.com"
					}
				],
				Members = [
					new ProposalMemberDetails
					{
						Name = "Daniel",
						Role = "Lead Developer"
					},
					new ProposalMemberDetails {
						Name = "Silas",
						Role = "Lead Assistant"
					}
				]
			};

			InteractorResult result = await _updateInteractor.CreateProposal(inputData);

			Assert.NotNull(result);
			Assert.Empty(result.Errors);
			Assert.False(result.HasErrors);

			List<Proposal> proposals = await _dbContext.Proposals
				.Include(p => p.Members)
				.Include(p => p.Links)
				.ToListAsync();

			Assert.Single(proposals);
			Assert.Equal("Daniel", proposals[0].ContactName);
			Assert.Equal("danieleejohnson@gmail.com", proposals[0].ContactEmail);
			Assert.Single(proposals[0].Links);
			Assert.Equal(2, proposals[0].Members.Count);
		}
	}
}