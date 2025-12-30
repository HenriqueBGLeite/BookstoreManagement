using BookstoreManagement.Data;
using BookstoreManagement.Exceptions;

namespace BookstoreManagement.UseCase.Books.Delete;

public class DeleteBookUseCase
{
    public void Execute(Guid id)
    {
        var bookInMemory = BookStore.Books.FirstOrDefault(book => book.Id.Equals(id));
        if (bookInMemory is null)
            throw new NotFoundException("Livro não encontrado.");

        BookStore.Books.Remove(bookInMemory);
    }
}
