using BookstoreManagement.Communication.Responses;
using BookstoreManagement.Data;
using BookstoreManagement.Exceptions;

namespace BookstoreManagement.UseCase.Books.GetById;

public class GetBookByIdUseCase
{
    public ResponseBookJson Execute(Guid id)
    {
        var book = BookStore.Books.FirstOrDefault(book => book.Id.Equals(id));
        if (book is null)
            throw new NotFoundException("Livro não encontrado.");

        return new ResponseBookJson
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            Stock = book.Stock,
            CreatedAt = book.CreatedAt,
            UpdateAt = book.UpdatedAt,
        };
    }
}
