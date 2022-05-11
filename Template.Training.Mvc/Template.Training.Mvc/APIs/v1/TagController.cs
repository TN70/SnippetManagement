using Core.Application.Features.Tag.Commands.CreateTag;
using Core.Application.Features.Tag.Commands.DeleteTag;
using Core.Application.Features.Tag.Commands.UpdateTag;
using Core.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SnippetManagement.Extensions;

namespace SnippetManagement.APIs.v1
{
    [ApiVersion("1.0")]
    public class TagController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TagController> _logger;

        public TagController(IMediator mediator, ILogger<TagController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(command, cancellationToken);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodeCustom.BadRequest, new Response<Exception>(ex.Message));
            }
        }

        [HttpPut("UpdateTag")]
        public async Task<IActionResult> UpdateTag([FromBody] UpdateTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(command, cancellationToken);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodeCustom.BadRequest, new Response<Exception>(ex.Message));
            }
        }

        [HttpDelete("DeleteTag")]
        public async Task<IActionResult> DeleteTag([FromQuery] DeleteTagCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(command, cancellationToken);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodeCustom.BadRequest, new Response<Exception>(ex.Message));
            }
        }
    }
}
