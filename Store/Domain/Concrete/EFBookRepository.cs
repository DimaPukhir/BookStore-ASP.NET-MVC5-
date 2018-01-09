using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFBookRepository:IBookRepository
    {
        EFDbContext db = new EFDbContext();
        public IEnumerable<Book> Books { get { return db.Books;  }  }

        public void DeleteBook(Book book)
        {
            Book delBook = db.Books.Find(book.BookId);
            if (delBook!=null) {

                db.Books.Remove(delBook);

            }
            db.SaveChanges();
        }

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {

                db.Books.Add(book);

            }
            else
            {
                Book dbEntry = db.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Name = book.Name;
                    dbEntry.Description = book.Description;
                    dbEntry.Author = book.Author;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Price = book.Price;



                }


            }
            db.SaveChanges();
        }
    }
}
