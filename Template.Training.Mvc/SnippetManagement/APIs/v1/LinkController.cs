using Core.Application.Features.Link.Commands.CreateLink;
using Core.Application.Features.Link.Commands.DeleteLink;
using Core.Application.Features.Link.Commands.UpdateLink;
using Core.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SnippetManagement.Extensions;

namespace SnippetManagement.APIs.v1
{
    [ApiVersion("1.0")]
    public class LinkController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TagController> _logger;

        public LinkController(IMediator mediator, ILogger<TagController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateLink")]
        public async Task<IActionResult> CreateTag([FromBody] CreateLinkCommand command, CancellationToken cancellationToken)
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

        [HttpPut("UpdateLink")]
        public async Task<IActionResult> UpdateTag([FromBody] UpdateLinkCommand command, CancellationToken cancellationToken)
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

        [HttpDelete("DeleteLink")]
        public async Task<IActionResult> DeleteTag([FromQuery] DeleteLinkCommand command, CancellationToken cancellationToken)
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
