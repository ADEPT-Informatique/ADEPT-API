using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATABASE.QueryBuilder;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Requests;
using AutoMapper;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.Repositories.Internals.MembreConfiance
{
    internal class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        private readonly IMapper _mapper;

        public QuestionRepository(AdeptContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), $"{nameof(QuestionRepository)} was expection a value for {nameof(mapper)} but received null..");
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var question = await base.GetFirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Question, QuestionDto>(question);
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsByQueryAsync(QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new List<QuestionDto>();

            var expression = GetQuestionSearchQuery(questionsQueryDto, searches);
            var questions = await base.GetAllAsync(expression);

            if (questions is { } && questions.Any())
            {
                results.AddRange(questions.Select(x => _mapper.Map<Question, QuestionDto>(x)));
            }

            return results;
        }

        public async Task<PaginatedCollectionResultDto<QuestionDto>> GetQuestionByPageByQueryAsync(int pageIndex, int pageSize, QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new PaginatedCollectionResultDto<QuestionDto>();

            var expression = GetQuestionSearchQuery(questionsQueryDto, searches);
            var paginatedResults = await base.GetPaginatedResultsAsync(pageIndex, pageSize, expression);
            if (paginatedResults is { } && paginatedResults.Any())
            {
                _mapper.Map<PagedList<IQueryable<Question>, Question>, PaginatedCollectionResultDto<QuestionDto>>(paginatedResults, results);
            }

            return results;
        }

        public async Task<QuestionDto> ToggleQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var question = await base.GetAsync(id);
            question.Activated = !question.Activated;
            await base.SaveAsync();

            return _mapper.Map<Question, QuestionDto>(question);
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionCreateRequestDto questionCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var questionToCreate = _mapper.Map<QuestionCreateRequestDto, Question>(questionCreateRequestDto);

            await base.AddAsync(questionToCreate);
            await base.SaveAsync();

            return _mapper.Map<Question, QuestionDto>(questionToCreate);
        }

        public async Task<QuestionDto> UpdateQuestionAsync(Guid id, QuestionUpdateRequestDto questionUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var question = await base.GetAsync(id);
            _mapper.Map<QuestionUpdateRequestDto, Question>(questionUpdateRequestDto, question);
            await base.SaveAsync();

            return _mapper.Map<Question, QuestionDto>(question);
        }

        public async Task DeleteQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var question = await base.GetAsync(id);

            base.Remove(question);
            await base.SaveAsync();
        }

        #region Helpers

        private static Expression<Func<Question, bool>> GetQuestionSearchQuery(QuestionsQueryDto questionsQueryDto, string searches)
        {
            var queryBuilder = new QuestionQueryBuilder(searches);
            var query = queryBuilder.GetQuery(questionsQueryDto);
            return query;
        }

        #endregion
    }
}
