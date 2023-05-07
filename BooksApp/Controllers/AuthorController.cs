using BooksApp.Data;
using BooksApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController( ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Author> authorList = _db.AuthorDb.ToList().Select(u => new SelectListItem
            {
                Text = u.Book.BookTitle
                Value = u.BookId.ToString()
            }) ;
            return View(authorList);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _db.AuthorDb.Add(author);
                _db.SaveChanges();
                TempData["success"] = "Author Created Successfully!";
                return RedirectToAction("Index", "Author");
            }
            return View(author);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Author? author = _db.AuthorDb.FirstOrDefault(u => u.Id == id);
            return View(author);
        }
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid) 
            { 
                _db.AuthorDb.Update(author);
                _db.SaveChanges();
                TempData["success"] = "Author Updated Successfully!";
                return RedirectToAction("Index", "Author");
            }
            return View(author);
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Author? author = _db.AuthorDb.FirstOrDefault(u =>u.Id == id);
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Author author)
        {
            if(author == null)
            {
                return NotFound();
            }
            _db.AuthorDb.Remove(author);
            _db.SaveChanges();
            TempData["success"] = "Author Deleted Successfully!";
            return RedirectToAction("Index", "Author");
        }
    }
}
