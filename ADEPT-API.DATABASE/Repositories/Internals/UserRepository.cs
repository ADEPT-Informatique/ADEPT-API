using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using System.Threading.Tasks;
using ADEPT_API.DATACONTRACTS.Dto.Users.Operations.Queries;
using System.Threading;
using System.Linq.Expressions;
using ADEPT_API.DATACONTRACTS.Enums;
using ADEPT_API.DATABASE.QueryBuilder;
using ADEPT_API.DATABASE.Models.Users.Extensions;
using System.Linq;
using ADEPT_API.DATACONTRACTS.Dto.Users.Authentification;

namespace ADEPT_API.Repositories.Internals
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(AdeptContext context, IMapper mapper) : base(context) 
        {
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(UserRepository)} was expection a value for {nameof(mapper)} but received null..");
        }

        public async Task<IEnumerable<UserDto>> GetUsersByQueryAsync(UsersQueryDto usersQueryDto, CancellationToken cancellationToken, string orderField = null, OrderDirections orderDirection = OrderDirections.Asc,  string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new List<UserDto>();

            var expression = this.GetUsersSearchQuery(usersQueryDto, searches);
            var users = await base.GetAllAsync(expression, orderField, orderDirection, UsersIncludeExtensions.IncludeAll);
            if (users is { } && users.Any())
            {
                results.AddRange(users.Select(x => _mapper.Map<User, UserDto>(x)));
            }

            return results;
        }

        public async Task<UserDto> CreateFirebaseUserAsync(string firebaseId, AuthenticateInDto authenticateInDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var userToCreate = _mapper.Map<AuthenticateInDto, User>(authenticateInDto);
            userToCreate.FireBaseID = firebaseId;

            await base.AddAsync(userToCreate);
            await base.SaveAsync();

            return _mapper.Map<User, UserDto>(userToCreate);
        }

        #region Helpers

        private Expression<Func<User,bool>> GetUsersSearchQuery(UsersQueryDto usersQueryDto, string searches)
        {
            var queryBuilder = new UserQueryBuilder(searches);
            var query = queryBuilder.GetQuery(usersQueryDto ??= new UsersQueryDto());
            return query;
        }

        #endregion
    }
}
