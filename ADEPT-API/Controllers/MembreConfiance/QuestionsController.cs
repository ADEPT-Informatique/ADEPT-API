using ADEPT_API.DATACONTRACTS.Dto;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Queries;
using ADEPT_API.DATACONTRACTS.Dto.MembreConfiances.Questions.Operations.Requests;
using ADEPT_API.LIBRARY.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.Controllers.MembreConfiance
{
    [Route("api/membreconfiance/questions")]
    [ApiController]
    public class QuestionsController : ApiController
    {
        private readonly IQuestionService _questionsService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionsService = questionService ?? throw new ArgumentNullException(nameof(questionService), $"{nameof(QuestionsController)} was expection a value for {nameof(questionService)} but received null..");
        }

        [HttpPost("query")]
        [ProducesResponseType(typeof(IEnumerable<QuestionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetQuestionByQuery([FromBody] QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, [FromQuery] string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _questionsService.GetQuestionsByQueryAsync(questionsQueryDto, cancellationToken, searches);
            return Ok(response);
        }

        [HttpPost("pages/{pageIndex}/query")]
        [ProducesResponseType(typeof(PaginatedCollectionResultDto<QuestionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetQuestionByPageByQuery([FromRoute] int pageIndex, [FromQuery] int pageSize, [FromBody] QuestionsQueryDto questionsQueryDto, CancellationToken cancellationToken, [FromQuery] string searches = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageIndex <= default(int) || pageSize <= default(int))
            {
                return BadRequest($"Les paramètres pageIndex : {pageIndex} et pageSize : {pageSize} doivent être plus grand que 0");
            }

            var response = await _questionsService.GetQuestionByPageByQueryAsync(pageIndex, pageSize, questionsQueryDto, cancellationToken, searches);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(QuestionDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionCreateRequestDto questionCreateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _questionsService.CreateQuestionAsync(questionCreateRequestDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(QuestionDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateQuestion([FromRoute] Guid id,[FromBody] QuestionUpdateRequestDto questionUpdateRequestDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _questionsService.UpdateQuestionAsync(id, questionUpdateRequestDto, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}/toggle")]
        [ProducesResponseType(typeof(QuestionDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ToggleQuestion([FromRoute]Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await _questionsService.ToggleQuestionAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteQuestion(Guid id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _questionsService.DeleteQuestionAsync(id, cancellationToken);
            return Ok();
        }
    }
}
