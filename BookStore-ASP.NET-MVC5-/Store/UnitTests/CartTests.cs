using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Add_New_Lines()
        {
            //Organization
            Book book1 = new Book { BookId = 1, Name = "Book1" };
            Book book2 = new Book { BookId = 2, Name = "Book2" };
            Cart cart = new Cart();
            cart.AddItem(book1, 1);
            cart.AddItem(book2, 1);
            //Action
            List<CartLine> results = cart.lines.ToList();

            //Statement
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Book, book1);
            Assert.AreEqual(results[1].Book, book2);

        }

        [TestMethod]
        public void Add_Quantity_For_Existing_Lines()
        {
            //Organization
            Book book1 = new Book { BookId = 1, Name = "Book1" };
            Book book2 = new Book { BookId = 2, Name = "Book2" };
            Cart cart = new Cart();
            cart.AddItem(book1, 1);
            cart.AddItem(book2, 1);
            cart.AddItem(book1, 5);
            //Action
            List<CartLine> results = cart.lines.OrderBy(c=>c.Book.BookId).ToList();

            //Statement
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Quantity, 6);
            Assert.AreEqual(results[1].Quantity, 1);

        }
        [TestMethod]
        public void Remove_Lines()
        {
            //Organization
            Book book1 = new Book { BookId = 1, Name = "Book1" };
            Book book2 = new Book { BookId = 2, Name = "Book2" };
            Cart cart = new Cart();
            cart.AddItem(book1, 1);
            cart.AddItem(book2, 1);
            cart.RemoveLine(book1);
            //Action
            List<CartLine> results = cart.lines.OrderBy(c => c.Book.BookId).ToList();

            //Statement
            Assert.AreEqual(cart.lines.Where(b=>b.Book==book1).Count(),0);
            
           

        }
        [TestMethod]
        public void Calculate_Lines()
        {
            //Organization
            Book book1 = new Book { BookId = 1, Name = "Book1",Price=100 };
            Book book2 = new Book { BookId = 2, Name = "Book2", Price=55};
            Cart cart = new Cart();
            cart.AddItem(book1, 1);
            cart.AddItem(book2, 1);
            cart.AddItem(book1, 5);

            //Action
            decimal result = cart.ComputeTotalValue();

            //Statement
            Assert.AreEqual(result, 655);



        }
        [TestMethod]
        public void Clear_Lines()
        {
            //Organization
            Book book1 = new Book { BookId = 1, Name = "Book1", Price = 100 };
            Book book2 = new Book { BookId = 2, Name = "Book2", Price = 55 };
            Cart cart = new Cart();
            cart.AddItem(book1, 1);
            cart.AddItem(book2, 1);
            cart.AddItem(book1, 5);
            cart.Clear();

            //Action
            decimal result = cart.ComputeTotalValue();

            //Statement
            Assert.AreEqual(cart.lines.Count(),0);



        }
    }
}
