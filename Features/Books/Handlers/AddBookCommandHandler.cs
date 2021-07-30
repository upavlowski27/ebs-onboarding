using System.Threading;
using System.Threading.Tasks;
using EBS.Onboarding.Web.Features.Books.Commands;
using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly BookRepository _bookRepository;
 
        public AddBookCommandHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
 
        public async Task<Book> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                ISBN = command.ISBN,
                Title = command.Title,
                Description = command.Description
            };
            
            await _bookRepository.Create(book);
            
            return book;
        }
    }
}