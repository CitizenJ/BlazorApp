using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Models;

namespace BlazorApp.DataAccess
{
    public class DataAccessLayer
    {
        BlazorContext bc = new();

        public List<Book> GetBooks()
        {
            try
            {
                return bc.Books.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Author> GetAuthors()
        {
            try
            {
                return bc.Authors.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Publisher> GetPublishers()
        {
            try
            {
                return bc.Publishers.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Book GetBook(int id)
        {
            try
            {
                Book book = bc.Books.Find(id);
                return book;
            }
            catch
            {
                throw;
            }
        }

        public Author GetAuthor(int id)
        {
            try
            {
                Author author = bc.Authors.Find(id);
                return author;
            }
            catch
            {
                throw;
            }
        }

        public List<Book> GetBooksByAID(int id)
        {
            try
            {
                List<Book> books = (from b in bc.Books
                                    where b.AuthorId == id
                                    orderby b.PublicationDate ascending
                                    select b).ToList();
                return books;
            }
            catch
            {
                throw;
            }
        }

        public int GetBookCount()
        {
            try
            {
                int count = (from b in bc.Books
                             select b).Count();
                return count;
            }
            catch
            {
                throw;
            }
        }

        public string GetPNameByBookPID(int id)
        {
            try
            {
                string pname = (from p in bc.Publishers
                                where p.Id == id
                                select p.Name).First().ToString();
                return pname;
            }
            catch
            {
                throw;
            }
        }

        public int GetLastBID()
        {
            try
            {
                string idt = (from b in bc.Books
                              orderby b.Id ascending
                              select b.Id
                          ).Last().ToString();
                int id = int.Parse(idt);
                return id;
            }
            catch
            {
                throw;
            }
        }

        public int GetLastAID()
        {
            try
            {
                string idt = (from a in bc.Authors
                          orderby a.Id ascending
                          select a.Id
                          ).Last().ToString();
                int id = int.Parse(idt);
                return id;
            }
            catch
            {
                throw;
            }
        }

        public void AddBook(Book book)
        {
            try
            {
                bc.Books.Add(book);
                bc.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddAuthor(Author author)
        {
            try
            {
                bc.Authors.Add(author);
                bc.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        
        public async Task AddBookAsync(Book book)
        {
            try 
            {
                bc.Books.Add(book);
                _ = await bc.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                bc.Entry(book).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteBook(int id)
        {
            try
            {
                Book book = bc.Books.Find(id);
                bc.Books.Remove(book);
                bc.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
