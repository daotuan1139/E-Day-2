using System;
using System.Collections.Generic;
using System.Linq;
using E_Day_2.Models;
using E_Day_2.Services;
using Microsoft.AspNetCore.Mvc;
using static E_Day_2.Services.IService;

namespace E_Day_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private IBookService _bookService;
        private IClientService _clientService;
        private IAuthorService _authorService;

        public BookController(IBookService bookService, IClientService clientService, IAuthorService authorService)
        {
            _bookService = bookService;
            _clientService = clientService;
            _authorService = authorService;
        }

        [HttpGet("Book")]
        public IEnumerable<Book> GetBooks()
        {
            return _bookService.GetList();
        }
        [HttpGet("Client")]
        public IEnumerable<Client> GetClients()
        {
            return _clientService.GetList();
        }
        [HttpGet("Author")]
        public IEnumerable<Author> GetAuthors()
        {
            return _authorService.GetList();
        }

        [HttpPost("Book")]
        public IActionResult AddBook(BookDTO Book)
        {
            var add = _bookService.CreateBook(Book);
            if (add == null)
            {
                return NotFound();
            }
            return Ok(add);
        }
        [HttpPost("Client")]
        public IActionResult AddClient(ClientDTO client)
        {
            var add = _clientService.CreateClient(client);
            if (add == null)
            {
                return NotFound();
            }
            return Ok(add);
        }
        [HttpPost("Author")]
        public IActionResult AddAuthor(AuthorDTO author)
        {
            var add = _authorService.CreateAuthor(author);
            if (add == null)
            {
                return NotFound();
            }
            return Ok(add);
        }

        [HttpPut("Book")]
        public List<Book> UpdateBook(BookDTO Book)
        {
            var update = _bookService.EditBook(Book);
            return update;
        }
        [HttpPut("Client")]
        public List<Client> UpdateClient(ClientDTO client)
        {
            var update = _clientService.EditClient(client);
            return update;
        }
        [HttpPut("Author")]
        public List<Author> UpdateAuthor(AuthorDTO author)
        {
            var update = _authorService.EditAuthor(author);
            return update;
        }

        [HttpGet("Book/{id}")]
        public Book FindByIDBook(int id)
        {
            return _bookService.FindByID(id);
        }
        [HttpGet("Client/{id}")]
        public Client FindByIDClient(int id)
        {
            return _clientService.FindByID(id);
        }
        [HttpGet("Author/{id}")]
        public Author FindByIDAuthor(int id)
        {
            return _authorService.FindByID(id);
        }

        [HttpDelete("Book")]
        public List<Book> IsDeleteBook(BookDTO book)
        {
            var list = _bookService.IsDelete(book);
            return list;
        }
        [HttpDelete("Client")]
        public List<Client> IsDeleteClient(ClientDTO client)
        {
            var list = _clientService.IsDelete(client);
            return list;
        }
        [HttpDelete("Author")]
        public List<Author> IsDeleteAuthor(AuthorDTO author)
        {
            var list = _authorService.IsDelete(author);
            return list;
        }
    }


}