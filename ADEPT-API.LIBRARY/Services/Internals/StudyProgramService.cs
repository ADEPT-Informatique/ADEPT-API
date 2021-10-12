using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.Exceptions;
using ADEPT_API.LIBRARY.Dto.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals
{


    public class StudyProgramService : IStudyProgramService
    {
        private readonly IStudyProgramRepository _studyProgramRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public StudyProgramService(IStudyProgramRepository pStudyProgramRepository, IUserRepository pUserRepository, IMapper pMapper)
        {
            _mapper = pMapper;
            _studyProgramRepository = pStudyProgramRepository ?? throw new ArgumentNullException($"{nameof(StudyProgramService)} was expecting a value for {nameof(pStudyProgramRepository)} but received null..");
            _userRepository = pUserRepository ?? throw new ArgumentNullException($"{nameof(StudyProgramService)} was expecting a value for {nameof(pUserRepository)} but received null..");
        }
        public async Task<IEnumerable<StudyProgramDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudyProgramDto>>(_studyProgramRepository.GetAll());
        }

        public async Task<StudyProgramDto> CreateAsync(StudyProgramCreateRequestDto pProgram)
        {

            StudyProgram program = _studyProgramRepository.GetFirstOrDefault(x => x.Name.ToLower().Trim() == pProgram.Name.ToLower().Trim());
            if (program != null)
            {
                // TODO error 
                throw new AlreadyExistsException("ERR_EXIST_STUDYPROGRAM", "Un Programme d'études avec ce nom éxiste déjà.");
            }
            else
            {
                program = new StudyProgram()
                {
                    Name = pProgram.Name
                };
                _studyProgramRepository.Add(program);
                _studyProgramRepository.Save();
                return _mapper.Map<StudyProgramDto>(program);
            }
        }

        public async Task<int> DeletionImpactAsync(Guid pProgramId)
        {
            _ = _studyProgramRepository.GetFirstOrDefault(x => x.Id == pProgramId) ?? throw new NotFoundException("ERR_NOTFOUND_STUDYPROGRAM", $"Un Programme d'études avec le Id {pProgramId}");
            return _userRepository.GetAll(x => x.Program.Id == pProgramId).ToList().Count;
        }
    }
}
