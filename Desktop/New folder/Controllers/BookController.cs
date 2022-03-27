using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApp_Library_All.Models;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Library_All.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using WebApp_Library_All.Models.Entities;
using WebApp_Library_All.Services;

namespace WebApp_Library_All
{
    public class BookController : Controller
    {
        private BookService bookService;
        private UserManager<User> userManager;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            List<BookDTO> products = bookService.GetAll();

            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Book book)
        {
            User user = await userManager.GetUserAsync(User);
            book.User = user;
            bookService.Add(book, user);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Book book = bookService.GetById(id);

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            bookService.Edit(book);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Book book = bookService.GetById(id);
            return View(book);
        }

    }
}
