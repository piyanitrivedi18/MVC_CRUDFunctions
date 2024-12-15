using Day5_MVCDemos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day5_MVCDemos.Controllers
{
    public class UserController : Controller
    {
        static List<User> users = null;
        public UserController()
        {
            if(users==null)
            {
                users = new List<User>()
                {

                };
            }

        }
        // GET: UserController
        public ActionResult Index()
        {
            if (users.Count == 0)
                ViewBag.msg = "There are no users";
            return View(users.ToList());
        }

        // value type variables are not nullable, they dont allow to store null
        // GET: UserController/Details/5
        public ActionResult Details(int? id)
        {
            User user = null;
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a valid ID";


            }

            else
            {
                user = users.Where(x => x.UserId == id).FirstOrDefault();
                if (user == null)
                    ViewBag.msg = "User with ID do not exist";
            }
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    users.Add(user);

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.msg = "Please provide a valid ID";

            }
            var user = users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
                ViewBag.msg = "User with ID do not exist";

            return View(user);

        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                foreach (var item in users)
                {
                    if (item.UserId == id)
                    {
                        item.Password = user.Password;
                    }
                    break;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {

            if (id == null)
            {
                ViewBag.msg = "Please provide a valid ID";

            }
            var user = users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
                ViewBag.msg = "User with ID do not exist";

            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try

            {
                var user = users.Where(x=>x.UserId == id).FirstOrDefault(); 
                users.Remove(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
