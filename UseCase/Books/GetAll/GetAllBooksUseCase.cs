using BookstoreManagement.Communication.Responses;
using BookstoreManagement.Data;

namespace BookstoreManagement.UseCase.Books.GetAll;

public class GetAllBooksUseCase
{
    public ResponseAllBooksJson Execute()
    {
        var books = BookStore.Books.ToList();

        return new ResponseAllBooksJson
        {
            Books = [..books.Select(book => new ResponseShortBookJson {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
            })]
        };
    }
}
