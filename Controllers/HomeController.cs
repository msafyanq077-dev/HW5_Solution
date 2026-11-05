using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // In-memory static lists as required by Lab instructions
        private static List<Author> _authors = new List<Author>
        {
            new Author { Id = 1, Name = "James Clear", Country = "UK" },
            new Author { Id = 2, Name = "Ibn Khuldon", Country = "Egypt" }
        };

        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Atomic Habits", Price = 500.00m, AuthorId = 1 },
            new Book { Id = 1, Title = "The Psychology of Money", Price = 700.00m, AuthorId = 1 },
            new Book { Id = 2, Title = "The Muqaddimah", Price = 5000.00m, AuthorId = 2 }
        };

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Authors = _authors,
                Books = _books.Select(b => new BookCardViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    AuthorName = _authors.FirstOrDefault(a => a.Id == b.AuthorId)?.Name ?? ""
                }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddBook(string Title, decimal Price, int Author)
        {
            int newId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(new Book { Id = newId, Title = Title, Price = Price, AuthorId = Author });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddAuthor(string Name, string Country)
        {
            int newId = _authors.Any() ? _authors.Max(a => a.Id) + 1 : 1;
            _authors.Add(new Author { Id = newId, Name = Name, Country = Country });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
            return RedirectToAction("Index");
        }

        public IActionResult About() => View();
        public IActionResult Contact() => View();
    }
}