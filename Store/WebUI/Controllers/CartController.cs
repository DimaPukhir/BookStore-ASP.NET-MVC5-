﻿using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IBookRepository repo, IOrderProcessor proc)
        {

            repository = repo;
            orderProcessor = proc;
        }
        //public Cart GetCart()
        //{

        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)                          його роботу ми передали CartModelBinder
        //    {

        //        cart = new Cart();
        //        Session["Cart"] = cart;


        //    }
        //    return cart;
        //}
        //
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl

            });

        }
        public RedirectToRouteResult AddToCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {

                cart.AddItem(book, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {

                cart.RemoveLine(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Checkout()
        {

            return View(new ShippingDetails());
        }
        public PartialViewResult Summary(Cart cart)
        {


            return PartialView(cart);
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.lines.Count() == 0)
            {

                ModelState.AddModelError("", "Sorry,your cart is empty");
            }
            if (ModelState.IsValid)
            {

                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");

            }
            else
            {

                return View(new ShippingDetails());


            }


        }
    }
}