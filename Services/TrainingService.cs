using FootballAdministration.Repositories;
using System;

namespace FootballAdministration.Services
{
    public class TrainingService
    {
        private readonly TrainingRepository repository;

        public TrainingService(TrainingRepository repository = null)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}

