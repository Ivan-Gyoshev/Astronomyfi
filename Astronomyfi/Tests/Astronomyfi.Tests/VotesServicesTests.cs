namespace Astronomyfi.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;
    using Astronomyfi.Services.Data.Votes;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class VotesServicesTests : BaseTestsService
    {
        private IVotesService Service
            => this.ServiceProvider.GetRequiredService<IVotesService>();

        [Theory]
        [InlineData("userId", 1, true)]
        public async Task CreateCommentShouldWorkCorrectly(string userId, int postId, bool isUpVote)
        {
            await this.Service.VoteAsync(postId, userId, isUpVote);

            Assert.True(this.DbContext.Votes.Count() == 1);
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectData()
        {
            var vote = await this.CreateVoteAsync();

            var votesCount = this.Service.GetVotes(vote.Id);
            var expected = 1;

            Assert.True(votesCount == expected);
        }

        private async Task<Vote> CreateVoteAsync()
        {
            var vote = new Vote
            {
                Id = 1,
                PostId = 1,
                AuthorId = "TestId",
                Type = (TypeOfVote)1,
            };

            await this.DbContext.AddAsync(vote);
            await this.DbContext.SaveChangesAsync();

            return vote;
        }
    }
}
