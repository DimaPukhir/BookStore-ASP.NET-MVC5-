using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IBookRepository repository;
        public AdminController(IBookRepository repo)
        {
            repository = repo;

        }
        public ViewResult Index()
        {
            return View(repository.Books);
        }
        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            return View(book);


        }
        [HttpPost]
        public ActionResult Edit(Book book) {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["Message"] = string.Format("Changes in books \"{0}\" were save", book.Name);
                return RedirectToAction("Index");


            }
            else { return View(book); }

        }
        public ViewResult Create() {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {

                repository.SaveBook(book);
                TempData["Message"] = string.Format("New book \"{0}\" was added succsess", book.Name);
                return RedirectToAction("Index");

            }
            else
            {
                return View(book);
            }
        }
        public ViewResult Delete(int bookId) {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            return View(book);
        
        }
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            repository.DeleteBook(book);
            TempData["Message"] = string.Format("Book was delete ");
            return RedirectToAction("Index");

        }
        
    }
}