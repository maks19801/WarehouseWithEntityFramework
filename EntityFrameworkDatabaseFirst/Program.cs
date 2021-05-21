using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            /*using(DatabaseFirstContext dBFirst = new DatabaseFirstContext())
            {
                dBFirst.Users.Add(new User { Name = "Gil", Age = 55 });
                dBFirst.SaveChanges();
                var users = dBFirst.Users.ToList();
                foreach(var user in users)
                {
                    Console.WriteLine($"{user.Id},{user.Name},{user.Age}");
                }
            }*/
            Init();
            GetAllBooks();
            
        }
        static void Init()
        {
            Author author = new Author
            {
                FirstName =
            "Ray",
                LastName = "Bradbury"
            };
            AddAuthor(author);
            author = new Author
            {
                FirstName = "Harry",
                LastName = "Harrison"
            };
            AddAuthor(author);
            author = new Author
            {
                FirstName = "Clifford",
                LastName = "Simak"
            };
            AddAuthor(author);
            Publisher publisher = new Publisher
            {
                PublisherName = "Rainbow",
                Address = "Kyiv"
            };
            AddPublisher(publisher);
            publisher = new Publisher
            {
                PublisherName =
            "Exlibris",
                Address = "Kyiv"
            };
            AddPublisher(publisher);
            Book book = new Book
            {
                Title = "Way Station",
                IdPublisher = 1,
                IdAuthor = 4,
                Pages = 350,
                Price = 85
            };
            AddBook(book);
            book = new Book
            {
                Title = "Ring Around the Sun", IdPublisher = 1, IdAuthor = 3,
            Pages = 420,
                Price = 99
            };
            AddBook(book);
            book = new Book
            {
                Title = "The Martian Chronicles", IdPublisher = 2, IdAuthor = 2,
            Pages = 410,
                Price = 105
            };
            AddBook(book);
            book = new Book
            {
                Title = "I, Robot",
                IdPublisher = 2,
                IdAuthor = 1,
                Pages = 378,
                Price = 100
            };
            AddBook(book);
        }
        static void AddPublisher(Publisher publisher)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Publisher a = db.Publishers.Where((x) =>
                x.PublisherName == publisher.
                PublisherName).FirstOrDefault();
                if (a == null)
                {
                    db.Publishers.Add(publisher);
                    db.SaveChanges();
                    Console.WriteLine("New publisher added: " + publisher.PublisherName);
                }
            }
        }
        static void AddBook(Book book)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Book a = db.Books.Where((x) => x.Title ==
                book.Title).FirstOrDefault();
                if (a == null)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    Console.WriteLine("New book added:" +
                    book.Title);
                }
            }
        }
        static void AddAuthor(Author author)
        {
            using (LibraryContext db = new LibraryContext())
            {
                Author a = db.Authors.Where((x) => x.FirstName ==
                author.FirstName).FirstOrDefault();
                if (a == null)
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                    Console.WriteLine("New author added:" +
                    author.LastName);
                }
            }
        }
        static void GetAllBooks()
        {
            using (LibraryContext db = new LibraryContext())
            {
                var books = db.Books.Include(_=>_.IdAuthorNavigation).ToList();
                foreach (var a in books)
                {
                    Console.WriteLine("Книга: " + a.Title
                                    + " цена: " + a.Price
                                    + " автор: " + a.IdAuthorNavigation.FirstName + " "
                                    + a.IdAuthorNavigation.LastName);
                }
            }
        }
    }
}
