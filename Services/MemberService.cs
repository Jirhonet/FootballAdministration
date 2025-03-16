using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FootballAdministration.Models.Entities;
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

        public Task<Member> GetMemberAsync(int id, CancellationToken ct = default)
        {
            return repository.GetMemberAsync(id, ct);
        }

        public Task<IEnumerable<MemberView>> GetMembersAsync(CancellationToken ct = default)
        {
            return repository.GetMembersAsync(ct);
        }

        public Task<int> AddMemberAsync(Member member, CancellationToken ct = default)
        {
            return repository.InsertAsync(member, ct);
        }

        public Task<int> UpdateMemberAsync(Member member, CancellationToken ct = default)
        {
            return repository.UpdateAsync(member, ct);
        }

        public Task<int> DeleteMemberAsync(int id, CancellationToken ct = default)
        {
            return repository.DeleteAsync(id, ct);
        }
    }
}

