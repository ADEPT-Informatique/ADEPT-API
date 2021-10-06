using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.Exceptions;
using ADEPT_API.LIBRARY.Dto.Users;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace ADEPT_API.LIBRARY.Services.Internals
{
    public class StudyProgramService
    {
        private readonly IStudyProgramRepository _studyProgramRepository;
        private readonly IMapper _mapper;
        public StudyProgramService(IStudyProgramRepository pStudyProgramRepository, IMapper pMapper)
        {
            _mapper = pMapper;
            _studyProgramRepository = pStudyProgramRepository ?? throw new ArgumentNullException($"{nameof(StudyProgramService)} was expection a value for {nameof(pStudyProgramRepository)} but received null..");
        }
        public IEnumerable<StudyProgramDto> GetAll()
        {
            return _mapper.Map<IEnumerable<StudyProgramDto>>(_studyProgramRepository.GetAll());
        }

        public StudyProgram Create(string programName)
        {

            StudyProgram program = _studyProgramRepository.GetFirstOrDefault(x => x.Name.ToLower().Trim() == programName.ToLower().Trim());
            if (program != null)
            {
                // TODO error 
                throw new AlreadyExistsException("ERR_EXIST_STUDY_PROGRAM", "Un Programme d'études avec ce nom éxiste déjà.");
            }
            else
            {
                program = new StudyProgram()
                {
                    Name = programName
                };
                _studyProgramRepository.Add(program);
                return program;
            }
        }
    }
}
