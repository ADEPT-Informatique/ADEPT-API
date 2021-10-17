using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.Exceptions;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using ADEPT_API.DATACONTRACTS.Dto.Users.Operations.Queries;

namespace ADEPT_API.LIBRARY.Services.Internals
{
    internal class StudyProgramService : IStudyProgramService
    {
        private readonly IStudyProgramRepository _studyProgramRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public StudyProgramService(IStudyProgramRepository studyProgramRepository, IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), $"{nameof(StudyProgramService)} was expecting a value for {nameof(mapper)} but received null..");
            _studyProgramRepository = studyProgramRepository ?? throw new ArgumentNullException(nameof(studyProgramRepository),$"{nameof(StudyProgramService)} was expecting a value for {nameof(studyProgramRepository)} but received null..");
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository), $"{nameof(StudyProgramService)} was expecting a value for {nameof(userRepository)} but received null..");
        }
        public async Task<IEnumerable<StudyProgramDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var results = await _studyProgramRepository.GetProgramsAsync(cancellationToken);
            return results;
        }

        public async Task<StudyProgramDto> CreateAsync(StudyProgramCreateRequestDto studyProgramCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var program = await _studyProgramRepository.GetStudyProgramByNameAsync(studyProgramCreateRequestDto.Name, cancellationToken);
            if (program is { })
            {
                throw new AlreadyExistsException(nameof(StudyProgram).ToUpper(), "Un Programme d'études avec ce nom éxiste déjà.");
            }

            var result = await _studyProgramRepository.CreateStudyProgramAsync(studyProgramCreateRequestDto, cancellationToken);
            return result;
            
        }

        public async Task<int> DeletionImpactAsync(Guid programId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _ = _studyProgramRepository.GetStudyProgramByIdAsync(programId, cancellationToken) ?? throw new NotFoundException(nameof(StudyProgram).ToUpper(), $"Un Programme d'études avec le Id {programId}");
            var userQuery = new UsersQueryDto { ProgramIds = new List<Guid> { programId } };
            var users = await _userRepository.GetUsersByQueryAsync(userQuery, cancellationToken);
            return users.Count();
        }
    }
}
