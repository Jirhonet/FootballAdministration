using System;

namespace FootballAdministration.Repositories.Base
{
    public class RepositoryBase
    {
        private readonly DbContext dbContext;
        
        protected RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        #region Properties
        protected DbContext DbContext
            => dbContext;
        #endregion
    }
}