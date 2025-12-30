using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Communication.Responses;
using BookstoreManagement.Data;
using BookstoreManagement.Exceptions;
using BookstoreManagement.Models;
using BookstoreManagement.UseCase.Books.SharedValidator;

namespace BookstoreManagement.UseCase.Books.Register;

public class RegisterBookUseCase
{
    public ResponseShortBookJson Execute(RequestBookJson request)
    {
        Validate(request);

        var dateCreated = DateTime.UtcNow;

        var newBook = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = dateCreated,
            UpdatedAt = dateCreated,
        };

        BookStore.Books.Add(newBook);

        return new ResponseShortBookJson
        {
            Id = newBook.Id,
            Title = newBook.Title,
            Author = newBook.Author
        };
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
