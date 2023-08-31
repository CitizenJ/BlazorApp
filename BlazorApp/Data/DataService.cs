using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;
using BlazorApp.DataAccess;

namespace BlazorApp.Data
{
    public class DataService
    {
        DataAccessLayer data = new DataAccessLayer();

        public Task<List<Book>> GetBooks()
        {
            return Task.FromResult(data.GetBooks());
        }

        public Task<List<Author>> GetAuthors()
        {
            return Task.FromResult(data.GetAuthors());
        }

        public Task<List<Publisher>> GetPublishers()
        {
            return Task.FromResult(data.GetPublishers());
        }

        public Author AuthorDetails(int id)
        {
            return data.GetAuthor(id);
        }

        public Task<List<Book>> GetBooksByAID(int id)
        {
            return Task.FromResult(data.GetBooksByAID(id));
        }

        public string GetPNameByBookPID(int id)
        {
            return data.GetPNameByBookPID(id);
        }

        public Task<string> GetPNameByBookPIDAsync(int id)
        {
            return Task.FromResult(data.GetPNameByBookPID(id));
        }
        public Task<int> GetBookCount()
        {
            return Task.FromResult(data.GetBookCount());
        }

        public Task<int> GetLastBID()
        {
            return Task.FromResult(data.GetLastBID());
        }

        public Task<int> GetLastAID()
        {
            return Task.FromResult(data.GetLastAID());
        }

        public Task<Book> BookDetails(int id)
        {
            return Task.FromResult(data.GetBook(id));
        }

        public void Create(Book book)
        {
            data.AddBook(book);
        }

        public void CreateA(Author author)
        {
            data.AddAuthor(author);
        }

        public async Task CreateAsync(Book book)
        {
            await data.AddBookAsync(book);
        }

        public void Edit(Book book)
        {
            data.UpdateBook(book);
        }

        public void Delete(int id)
        {
            data.DeleteBook(id);
        }

        
    }
}
