using System;
using System.Collections.Generic;
using System.Linq;
using E_Day_2.Models;
using Microsoft.EntityFrameworkCore;
using static E_Day_2.Services.IService;

namespace E_Day_2.Services
{

    public class BookService : IBookService
    {
        private DataContext _dataContext;
        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Book> GetList()
        {
            return _dataContext.Books.ToList();
        }

        public Book CreateBook(BookDTO book)
        {
            var newBook = new Book
                {
                    BookName = book.BookName,
                    ClientID = book.ClientID,
                };
            _dataContext.Books.Add(newBook);
            _dataContext.SaveChanges();

            return newBook;
        }

        public List<Book> EditBook(BookDTO book)
        {
            Book existingBook = _dataContext.Books.Find(book.ID);

            if (existingBook == null)
            {
                return new List<Book>();
            }
            else
            {
                existingBook.BookName = book.BookName;
                existingBook.ClientID = book.ClientID;

                _dataContext.Entry(existingBook).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
            return _dataContext.Books.ToList();
        }

        public List<Book> IsDelete(BookDTO book)
        {
            Book existingBook = _dataContext.Books.Find(book.ID);
            _dataContext.Remove(existingBook);
            _dataContext.SaveChanges();
            return _dataContext.Books.ToList();
        }

        public Book FindByID(int id)
        {
            Book existingBook = _dataContext.Books.Find(id);

            return existingBook;
        }

    }

}