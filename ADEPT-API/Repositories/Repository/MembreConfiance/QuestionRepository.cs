using ADEPT_API.Context;
using ADEPT_API.Models.MembreConfiance;

namespace ADEPT_API.Repositories.Repository.MembreConfiance
{
    public class QuestionRepository : BaseRepository<Question>
    {
        public QuestionRepository(AdeptContext pContext) : base(pContext) { }
    }
}
