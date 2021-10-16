using ADEPT_API.DATACONTRACTS.Dto.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IStudyProgramService
    {
        Task<StudyProgramDto> CreateAsync(StudyProgramCreateRequestDto pProgram);
        Task<int> DeletionImpactAsync(Guid pProgramId);
        Task<IEnumerable<StudyProgramDto>> GetAllAsync();
    }
}