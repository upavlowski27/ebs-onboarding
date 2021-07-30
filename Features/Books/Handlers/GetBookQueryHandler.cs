using System.Threading;
using System.Threading.Tasks;
using EBS.Onboarding.Web.Features.Books.Queries;
using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Handlers
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book>
    {
        private readonly BookRepository _bookRepository;
 
        public GetBookQueryHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
 
        public async Task<Book> Handle(GetBookQuery query, CancellationToken cancellationToken)
        {
            return await _bookRepository.Load(query.ISBN);
        }
    }
}