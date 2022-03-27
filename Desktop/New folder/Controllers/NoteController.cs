using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Library_All.Models.DTOs;
using WebApp_Library_All.Models.Entities;
using WebApp_Library_All.Services;

namespace WebApp_Library_All.Controllers
{
    public class NoteController: Controller
    {
        private NoteService noteService;
        private UserManager<User> userManager;

        public NoteController(NoteService noteService)
        {
            this.noteService = noteService;
        }

        public IActionResult Index()
        {
            List<NoteDTO> products = noteService.GetAll();

            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Note note)
        {
            User user = await userManager.GetUserAsync(User);
            note.User = user;
            noteService.Add(note, user);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Note note = noteService.GetById(id);

            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            noteService.Edit(note);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Note note = noteService.GetById(id);
            return View(note);
        }
    }
}
