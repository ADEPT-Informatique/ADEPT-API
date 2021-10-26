using ADEPT_API.DATACONTRACTS.Dto.Users;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories
{
    public interface IStudyProgramRepository
    {
        /// <summary>
        /// Obtain a specific program
        /// </summary>
        /// <param name="id">The program id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<StudyProgramDto> GetStudyProgramByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain a specific program
        /// </summary>
        /// <param name="name">The program name</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<StudyProgramDto> GetStudyProgramByNameAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Create a program
        /// </summary>
        /// <param name="studyProgramCreateRequestDto">The create request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<StudyProgramDto> CreateStudyProgramAsync(StudyProgramCreateRequestDto studyProgramCreateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain all programs
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<IEnumerable<StudyProgramDto>> GetProgramsAsync(CancellationToken cancellationToken);
    }
}
