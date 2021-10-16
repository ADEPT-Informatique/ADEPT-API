using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.LIBRARY.Services
{
    public interface IQuestionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionCreateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<QuestionDto> CreateQuestionAsync(QuestionCreateRequestDto questionCreateRequestDto, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteQuestionAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="questionsQueryDto"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="searches"></param>
        /// <returns></returns>
        Task<PaginatedCollectionResultDto<QuestionDto>> GetQuestionByPageByQueryAsync(int pageIndex, int pageSize, QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionsQueryDto"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="searches"></param>
        /// <returns></returns>
        Task<IEnumerable<QuestionDto>> GetQuestionsByQueryAsync(QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, string searches = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<QuestionDto> ToggleQuestionAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="questionUpdateRequestDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<QuestionDto> UpdateQuestionAsync(Guid id, QuestionUpdateRequestDto questionUpdateRequestDto, CancellationToken cancellationToken);
    }
}