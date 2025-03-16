using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FootballAdministration.Models.Views;
using FootballAdministration.Repositories;

namespace FootballAdministration.Services
{
    public class MemberService
    {
        private readonly MemberRepository repository;
        
        public MemberService(MemberRepository repository = null)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        public Task<IEnumerable<MemberView>> GetMembersAsync(CancellationToken ct = default)
        {
            return repository.GetMembersAsync(ct);
        }
    }
}

