using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
            
        }
        public async Task<IActionResult> Index()
        {
            var Books = await _bookService.GetBooksAsync();
            return View(Books);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            // to check if model is valid
            if (ModelState.IsValid)
            {
                await _bookService.AddBookAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            // if book to be updated not equal book id
            if (id != book.Id)
            {
                return BadRequest();
            }

            // if there is any error in the model
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBookAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }


}
