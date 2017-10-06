using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalculatorService.Models;
using Newtonsoft.Json;

namespace CalculatorService.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }
        public string Add(AddRequest petition)
        {
            int[] nums = petition.Added;
            AddResponse result = new AddResponse();
            result.Sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result.Sum += nums[i];
            }
            var hasonServer = JsonConvert.SerializeObject(result);
            return hasonServer;
        }
    }
}