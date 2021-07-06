using System;
using System.Collections.Generic;
using System.Linq;
using E_Day_2.Models;
using Microsoft.EntityFrameworkCore;
using static E_Day_2.Services.IService;

namespace E_Day_2.Services
{

    public class AuthorService : IAuthorService
    {
        private DataContext _dataContext;
        public AuthorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Author> GetList()
        {
            return _dataContext.Authors.ToList();
        }

        public Author CreateAuthor(AuthorDTO author)
        {
            var newAuthor = new Author
                {
                    AuthorName = author.AuthorName,

                };
            _dataContext.Authors.Add(newAuthor);
            _dataContext.SaveChanges();

            return newAuthor;
        }

        public List<Author> EditAuthor(AuthorDTO author)
        {
            Author existingAuthor = _dataContext.Authors.Find(author.ID);

            if (existingAuthor == null)
            {
                return new List<Author>();
            }
            else
            {
                existingAuthor.AuthorName = author.AuthorName;


                _dataContext.Entry(existingAuthor).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
            return _dataContext.Authors.ToList();
        }

        public List<Author> IsDelete(AuthorDTO author)
        {
            Author existingAuthor = _dataContext.Authors.Find(author.ID);
            _dataContext.Remove(existingAuthor);
            _dataContext.SaveChanges();
            return _dataContext.Authors.ToList();
        }

        public Author FindByID(int id)
        {
            Author existingAuthor = _dataContext.Authors.Find(id);

            return existingAuthor;
        }

    }

}