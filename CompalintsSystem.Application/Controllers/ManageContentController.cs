using CompalintsSystem.Core.ViewModels;
using CompalintsSystem.Core.Models;
using CompalintsSystem.EF.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompalintsSystem.Application
{
    [Authorize(Roles = "AdminGeneralFederation")]
    public class ManageContentController : Controller
    {
        private readonly AppCompalintsContextDB _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageContentController(AppCompalintsContextDB context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public ActionResult TypeCommuncations()
        {
            //List<CategoryCommuncationVM> listCate = _context.TypeCommunications.Select(x => new CategoryCommuncationVM { Type = x.Type, UserId = x.UserId, UsersNameAddType = x.UsersNameAddType }).ToList();

            //ViewBag.CategoryList = listCate;

            return View();
        }
        public IActionResult GetData()
        {
            IEnumerable<CategoryCommuncationVM> list = _context.TypeCommunications.Select(x => new CategoryCommuncationVM { Type = x.Type, UserId = x.UserId, UsersNameAddType = x.UsersNameAddType }).ToList();
            return Json(list);
        }
        public IActionResult find(int id)
        {
            TypeCommunication user = _context.TypeCommunications.Find(id);
            return Json(user);
        }

        public async Task<IActionResult> update(int id, string Type)
        {
            var userAdded = await _userManager.GetUserAsync(User);
            TypeCommunication user;
            if (id != 0) user = _context.TypeCommunications.Find(id);
            else user = new TypeCommunication();
            user.Type = Type;
            user.UsersNameAddType = userAdded.FullName;
            user.UserId = userAdded.UserId;
            user.CreatedDate = DateTime.Now;

            if (id == 0) _context.TypeCommunications.Add(user);
            else _context.TypeCommunications.Update(user);


            _context.SaveChanges();
            return Json(new { msg = "Successfully Change adding user " });
        }
        [HttpPost]
        public IActionResult del(int id)
        {
            TypeCommunication zv = _context.TypeCommunications.Find(id);
            if (id != 0)
            {

                _context.TypeCommunications.Remove(zv);
                _context.SaveChanges();
                return Json(new { msg = "Remove Successfully" });

            }
            return Json(new { msg = "Successfully Change not  " });
        }


        public async Task<IActionResult> AddEditCategory(int id)
        {
            var userHasChaing = await _userManager.GetUserAsync(User);

            var userId = userHasChaing.Id;
            TypeCommunication model = new TypeCommunication();
            try
            {
                if (id != null)
                {
                    TypeCommunication type = _context.TypeCommunications.SingleOrDefault(x => x.Id == id);
                    model.Id = type.Id;
                    model.Type = type.Type;
                    model.UserId = type.UserId = userHasChaing.UserId;
                    model.UsersNameAddType = type.UsersNameAddType = userHasChaing.FullName;

                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return PartialView("_CommunicationPartial", model);
        }

        public IActionResult TypeCompalints()
        {
            return View();
        }
    }
}
