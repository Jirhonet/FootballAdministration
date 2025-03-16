using FootballAdministration.Repositories.Base;

namespace FootballAdministration.Repositories
{
    public class TrainingRepository : RepositoryBase
    {
        public TrainingRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}

