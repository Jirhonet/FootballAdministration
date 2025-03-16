using FootballAdministration.Repositories.Base;

namespace FootballAdministration.Repositories
{
    public class MatchRepository : RepositoryBase
    {
        public MatchRepository(DbContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}

