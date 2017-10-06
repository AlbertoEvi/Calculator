using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalculatorService.Models;

namespace CalculatorService.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }
        public void Add(AddRequest petition)
        {
            int[] nums = petition.Added;

        }
    }
}