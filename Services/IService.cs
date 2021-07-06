using System;
using System.Collections.Generic;
using E_Day_2.Models;


namespace E_Day_2.Services
{

    public interface IService
    {
        interface IBookService
        {
            IEnumerable<Book> GetList();
            Book CreateBook(BookDTO book);
            List<Book> EditBook(BookDTO book);
            List<Book> IsDelete(BookDTO book);
            Book FindByID(int id);
        }
        interface IAuthorService{
            IEnumerable<Author> GetList();
            Author CreateAuthor(AuthorDTO book);
            List<Author> EditAuthor(AuthorDTO book);
            List<Author> IsDelete(AuthorDTO book);
            Author FindByID(int id);
        }
        interface IClientService{
            IEnumerable<Client> GetList();
            Client CreateClient(ClientDTO book);
            List<Client> EditClient(ClientDTO book);
            List<Client> IsDelete(ClientDTO book);
            Client FindByID(int id);
        }



    }

}