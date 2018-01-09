using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IBookRepository repository;
        public NavigationController(IBookRepository repo) {
            repository = repo;
        }
        public PartialViewResult Menu()
        {
            IEnumerable<string> genres = repository.Books
                .Select(b => b.Genre)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(genres);

            
        }
    }
}