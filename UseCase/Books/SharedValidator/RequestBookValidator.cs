using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Data;
using FluentValidation;

namespace BookstoreManagement.UseCase.Books.SharedValidator;

public class RequestBookValidator : AbstractValidator<RequestBookJson>
{
    private readonly List<string> _allowedGenres =
    [
        "Ficção",
        "Ação",
        "Romance",
        "Mistério",
        "Aventura",
        "Infantil"
    ];

    public RequestBookValidator()
    {
        RuleFor(book => book.Title)
            .NotEmpty().WithMessage("O Título não pode ser vazio")
            .Length(2, 120).WithMessage("O Título deve estar entre 2 e 120 caracteres");
        RuleFor(book => book.Author)
            .NotEmpty().WithMessage("O Autor não pode ser vazio")
            .Length(2, 120).WithMessage("O Autor deve estar entre 2 e 120 caracteres");
        RuleFor(book => book.Genre)
            .NotEmpty().WithMessage("O gênero não pode ser vazio")
            .Must(genre => _allowedGenres.Contains(genre)).WithMessage($"Gênero inválido. Os gêneros aceitos são: {string.Join(", ", _allowedGenres)}");
        RuleFor(book => book.Price)
            .GreaterThanOrEqualTo(0).WithMessage("O preço tem que ser maior ou igual a 0.");
        RuleFor(book => book.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("O estoque tem que ser maior ou igual a 0.");
        RuleFor(book => book)
            .Must(request => !BookStore.Books.Any(b => b.Title.Equals(request.Title) && b.Author.Equals(request.Author)))
            .WithMessage("Este autor já possui um livro com esse título.");
    }
}
