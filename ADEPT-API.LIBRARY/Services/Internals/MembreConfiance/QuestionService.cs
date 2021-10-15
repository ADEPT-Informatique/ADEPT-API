using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.LIBRARY.Dto;
using ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions;
using ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions.Operations.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals.MembreConfiance
{
    public class QuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException($"{nameof(QuestionService)} was expection a value for {nameof(questionRepository)} but received null..");
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(QuestionService)} was expection a value for {nameof(mapper)} but received null..");
        }


        public async Task<IEnumerable<QuestionDto>> GetQuestionsByQueryAsync(QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new List<QuestionDto>();


            return results;
        }

        public async Task<PaginatedCollectionResultDto<QuestionDto>> GetQuestionByPageByQueryAsync(int pageIndex, int pageSize, QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new PaginatedCollectionResultDto<QuestionDto>();



            return results;
        }

        public async Task<QuestionDto> ToggleQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionCreateRequestDto questionCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public async Task<QuestionDto> UpdateQuestionAsync(QuestionUpdateRequestDto questionUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }

        public async Task DeleteQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            throw new NotImplementedException();
        }
    }
}
