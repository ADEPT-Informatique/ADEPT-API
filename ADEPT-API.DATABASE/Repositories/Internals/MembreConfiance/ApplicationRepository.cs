using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.Repositories.Internals;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories.Internals.MembreConfiance
{
    internal class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        private readonly IMapper _mapper;

        public ApplicationRepository(AdeptContext pContext, IMapper mapper) : base(pContext) 
        {
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(ApplicationRepository)} was expection a value for {nameof(mapper)} but received null..");
        }

        public IQueryable<Application> IncludeAll(IQueryable<Application> queryable)
        {
            var query = queryable.Include(x => x.ApplicationQuestions)
                                 .Include(x => x.User)
                                 .Include(x => x.Reviewer);

            return query;
        }
    }
}
