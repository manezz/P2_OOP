using ASP_NET_OOP_Opg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP_NET_OOP_Opg3.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<Movies> movies = new List<Movies>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // sætter connectoionstring
            con.ConnectionString = ASP_NET_OOP_Opg3.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            FetchData();
            return View(movies);
        }
        private void FetchData()
        {
            if(movies.Count > 0)
            {
                movies.Clear();
            }
            try
            {
                // Vælger film
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [ID], [Name], [Director], [YearOfRelease] FROM [joe].[dbo].[MovieTable]";
                dr = com.ExecuteReader();
                while(dr.Read())
                {
                    movies.Add(new Movies() {ID = dr["ID"].ToString()
                    ,Name = dr["Name"].ToString()
                    ,Director = dr["Director"].ToString()
                    ,YearOfRelease = dr["YearOfRelease"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
