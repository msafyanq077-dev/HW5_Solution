using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeViewModel
    {
        public List<BookCardViewModel> Books { get; set; } = new List<BookCardViewModel>();
        public List<Author> Authors { get; set; } = new List<Author>();

    }
}