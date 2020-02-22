﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IntroWebApi.Models;
using System.Net.Http;
using System.Text.Json;

namespace IntroWebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,"users/jahbenjah");
            var client = _clientFactory.CreateClient("Github");
            var response = await client.SendAsync(request);

            GithubUser user = new GithubUser();
            
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                 user = await JsonSerializer.DeserializeAsync<GithubUser>(responseStream);
            }
            else
            {
               
                
            }

            return View(user);
        }

        public async Task<IActionResult> Privacy()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "users/jahbenjah/repos");
            var client = _clientFactory.CreateClient("Github");
            var response = await client.SendAsync(request);

            GithubUser user = new GithubUser();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                user = await JsonSerializer.DeserializeAsync<GithubUser>(responseStream);
            }
            else
            {


            }

            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
