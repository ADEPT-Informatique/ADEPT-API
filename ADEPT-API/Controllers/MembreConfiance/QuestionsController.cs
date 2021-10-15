using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ADEPT_API.Controllers.MembreConfiance
{
  [Route("api/membreconfiance/questions")]
  [ApiController]
  public class QuestionsController : ControllerBase
  {


    [HttpPost("query")]
    public async Task<IActionResult> GetQuestionByQuery(CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();

      throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion(CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();

      throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestion(Guid id,  CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();

      throw new NotImplementedException();
    }

    [HttpPut("{id}/toggle")]
    public async Task<IActionResult> ToggleQuestion(Guid id, CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();

      throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(Guid id, CancellationToken cancellationToken)
    {
      cancellationToken.ThrowIfCancellationRequested();

      throw new NotImplementedException();
    }

  }
}
