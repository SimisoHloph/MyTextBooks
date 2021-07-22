using My_Books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Books.Data.Service
{
    public class BooksService
    {
        private readonly AppDbContext _context;
        public BooksService( AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();

        public Book GetBook(int bookId) => _context.Books.FirstOrDefault( n => n.Id ==bookId);

        public Book UpdateBook(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
                _book.DateAdded = DateTime.Now;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBook(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book !=null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
