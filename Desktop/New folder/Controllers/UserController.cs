using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Library_All.Models.DTOs;
using WebApp_Library_All.Models.Entities;

namespace WebApp_Library_All.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;

        public UserController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details()
        {
            User user = await userManager.GetUserAsync(User);

            UserDTO userDTO = new UserDTO();
            userDTO.Email = user.Email;
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;

            return View(userDTO);
        }
    }
}
