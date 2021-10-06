using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.Repositories.Internals;

namespace ADEPT_API.DATABASE.Repositories.Internals
{
    internal class StudyProgramRepository : BaseRepository<StudyProgram>, IStudyProgramRepository
    {
        public StudyProgramRepository(AdeptContext pContext) : base(pContext)
        {}
    }
}
