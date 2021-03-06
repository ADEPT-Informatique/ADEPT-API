using ADEPT_API.DATABASE.Models.MembreConfiance;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Requests;
using ADEPT_API.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services.Internals.MembreConfiance
{
    internal class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository), $"{nameof(QuestionService)} was expection a value for {nameof(questionRepository)} but received null..");
        }


        public async Task<IEnumerable<QuestionDto>> GetQuestionsByQueryAsync(QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var results = await _questionRepository.GetQuestionsByQueryAsync(questionsQueryDto, cancellationToken, searches);
            return results;
        }

        public async Task<PaginatedCollectionResultDto<QuestionDto>> GetQuestionByPageByQueryAsync(int pageIndex, int pageSize, QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var results = await _questionRepository.GetQuestionByPageByQueryAsync(pageIndex, pageSize, questionsQueryDto, cancellationToken, searches);
            return results;
        }

        public async Task<QuestionDto> ToggleQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _ = await _questionRepository.GetQuestionByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(Question).ToUpper(), $"La question avec l'pId {id} est introuvable.");

            var result = await _questionRepository.ToggleQuestionAsync(id, cancellationToken);
            return result;
        }

        public async Task<QuestionDto> CreateQuestionAsync(QuestionCreateRequestDto questionCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _questionRepository.CreateQuestionAsync(questionCreateRequestDto, cancellationToken);
            return result;
        }

        public async Task<QuestionDto> UpdateQuestionAsync(Guid id, QuestionUpdateRequestDto questionUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _ = await _questionRepository.GetQuestionByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(Question).ToUpper(), $"La question avec l'pId {id} est introuvable.");

            var result = await _questionRepository.UpdateQuestionAsync(id, questionUpdateRequestDto, cancellationToken);
            return result;
        }

        public async Task DeleteQuestionAsync(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _ = await _questionRepository.GetQuestionByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(Question).ToUpper(), $"La question avec l'pId {id} est introuvable.");

            await _questionRepository.DeleteQuestionAsync(id, cancellationToken);
        }
    }
}
