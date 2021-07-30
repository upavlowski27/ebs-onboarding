using System.Threading;
using System.Threading.Tasks;
using EBS.Onboarding.Web.Features.Books.Commands;
using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly BookRepository _bookRepository;
 
        public UpdateBookCommandHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
 
        public async Task<Book> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                ISBN = command.ISBN,
                Title = command.Title,
                Description = command.Description
            };
            
            await _bookRepository.Update(book);
            
            return book;
        }
    }
}