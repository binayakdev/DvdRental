/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Semester2Coursework.Models;

namespace Semester2Coursework.Controllers
{
    public class UserAndRolesController : Controller
    {
        // GET: UserAndRoles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddUserToRole()
        {
            ApplicationUserRoleViewModel vm = new ApplicationUserRoleViewModel();
            var Users = await dbCon.Users.ToListAsync();
            var roles = await dbCon.Roles.ToListAsync();
            ViewBag.UserId = new SelectList(Users, "Id", "UserName");
            ViewBag.RoleId = new SelectList(roles, "Id", "Name");
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserToRole(ApplicationUserRoleViewModel model)
        {
            var role = dbCon.Roles.Find(model.RoleId);
            if (role != null)
            {
                await UserManager.AddToRoleAsync(model.UserId, role.Name);
            }
            return RedirectToAction("AddUserToRole");

        }
    }
}*/