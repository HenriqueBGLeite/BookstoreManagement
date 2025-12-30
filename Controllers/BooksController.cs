using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Communication.Responses;
using BookstoreManagement.UseCase.Books.Delete;
using BookstoreManagement.UseCase.Books.GetAll;
using BookstoreManagement.UseCase.Books.GetById;
using BookstoreManagement.UseCase.Books.Register;
using BookstoreManagement.UseCase.Books.Update;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestBookJson request)
    {
        var useCase = new RegisterBookUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllBooksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllBooksUseCase();

        var response = useCase.Execute();

        if (response.Books.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var useCase = new GetBookByIdUseCase();

        var response = useCase.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestBookJson request)
    {
        var useCase = new UpdateBookUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteBookUseCase();

        useCase.Execute(id);

        return NoContent();
    }
}
