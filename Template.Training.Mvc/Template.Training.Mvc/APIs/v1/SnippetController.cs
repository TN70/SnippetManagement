using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Template.Training.Mvc.APIs.v1
{
    [ApiVersion("1.0")]
    public class SnippetController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SnippetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Snippets
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSnippets")]
        public async Task<IActionResult> GetAllSnippets()
        {
            try
            {
                return Ok("All Snippets");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Snippet by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSnippetById")]
        public async Task<IActionResult> GetSnippetById(string Id)
        {
            try
            {
                return Ok("Snippet Id:"+Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create Snippet
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateSnippet")]
        public async Task<IActionResult> CreateSnippet()
        {
            return Ok("Create");
        }

        /// <summary>
        /// Update Snippet
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateSnippet")]
        public async Task<IActionResult> UpdateSnippet()
        {
            return Ok("Update");
        }

        /// <summary>
        /// Delete Snippet
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteSnippet")]
        public async Task<IActionResult> DeleteSnippet()
        {
            return Ok("Delete");
        }

    }
}
