using Amazon.DynamoDBv2.DataModel;

namespace EBS.Onboarding.Web.Features.Books
{
    [DynamoDBTable("Books")]
    public record Book
    {
        public string ISBN { get; init; }
        
        public string Title { get; init; }
        
        public string Description { get; init; }
    }
}