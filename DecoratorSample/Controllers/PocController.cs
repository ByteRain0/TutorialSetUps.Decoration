using DecoratorSample.Models;
using DecoratorSample.Services;
using DecoratorSample.Services.GenericApproach;
using DecoratorSample.Services.SimpleExample;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorSample.Controllers;

[ApiController]
public class PocController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    private readonly IRepository<Book> _genericBookRepository;

    public PocController(IBookRepository bookRepository, IRepository<Book> genericBookRepository)
    {
        _bookRepository = bookRepository;
        _genericBookRepository = genericBookRepository;
    }
    
    [HttpPost(nameof(SaveBook))]
    public IActionResult SaveBook(Book book)
    {
        try
        {
            _bookRepository.SaveBook(book);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
        
        return Ok();
    }

    [HttpPost(nameof(SaveBookUsingGenericInterface))]
    public IActionResult SaveBookUsingGenericInterface(Book book)
    {
        try
        {
            _genericBookRepository.Save(book);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
        
        return Ok();
    }
}