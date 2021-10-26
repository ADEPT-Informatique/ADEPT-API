using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories
{
    public interface IQuestionRepository
    {
        /// <summary>
        /// Obtain a specific question
        /// </summary>
        /// <param name="id">The question id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<QuestionDto> GetQuestionByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Create a question
        /// </summary>
        /// <param name="questionCreateRequestDto">The create request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<QuestionDto> CreateQuestionAsync(QuestionCreateRequestDto questionCreateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// Delete a specific question
        /// </summary>
        /// <param name="id">The question id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task DeleteQuestionAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Obtain paginated questions depending on the query request
        /// </summary>
        /// <param name="pageIndex">The page index</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="questionsQueryDto">The query request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="searches">Searches</param>
        /// <returns></returns>
        Task<PaginatedCollectionResultDto<QuestionDto>> GetQuestionByPageByQueryAsync(int pageIndex, int pageSize, QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null);

        /// <summary>
        /// Obtain questions depending on the query request
        /// </summary>
        /// <param name="questionsQueryDto">The query request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <param name="searches">Searches</param>
        /// <returns></returns>
        Task<IEnumerable<QuestionDto>> GetQuestionsByQueryAsync(QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null);

        /// <summary>
        /// Toggle the activity
        /// </summary>
        /// <param name="id">The question id</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<QuestionDto> ToggleQuestionAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Update a specific question
        /// </summary>
        /// <param name="id">The question id</param>
        /// <param name="questionUpdateRequestDto">The update request</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task<QuestionDto> UpdateQuestionAsync(Guid id, QuestionUpdateRequestDto questionUpdateRequestDto, CancellationToken cancellationToken);
    }
}