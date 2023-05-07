using BooksApp.Data;
using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController( ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> bookList = _db.BooksDb.ToList();
            return View(bookList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book? book)
        {
            if(ModelState.IsValid)
            {
                _db.BooksDb.Add(book);
                _db.SaveChanges();
                TempData["success"] = "Book Created Successfully!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            if (id != null || id != 0) 
            {
                Book book = _db.BooksDb.FirstOrDefault(u => u.Id == id);
                return View(book);
            }
           else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.BooksDb.Update(book);
                _db.SaveChanges();
                TempData["success"] = "Book Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if( id  != null || id != 0)
            {
                Book book = _db.BooksDb.FirstOrDefault(u => u.Id == id);
                return View(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Book book = _db.BooksDb.FirstOrDefault(u => u.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _db.BooksDb.Remove(book);
            _db.SaveChanges();
            TempData["success"] = "Book Deleted Successfully!";
            return RedirectToAction("Index", "Book");
        }
    }
}
