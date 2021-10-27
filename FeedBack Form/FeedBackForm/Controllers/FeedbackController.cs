using BusinessLayer.Logics;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackForm.Controllers
{
    public class FeedbackController : Controller
    {
        public FeedbackBL _feedbackBL;
        

        public FeedbackController(FeedbackBL feedbackBL)
        {
            this._feedbackBL = feedbackBL;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackBL.AddFeedback(feedback);

                return RedirectToAction("Index");
            }

            return View(feedback);
        }

    }
}
