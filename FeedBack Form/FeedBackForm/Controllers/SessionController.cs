using BusinessLayer.Logics;
using DataAccessLayer.Data;
using DataAccessLayer.Model;
//using DataAccessLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackForm.Controllers
{
    public class SessionController : Controller
    {
        public SessionBL _sessionBL;
       
        public FeedBackDBContext _db;

        public SessionController(SessionBL sessionBL, FeedBackDBContext db)
        {
            this._sessionBL = sessionBL;
            this._db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Session> sessionList = (IEnumerable<Session>)await _sessionBL.GetAllSessions();

            return View(sessionList);
        }


        public IActionResult Create2()
        {


            IEnumerable<SelectListItem> listConductors = _db.Users.Select(x =>
            new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });



            ViewBag.conductors = listConductors;




            return View();
        }

        [HttpPost]
        public IActionResult Create2(Session session)
        {
            if (ModelState.IsValid)
            {
                _sessionBL.AddSession(session);

                return RedirectToAction("Index");
            }

            return View(session);
        }

    }
}
