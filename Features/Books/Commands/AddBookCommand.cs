using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Commands
{
    public record AddBookCommand : Book, IRequest<Book>
    {
        
    }
}