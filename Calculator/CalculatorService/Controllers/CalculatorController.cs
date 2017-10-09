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
            result.Result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result.Result += nums[i];
            }
            var hasonServer = JsonConvert.SerializeObject(result);
            return hasonServer;
        }
        
        public string Subtract(SubtractRequest petition)
        {
            int[] nums = petition.Numbers;
            SubtractResponse result = new SubtractResponse();

            result.Result = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if(i!=0)
                    result.Result -= nums[i];
            }
            var hasonServer = JsonConvert.SerializeObject(result);
            return hasonServer;
        }

        public string Multiply(MultRequest petition)
        {
            int[] nums = petition.Multipliers;
            MultResponse result = new MultResponse();
            result.Result = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result.Result *= nums[i];
            }
            var hasonServer = JsonConvert.SerializeObject(result);
            return hasonServer;
        }

        public string Divide(DivRequest petition)
        {
            int[] nums = new int[2];

            nums[0] = petition.Dividend;
            nums[1] = petition.Diviser;

            DivResponse result = new DivResponse();

            result.Quotient = nums[0] / nums[1];
            result.Remainder = nums[0] % nums[1];

            var hasonServer = JsonConvert.SerializeObject(result);
            return hasonServer;
        }
    }
}