﻿using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //string a = "aaa";
            //string b = "bbbb";
            //Console.WriteLine($"{a} {b}");

            //var newPerson = new Person { FirstName = "Tomek" };

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            //2xx
            if(response.IsSuccessStatusCode)
            {
                string htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("\\w+@(\\w+\\.){1,}\\w+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach(var m in matches)
                {
                    Console.WriteLine(m.ToString());
                }
            }
        }
    }
}
