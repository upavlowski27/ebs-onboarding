using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Commands
{
    public record UpdateBookCommand : Book, IRequest<Book>
    {
        
    }
}