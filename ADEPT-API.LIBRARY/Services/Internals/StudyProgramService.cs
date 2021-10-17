using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.Exceptions;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals
{


    internal class StudyProgramService : IStudyProgramService
    {
        private readonly IStudyProgramRepository _studyProgramRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public StudyProgramService(IStudyProgramRepository studyProgramRepository, IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studyProgramRepository = studyProgramRepository ?? throw new ArgumentNullException($"{nameof(StudyProgramService)} was expecting a value for {nameof(studyProgramRepository)} but received null..");
            _userRepository = userRepository ?? throw new ArgumentNullException($"{nameof(StudyProgramService)} was expecting a value for {nameof(userRepository)} but received null..");
        }
        public async Task<IEnumerable<StudyProgramDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudyProgramDto>>(await _studyProgramRepository.GetAllAsync());
        }

        public async Task<StudyProgramDto> CreateAsync(StudyProgramCreateRequestDto studyProgramCreateRequestDto)
        {

            StudyProgram program = await _studyProgramRepository.GetFirstOrDefaultAsync(x => x.Name.ToLower().Trim() == studyProgramCreateRequestDto.Name.ToLower().Trim());
            if (program != null)
            {
                // TODO error 
                throw new AlreadyExistsException(nameof(StudyProgram).ToUpper(), "Un Programme d'études avec ce nom éxiste déjà.");
            }
            else
            {
                program = new StudyProgram()
                {
                    Name = studyProgramCreateRequestDto.Name
                };
                await _studyProgramRepository.AddAsync(program);
                await _studyProgramRepository.SaveAsync();
                return _mapper.Map<StudyProgram, StudyProgramDto>(program);
            }
        }

        public async Task<int> DeletionImpactAsync(Guid programId)
        {
            _ = _studyProgramRepository.GetFirstOrDefaultAsync(x => x.Id == programId) ?? throw new NotFoundException(nameof(StudyProgram).ToUpper(), $"Un Programme d'études avec le Id {programId}");
            return (await _userRepository.GetAllAsync(x => x.Program.Id == programId)).ToList().Count;
        }
    }
}
