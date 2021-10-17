using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.Users;
using ADEPT_API.Repositories.Internals;
using AutoMapper;
using System;
using System.Threading.Tasks;
using ADEPT_API.DATACONTRACTS.Dto.Users;
using System.Threading;

namespace ADEPT_API.DATABASE.Repositories.Internals
{
    internal class StudyProgramRepository : BaseRepository<StudyProgram>, IStudyProgramRepository
    {
        private readonly IMapper _mapper;

        public StudyProgramRepository(AdeptContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(StudyProgramRepository)} was expection a value for {nameof(mapper)} but received null..");
        }

        public async Task<StudyProgramDto> GetStudyProgramByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var studyProgram = await base.GetFirstOrDefaultAsync(x =>x.Id == id);
            return _mapper.Map<StudyProgram, StudyProgramDto>(studyProgram);
        }

        public async Task<StudyProgramDto> GetStudyProgramByNameAsync(string name, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var studyProgram = await base.GetFirstOrDefaultAsync(x =>x.Name.ToLower().Trim() == name.ToLower().Trim());
            return _mapper.Map<StudyProgram, StudyProgramDto>(studyProgram);
        }

        public async Task<StudyProgramDto> CreateStudyProgramAsync(StudyProgramCreateRequestDto studyProgramCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var programToCreate = _mapper.Map<StudyProgramCreateRequestDto, StudyProgram>(studyProgramCreateRequestDto);
            await base.AddAsync(programToCreate);
            await base.SaveAsync();

            return _mapper.Map<StudyProgram, StudyProgramDto>(programToCreate);
        }

    }
}
