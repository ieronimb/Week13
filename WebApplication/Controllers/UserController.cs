using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Students.Web.Models;

namespace Students.Web.Controllers
{
    public class UserController : Controller
    {
        private static readonly List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel { Id = 1, Email = "dan@yahoo.com", UserName = "dan", Address = new AddressViewModel()},
            new UserViewModel { Id = 2, Email = "andrei@yahoo.com", UserName = "andrei", Address = new AddressViewModel()},
            new UserViewModel { Id = 3, Email = "vlad@yahoo.com", UserName = "vlad", Address = new AddressViewModel()},
        };  

        [HttpGet]
        public ActionResult Index()
        {
            return View(Users);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = Users.FirstOrDefault(x => x.Id == id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Users.FirstOrDefault(x => x.Id == id);

            return View("Add", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteUser = Users.FirstOrDefault(x => x.Id == id);
            
            Users.Remove(deleteUser);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", user);
            }

            if (user.Id != null && user.Id != 0)
            {
                var existingUser = Users.Find(x => x.Id == user.Id);
                existingUser.Address = user.Address;
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;
            }
            else
            {
                user.Id = Users.Count + 1;
                Users.Add(user);
            }

            return RedirectToAction("Index");
        }
    }
}