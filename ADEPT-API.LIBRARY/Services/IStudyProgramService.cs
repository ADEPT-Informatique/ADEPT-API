using ADEPT_API.LIBRARY.Dto.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    /// <summary>
    /// Service used to create / update and check impact of delecting a StudyProgram
    /// </summary>
    public interface IStudyProgramService
    {
        /// <summary>
        /// Creates a study program
        /// </summary>
        /// <param name="pProgram"></param>
        Task<StudyProgramDto> CreateAsync(StudyProgramCreateRequestDto pProgram);
        /// <summary>
        /// Checks how many users are affected if study program is to be removed
        /// </summary>
        /// <param name="pProgramId"></param>
        Task<int> DeletionImpactAsync(Guid pProgramId);

        /// <summary>
        /// Fetches all StudyPrograms from the Database
        /// </summary>
        Task<IEnumerable<StudyProgramDto>> GetAllAsync();
    }
}