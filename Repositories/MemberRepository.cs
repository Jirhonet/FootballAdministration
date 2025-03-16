using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FootballAdministration.Models.Entities;
using FootballAdministration.Models.Views;
using FootballAdministration.Repositories.Base;
using Microsoft.Data.SqlClient;

namespace FootballAdministration.Repositories
{
    public class MemberRepository : RepositoryBase
    {
        public MemberRepository(DbContext dbContext)
            : base(dbContext)
        {
            //
        }

        public async Task<Member> GetMemberAsync(int id, CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    m.*
                FROM Member m
                WHERE m.Id = @Id
                """;

            var param = new
            {
                Id = id,
            };

            await using SqlConnection connection = DbContext.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Member>(sql, param);
        }

        public async Task<IEnumerable<MemberView>> GetMembersAsync(CancellationToken ct = default)
        {
            const string sql =
                """
                SELECT
                    m.Id,
                    m.FirstName,
                    m.MiddleName,
                    m.LastName,
                    m.DateOfBirth,
                    m.Email,

                    t.Id,
                    t.Name,

                    tr.Id,
                    tr.FirstName,
                    tr.MiddleName,
                    tr.LastName,
                    tr.DateOfBirth,
                    tr.Email
                FROM Member m
                LEFT JOIN Team t ON t.Id = m.TeamId
                LEFT JOIN Trainer tr ON tr.Id = t.TrainerId
                """;

            await using SqlConnection connection = DbContext.GetConnection();
            return await connection.QueryAsync<MemberView, TeamView, TrainerView, MemberView>(
                sql,
                (member, team, trainer) =>
                {
                    if (team != null)
                        member.Team = team;
                    if (trainer != null)
                        team.Trainer = trainer;
                    return member;
                },
                splitOn: "Id"
            );
        }

        public async Task<int> InsertAsync(Member member, CancellationToken ct = default)
        {
            const string sql =
                """
                INSERT INTO Member (FirstName, MiddleName, LastName, DateOfBirth, Email, Password, TeamId, IsActive)
                VALUES (@FirstName, @MiddleName, @LastName, @DateOfBirth, @Email, @Password, @TeamId, @IsActive)
                """;

            await using SqlConnection connection = DbContext.GetConnection();
            return await connection.ExecuteAsync(sql, member);
        }

        public async Task<int> UpdateAsync(Member member, CancellationToken ct = default)
        {
            const string sql =
                """
                UPDATE Member
                SET FirstName = @FirstName,
                    MiddleName = @MiddleName,
                    LastName = @LastName,
                    DateOfBirth = @DateOfBirth,
                    Email = @Email,
                    Password = @Password,
                    TeamId = @TeamId,
                    IsActive = @IsActive
                WHERE Id = @Id
                """;

            await using SqlConnection connection = DbContext.GetConnection();
            return await connection.ExecuteAsync(sql, member);
        }

        public async Task<int> DeleteAsync(int id, CancellationToken ct = default)
        {
            const string sql =
                """
                DELETE FROM Member
                WHERE Id = @Id
                """;

            var param = new
            {
                Id = id,
            };

            await using SqlConnection connection = DbContext.GetConnection();
            return await connection.ExecuteAsync(sql, param);
        }
    }
}

