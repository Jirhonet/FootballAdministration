using FootballAdministration.Repositories;
using System;

namespace FootballAdministration.Services
{
    public class MatchService
    {
        private readonly MatchRepository repository;

        public MatchService(MatchRepository repository = null)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}

