using ProjectVideo.Tests.Setup;

namespace ProjectVideo.Tests
{
	public class ProposalUpdateInteractorShould : IAsyncLifetime
	{
        private readonly RepoCollectionFixture _fixture;

        public ProposalUpdateInteractorShould(RepoCollectionFixture repofixture)
        {
            _fixture = repofixture;
        }

        public Task DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        [Fact]
		public void Successfully_Create_Proposal()
		{

		}
	}
}