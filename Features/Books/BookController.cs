using System.Threading.Tasks;
using EBS.Onboarding.Web.Features.Books.Commands;
using EBS.Onboarding.Web.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EBS.Onboarding.Web.Features.Books
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetBookQuery query)
        {
            var book = await _mediator.Send(query);
            return Ok(book);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBookCommand command)
        {
            var book = await _mediator.Send(command);
            return Created(nameof(Book), book);
        }
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBookCommand command)
        {
            var book = await _mediator.Send(command);
            return Ok(book);
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromHeader] DeleteBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}