using ADEPT_API.DATABASE.Models.Users;
using System.Collections.Generic;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IStudyProgramService
    {
        StudyProgram Create(string programName);
        IEnumerable<StudyProgram> GetAll();
    }
}