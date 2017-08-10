using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ClinicalResearchMVC.Controllers
{
    public class StudyResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Policy = "Doctor, Manager")]
        [Authorize]
        //[Authorize(Roles = "Doctor, Manager")]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Policy = "Doctor, Manager")]
        [Authorize]
        //[Authorize(Roles = "Doctor, Manager")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudyResult item)
        {
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);

            var myContent = JsonConvert.SerializeObject(item);

            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var content = await client.PostAsync("http://localhost:1822/api/StudyResult", byteContent);

            return CreatedAtRoute("StudyResult", new { id = item.Id }, item);
        }
    }
}