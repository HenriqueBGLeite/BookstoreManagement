using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Data;
using BookstoreManagement.Exceptions;
using BookstoreManagement.UseCase.Books.SharedValidator;

namespace BookstoreManagement.UseCase.Books.Update;

public class UpdateBookUseCase
{
    public void Execute(Guid bookId, RequestBookJson request)
    {
        Validate(request);

        var bookInMemory = BookStore.Books.FirstOrDefault(book => book.Id.Equals(bookId));
        if (bookInMemory is null)
            throw new NotFoundException("Livro não encontrado.");

        bookInMemory.Title = request.Title;
        bookInMemory.Author = request.Author;
        bookInMemory.Genre = request.Genre;
        bookInMemory.Price = request.Price;
        bookInMemory.Stock = request.Stock;
        bookInMemory.UpdatedAt = DateTime.Now;
    }

    private void Validate(RequestBookJson request)
    {
        var validator = new RequestBookValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
