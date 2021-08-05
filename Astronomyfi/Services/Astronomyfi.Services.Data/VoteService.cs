namespace Astronomyfi.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Astronomyfi.Data.Common.Repositories;
    using Astronomyfi.Data.Models;
    using Astronomyfi.Data.Models.Enums;

    public class VoteService : IVotesService
    {
        private readonly IDeletableEntityRepository<Vote> votesRepository;

        public VoteService(IDeletableEntityRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(v => v.PostId == postId && v.AuthorId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? TypeOfVote.UpVote : TypeOfVote.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = postId,
                    AuthorId = userId,
                    Type = isUpVote ? TypeOfVote.UpVote : TypeOfVote.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }

        public int GetVotes(int postId)
           => this.votesRepository.All()
            .Where(v => v.PostId == postId)
            .Sum(v => (int)v.Type);

    }
}
