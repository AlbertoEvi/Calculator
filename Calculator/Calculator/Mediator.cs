using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Models;
using System.Net;
using System.IO;

namespace Calculator
{
    public class Mediator
    {
        public static string url = "http://localhost:51186/Calculator/";
        #region add
        public void Add(string trackingId)
        {
            AddRequest addition = new AddRequest();
            AddResponse result = new AddResponse();

            int[] numbers = new int[] {};
            
            addition.Added = numbers;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}Add");
            request.Method = "POST";
            request.ContentType = "application/json";
            
            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                dataStream.Write(addition.Added);
                dataStream.Close();
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
