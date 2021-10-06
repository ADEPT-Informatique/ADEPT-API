using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.MembreConfiance;

namespace ADEPT_API.Repositories.Internals.MembreConfiance
{
    public class QuestionRepository : BaseRepository<Question>
    {
        public QuestionRepository(AdeptContext pContext) : base(pContext) { }
    }
}
