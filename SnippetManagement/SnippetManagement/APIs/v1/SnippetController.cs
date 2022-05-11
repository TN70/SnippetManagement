using Core.Application.Features.Snippet.Commands.CreateSnippet;
using Core.Application.Features.Snippet.Commands.DeleteSnippet;
using Core.Application.Features.Snippet.Commands.UpdateSnippet;
using Core.Application.Features.Snippet.Queries.GetAllSnippets;
using Core.Application.Features.Snippet.Queries.GetSnippetById;
using Core.Application.Features.Snippet.Queries.SearchSnippetByKeyword;
using Core.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SnippetManagement.Extensions;

namespace SnippetManagement.APIs.v1
{
    [ApiVersion("1.0")]
    public class SnippetController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SnippetController> _logger;

        public SnippetController(IMediator mediator, ILogger<SnippetController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetAllSnippets")]
        public async Task<IActionResult> GetAllSnippets([FromQuery] GetAllSnippetsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(query, cancellationToken);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodeCustom.BadRequest, new Response<Exception>(ex.Message));
            }
        }

        [HttpGet("SearchSnippetByKeyword")]
        public async Task<IActionResult> SearchSnippetByKeyword([FromQuery] SearchSnippetByKeywordQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(query, cancellationToken);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodeCustom.BadRequest, new Response<Exception>(ex.Message));
            }
        }

        [HttpGet("GetSnippetById")]
        public async Task<IActionResult> GetSnippetById([FromQuery] GetSnippetByIdQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodeCustom.BadRequest, new Response<Exception>(ex.Message));
            }
        }

        [HttpPost("CreateSnippet")]
        public async Task<IActionResult> CreateSnippet([FromBody] CreateSnippetCommand command, CancellationToken cancellationToken)
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

        [HttpPut("UpdateSnippet")]
        public async Task<IActionResult> UpdateSnippet([FromBody] UpdateSnippetCommand command, CancellationToken cancellationToken)
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

        [HttpDelete("DeleteSnippet")]
        public async Task<IActionResult> DeleteSnippet([FromQuery] DeleteSnippetCommand command, CancellationToken cancellationToken)
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
