using lab2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;

namespace lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string Universcsity)
        {
            return "hello Nguyen Van Sen- University" + Universcsity;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS the complete manual - autor name book1");
            books.Add("HTML5 & CSS the complete manual - autor name book1");
            books.Add("HTML5 & CSS the complete manual - autor name book1");
            ViewBag.Books = books;

            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS the complete manual ", "author name book 1", "/Content/Image/book1cover.jpg"));
            books.Add(new Book(2, "HTML & CSS  responsive web design cookbook", "author name book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.Net MVCS", "author name book 3", "/Content/Image/book3cover.jpg"));
            return View(books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, Image_cover")] Book bookData)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "html5 & css3 the the complate manual", "author name book 1", "/Content/images/imageBook.jpg"));
            books.Add(new Book(2, "html5 & css3 responsive web design cookbook", "author name book 2", "/Content/images/imageBook.jpg"));
            books.Add(new Book(3, "professional asp.net", "author name book 3", "/Content/images/imageBook.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(bookData);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error save data");
            }
            return View("ListBookModel", books);
        }
    }
}