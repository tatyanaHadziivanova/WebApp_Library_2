using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Library_All.Models;
using WebApp_Library_All.Models.DTOs;
using WebApp_Library_All.Models.Entities;

namespace WebApp_Library_All.Services
{
    public class NoteService
    {
        private LibraryDbContext dbContext;

        public NoteService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<NoteDTO> GetAll()
        {
            return dbContext.Notes
                .Include(p => p.User)
                .Select(p => ToDto(p))
                .ToList();
        }
        public void Add(Note note, User user)
        {
            note.User = user;

            dbContext.Notes.Add(note);
            dbContext.SaveChanges();
        }

        public Note GetById(int id)
        {
            return dbContext.Notes.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Note note)
        {
            Note dbNote = GetById(note.Id);

            dbNote.Title = note.Title;
            dbNote.Text = note.Text;


            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Note dbNote = GetById(id);
            dbContext.Notes.Remove(dbNote);
            dbContext.SaveChanges();
        }
        //njdkkdbdkdk

        private static NoteDTO ToDto(Note b)
        {
            NoteDTO note = new NoteDTO();

            note.Id = b.Id;
            note.Title = b.Title;
            note.Text = b.Text;
            note.CreatedBy = $"{b.User.FirstName} {b.User.LastName}";
            note.UserEmail = b.User.Email;

            return note;
        }
    }
}
