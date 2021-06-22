using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class EditBookController : Controller
    {
        // GET: EditBook
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS the complete manual ", "author name book 1", "/Content/Image/book1cover.jpg"));
            books.Add(new Book(2, "HTML & CSS  responsive web design cookbook", "author name book 2", "/Content/Image/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.Net MVCS", "author name book 3", "/Content/Image/book3cover.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
    }
}