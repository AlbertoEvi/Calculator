using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Calculator
{
    public class Mediator
    {
        public static string url = "http://localhost:51186/Calculator/";
        public static string sum;
        #region add
        public void Add(string trackingId)
        {
            Console.WriteLine("------Add Operation------");
            Console.WriteLine("Type the sum you want to do(ex:13 + 12 + 5): ");

            char symb = '+';
            sum = Console.ReadLine();
            string[] nums = sum.Split(symb);

            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i].Trim());
                Console.WriteLine(numbers[i]);
            }
            
            AddRequest addition = new AddRequest(); 
            AddResponse result = new AddResponse();
                        
            addition.Added = numbers;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}Add");
            request.Method = "POST";
            request.ContentType = "application/json";
            
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                var jason = JsonConvert.SerializeObject(addition);
                dataStream.Write(jason);
                dataStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stRead = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine("The server operation's result is:");
                result = JsonConvert.DeserializeObject<AddResponse>(stRead.ReadToEnd());
                Console.WriteLine(result.Sum);
                stRead.Close();
            }
        }
        #endregion
        #region subtraction
        public void Subt(string trackingId)
        {
            SubtractRequest subtract = new SubtractRequest();
            SubtractResponse result = new SubtractResponse();
        }
        #endregion
        #region multiply
        public void Mult(string trackingId)
        {
            MultRequest multiply = new MultRequest();
            MultResponse result = new MultResponse();
        }
        #endregion
        #region division
        public void Div(string trackingId)
        {
            DivRequest division = new DivRequest();
            DivResponse result = new DivResponse();
        }
        #endregion
    }
}
