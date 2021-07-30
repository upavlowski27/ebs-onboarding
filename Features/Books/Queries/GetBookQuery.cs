using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Queries
{
    public record GetBookQuery : IRequest<Book>
    {
        public string ISBN { get; init; }
    }
}