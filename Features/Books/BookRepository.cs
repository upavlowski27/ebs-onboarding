using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace EBS.Onboarding.Web.Features.Books
{
    public class BookRepository
    {
        private readonly IDynamoDBContext _dynamoContext;

        public BookRepository(IDynamoDBContext dynamoContext)
        {
            _dynamoContext = dynamoContext;
        }

        public async Task<Book> Load(string isbn)
            => await _dynamoContext.LoadAsync<Book>(isbn);

        public async Task Create(Book book)
        {
            await _dynamoContext.SaveAsync(book);
        }
        
        public async Task Update(Book book)
        {
            var bookToModify = await Load(book.ISBN);
            if (bookToModify != null)
                bookToModify = book with { Title = book.Title, Description = book.Description };
            
            await _dynamoContext.SaveAsync(bookToModify);
        }
        
        public async Task Delete(string isbn)
        {
            await _dynamoContext.DeleteAsync<Book>(isbn);
        }
    }
}