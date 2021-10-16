using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.Exceptions;
using ADEPT_API.LIBRARY.Dto;
using ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions;
using ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.LIBRARY.Dto.MembreConfiances.Questions.Operations.Requests;
using ADEPT_API.LIBRARY.QueryBuilder;
using AutoMapper;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals.MembreConfiance
{
    internal class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException($"{nameof(QuestionService)} was expection a value for {nameof(questionRepository)} but received null..");
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(QuestionService)} was expection a value for {nameof(mapper)} but received null..");
        }


        public async Task<IEnumerable<QuestionDto>> GetQuestionsByQueryAsync(QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var results = new List<QuestionDto>();

            var expression = this.GetQuestionSearchQuery(questionsQueryDto, searches);
            var questions = await _questionRepository.GetAllAsync(expression);

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

            var expression = this.GetQuestionSearchQuery(questionsQueryDto, searches);
            var paginatedResults = await _questionRepository.GetPaginatedResultsAsync(pageIndex, pageSize, expression);
            if (paginatedResults is { } && paginatedResults.Any())
            {
                _mapper.Map<PagedList<IQueryable<Question>, Question>, PaginatedCollectionResultDto<QuestionDto>>(paginatedResults, results);
            }

            return results;
        }

        public async Task<QuestionDto> ToggleQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var question = await _questionRepository.GetAsync(id) ?? throw new NotFoundException(nameof(Question).ToUpper(), $"Une question avec l'id {id} n'existe pas.");

            question.Activated = !question.Activated;

            await _questionRepository.SaveAsync();

            return _mapper.Map<Question, QuestionDto>(question);
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionCreateRequestDto questionCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var questionToCreate = _mapper.Map<QuestionCreateRequestDto, Question>(questionCreateRequestDto);

            await _questionRepository.AddAsync(questionToCreate);
            await _questionRepository.SaveAsync();

            return _mapper.Map<Question, QuestionDto>(questionToCreate);
        }

        public async Task<QuestionDto> UpdateQuestionAsync(Guid id, QuestionUpdateRequestDto questionUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var question = await _questionRepository.GetAsync(id) ?? throw new NotFoundException(nameof(Question).ToUpper(), $"Une question avec l'id {id} n'existe pas.");

            _mapper.Map<QuestionUpdateRequestDto, Question>(questionUpdateRequestDto, question);
            await _questionRepository.SaveAsync();

            return _mapper.Map<Question, QuestionDto>(question);
        }

        public async Task DeleteQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var question = await _questionRepository.GetAsync(id) ?? throw new NotFoundException(nameof(Question).ToUpper(), $"Une question avec l'id {id} n'existe pas.");

            _questionRepository.Remove(question);
            await _questionRepository.SaveAsync();
        }

        #region Helpers

        private Expression<Func<Question, bool>> GetQuestionSearchQuery(QuestionsQueryDto questionsQueryDto, string searches)
        {
            var queryBuilder = new QuestionQueryBuilder(searches);
            var query = queryBuilder.GetQuery(questionsQueryDto ??= new QuestionsQueryDto());
            return query;
        }

        #endregion

    }
}
