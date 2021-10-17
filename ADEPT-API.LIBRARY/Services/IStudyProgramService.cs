using ADEPT_API.DATACONTRACTS.Dto.Users;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IStudyProgramService
    {
        /// <summary>
        /// Create a program
        /// </summary>
        /// <param name="studyProgramCreateRequestDto">The create request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<StudyProgramDto> CreateAsync(StudyProgramCreateRequestDto studyProgramCreateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain the number of user impacted by the deletion of a specific program
        /// </summary>
        /// <param name="programId">The program id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<int> DeletionImpactAsync(Guid programId, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain all programs
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<IEnumerable<StudyProgramDto>> GetAllAsync(CancellationToken cancellationToken);
    }
}