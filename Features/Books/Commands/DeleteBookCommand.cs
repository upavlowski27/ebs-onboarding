using MediatR;

namespace EBS.Onboarding.Web.Features.Books.Commands
{
    public record DeleteBookCommand : IRequest<string>
    {
        public string ISBN { get; init; }
    }
}