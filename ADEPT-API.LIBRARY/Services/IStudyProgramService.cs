using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.LIBRARY.Dto.Users;
using System;
using System.Collections.Generic;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IStudyProgramService
    {
        StudyProgramDto Create(StudyProgramCreateRequestDto pProgram);
        int DeletionImpact(Guid pProgramId);
        IEnumerable<StudyProgramDto> GetAll();
    }
}