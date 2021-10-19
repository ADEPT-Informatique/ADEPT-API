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
                if (userQueryDto.Ids is { } && userQueryDto.Ids.Any())
                {
                    Expression<Func<User, bool>> queryIds = entity => userQueryDto.Ids.Contains(entity.Id);
                    _query = _query is null ? queryIds : _query.And(queryIds);
                }
                //Query FirebaseIds
                if (userQueryDto.FirebaseIds is { } && userQueryDto.FirebaseIds.Any())
                {
                    Expression<Func<User, bool>> queryFirebaseIds = entity => userQueryDto.FirebaseIds.Contains(entity.FireBaseID);
                    _query = _query is null ? queryFirebaseIds : _query.And(queryFirebaseIds);
                }

                //Query StudentNumbers
                if (userQueryDto.StudentNumbers is { } && userQueryDto.StudentNumbers.Any())
                {
                    Expression<Func<User, bool>> queryStudentNumbers = entity => userQueryDto.StudentNumbers.Contains(entity.StudentNumber);
                    _query = _query is null ? queryStudentNumbers : _query.And(queryStudentNumbers);
                }

                //Query DiscordIds
                if (userQueryDto.DiscordIds is { } && userQueryDto.DiscordIds.Any())
                {
                    Expression<Func<User, bool>> queryDiscordIds = entity => userQueryDto.DiscordIds.Contains(entity.DiscordId);
                    _query = _query is null ? queryDiscordIds : _query.And(queryDiscordIds);
                }

                //Query ProgramIds
                if (userQueryDto.ProgramIds is { } && userQueryDto.ProgramIds.Any())
                {
                    Expression<Func<User, bool>> queryProgramIds = entity => userQueryDto.ProgramIds.Contains(entity.ProgramId);
                    _query = _query is null ? queryProgramIds : _query.And(queryProgramIds);
                }

                if (userQueryDto.UserRoles is { })
                {
                    //Query Roles
                    if (userQueryDto.UserRoles.Roles is { } && userQueryDto.UserRoles.Roles.Any())
                    {
                        Expression<Func<User, bool>> queryRoles = entity => entity.Roles.Any(x => userQueryDto.UserRoles.Roles.Contains(x.Role));
                        _query = _query is null ? queryRoles : _query.And(queryRoles);
                    }
                }
            }

            return _query ??= entity => true;
        }
    }
}
