using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
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
                INNER JOIN Team t ON t.Id = m.TeamId
                INNER JOIN Trainer tr ON tr.Id = t.TrainerId
                """;

            await using SqlConnection connection = DbContext.GetConnection();
            return await connection.QueryAsync<MemberView, TeamView, TrainerView, MemberView>(
                sql,
                (member, team, trainer) =>
                {
                    member.Team = team;
                    team.Trainer = trainer;
                    return member;
                },
                splitOn: "Id"
            );
        }
    }
}

