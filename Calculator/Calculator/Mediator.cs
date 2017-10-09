﻿using System;
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

        #region add

        public void Add(string trackingId)
        {
            #region AddStuff

            Console.WriteLine("------Addition Operation------");
            Console.WriteLine("Type the sum you want to do(ex:13 + 12 + 5): ");

            char symb = '+';
            string sum = Console.ReadLine();
            string[] nums = sum.Split(symb);

            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i].Trim());
                Console.WriteLine(numbers[i]);
            }
            #endregion

            #region Connection

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
                Console.WriteLine(result.Result);
                stRead.Close();
            }
            #endregion
        }
        #endregion

        #region subtraction

        public void Subt(string trackingId)
        {
            #region SubtractionStuff

            Console.WriteLine("------Subtraction Operation------");
            Console.WriteLine("Type the subtraction you want to do(ex:13 - 12 - 5): ");

            char symb = '-';
            string subt = Console.ReadLine();
            string[] nums = subt.Split(symb);

            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i].Trim());
                Console.WriteLine(numbers[i]);
            }
            #endregion

            #region Connection

            SubtractRequest subtract = new SubtractRequest();
            SubtractResponse result = new SubtractResponse();

            subtract.Numbers = numbers;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}Subtract");
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                var jason = JsonConvert.SerializeObject(subtract);
                dataStream.Write(jason);
                dataStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stRead = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine("The server operation's result is:");
                result = JsonConvert.DeserializeObject<SubtractResponse>(stRead.ReadToEnd());
                Console.WriteLine(result.Result);
                stRead.Close();
            }
            #endregion
        }
        #endregion

        #region multiply

        public void Mult(string trackingId)
        {
            #region MultiplicationStuff

            Console.WriteLine("------Multplication Operation------");
            Console.WriteLine("Type the multiplication you want to do(ex:13 * 12 * 5): ");

            char symb = '*';
            string mult = Console.ReadLine();
            string[] nums = mult.Split(symb);

            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i].Trim());
                Console.WriteLine(numbers[i]);
            }
            #endregion

            #region Connection

            MultRequest multiply = new MultRequest();
            MultResponse result = new MultResponse();

            multiply.Multipliers = numbers;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}Multiply");
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                var jason = JsonConvert.SerializeObject(multiply);
                dataStream.Write(jason);
                dataStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stRead = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine("The server operation's result is:");
                result = JsonConvert.DeserializeObject<MultResponse>(stRead.ReadToEnd());
                Console.WriteLine(result.Result);
                stRead.Close();
            }
            #endregion
        }
        #endregion

        #region division

        public void Div(string trackingId)
        {
            #region DivisionStuff

            Console.WriteLine("-------Division Operation------");
            Console.WriteLine("Type the binomial int division  you want to do(ex:13 / 12): ");

            char symb = '/';
            string div = Console.ReadLine();
            string[] nums = div.Split(symb);

            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i].Trim());
                Console.WriteLine(numbers[i]);
            }
            #endregion

            #region Connection

            DivRequest division = new DivRequest();
            DivResponse result = new DivResponse();

            division.Dividend = numbers[0];
            division.Diviser = numbers[1];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}Divide");
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                var jason = JsonConvert.SerializeObject(division);
                dataStream.Write(jason);
                dataStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stRead = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine("The server operation's result is:");
                result = JsonConvert.DeserializeObject<DivResponse>(stRead.ReadToEnd());
                Console.WriteLine(result.Quotient);
                Console.WriteLine("The remainder of the division is:");
                Console.WriteLine(result.Remainder);
                stRead.Close();
            }
            #endregion
        }
        #endregion
        #region squareRoot
        
        public void Square(string trackingId)
        {/*
            #region SquareRootStuff

            Console.WriteLine("-------Square Root Operation------");
            Console.WriteLine("Type the number to make the square root of it(ex: 12): ");
            
            string sqr = Console.ReadLine();
            string[] nums = div.Split(symb);

            int[] numbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numbers[i] = int.Parse(nums[i].Trim());
                Console.WriteLine(numbers[i]);
            }
            #endregion

            #region Connection

            DivRequest division = new DivRequest();
            DivResponse result = new DivResponse();

            division.Dividend = numbers[0];
            division.Diviser = numbers[1];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}Divide");
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter dataStream = new StreamWriter(request.GetRequestStream()))
            {
                var jason = JsonConvert.SerializeObject(division);
                dataStream.Write(jason);
                dataStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader stRead = new StreamReader(response.GetResponseStream()))
            {
                Console.WriteLine("The server operation's result is:");
                result = JsonConvert.DeserializeObject<DivResponse>(stRead.ReadToEnd());
                Console.WriteLine(result.Quotient);
                Console.WriteLine("The remainder of the division is:");
                Console.WriteLine(result.Remainder);
                stRead.Close();
            }
            #endregion*/
        }
        #endregion
    }
}
