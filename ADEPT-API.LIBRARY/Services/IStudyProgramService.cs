using ADEPT_API.DATACONTRACTS.Dto.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IStudyProgramService
    {
        Task<StudyProgramDto> CreateAsync(StudyProgramCreateRequestDto studyProgramCreateRequestDto);
        Task<int> DeletionImpactAsync(Guid programId);
        Task<IEnumerable<StudyProgramDto>> GetAllAsync();
    }
}