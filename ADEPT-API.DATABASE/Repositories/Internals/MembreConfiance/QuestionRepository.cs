using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATABASE.Repositories;

namespace ADEPT_API.Repositories.Internals.MembreConfiance
{
    internal class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AdeptContext pContext) : base(pContext) { }
    }
}
