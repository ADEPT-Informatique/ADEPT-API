using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.QueryBuilder.Abstracts;
using ADEPT_API.DATACONTRACTS.Dto.Users.Operations.Queries;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ADEPT_API.DATABASE.QueryBuilder
{
    public class UserQueryBuilder : QueryBuilder<User>
    {
        public UserQueryBuilder(string searches) : base(searches) { }

        public override Expression<Func<User, bool>> GetQuery<TQueryDto>(TQueryDto queryDto)
        {
            if (queryDto is UsersQueryDto userQueryDto)
            {
                //Query Ids
                Expression<Func<User, bool>> queryIds = entity => userQueryDto.Ids.Contains(entity.Id);
                _query = userQueryDto.Ids is null || !userQueryDto.Ids.Any() ? _query : _query is null ? queryIds : _query.And(queryIds);

                //Query FirebaseIds
                Expression<Func<User, bool>> queryFirebaseIds = entity => userQueryDto.FirebaseIds.Contains(entity.FireBaseID);
                _query = userQueryDto.FirebaseIds is null || !userQueryDto.FirebaseIds.Any() ? _query : _query is null ? queryFirebaseIds : _query.And(queryFirebaseIds);

                //Query StudentNumbers
                Expression<Func<User, bool>> queryStudentNumbers = entity => userQueryDto.StudentNumbers.Contains(entity.StudentNumber);
                _query = userQueryDto.StudentNumbers is null || !userQueryDto.StudentNumbers.Any() ? _query : _query is null ? queryStudentNumbers : _query.And(queryStudentNumbers);

                //Query DiscordIds 
                Expression<Func<User, bool>> queryDiscordIds = entity => userQueryDto.DiscordIds.Contains(entity.DiscordId);
                _query = userQueryDto.DiscordIds is null || !userQueryDto.DiscordIds.Any() ? _query : _query is null ? queryDiscordIds : _query.And(queryDiscordIds);

                //Query ProgramIds
                Expression<Func<User, bool>> queryProgramIds = entity => userQueryDto.ProgramIds.Contains(entity.ProgramId);
                _query = userQueryDto.ProgramIds is null || !userQueryDto.ProgramIds.Any() ? _query : _query is null ? queryProgramIds : _query.And(queryProgramIds);

                if (userQueryDto.UserRoles is { })
                {
                    //Query Roles
                    Expression<Func<User, bool>> queryRoles = entity => entity.Roles.Any(x => userQueryDto.UserRoles.Roles.Contains(x.Role));
                    _query = userQueryDto.UserRoles.Roles is null || !userQueryDto.UserRoles.Roles.Any() ? _query : _query is null ? queryRoles : _query.And(queryRoles);
                }
            }

            return _query ??= entity => true;
        }
    }
}
