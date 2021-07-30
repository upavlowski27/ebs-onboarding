using System.Threading;
using System.Threading.Tasks;
using EBS.Onboarding.Web.Features.Books.Commands;
using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly BookRepository _bookRepository;
 
        public DeleteBookCommandHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
 
        public async Task<string> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            await _bookRepository.Delete(command.ISBN);
            return command.ISBN;
        }
    }
}