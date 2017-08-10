using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityModel;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;

namespace ClinicalResearchMVC.Controllers
{
    public class PatientController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //make a request to web api, call the patient controller on the web api
            //get only the patient for this doctor

            string id = string.Empty;
            string apiURL = string.Empty;

            if (HttpContext.User.IsInRole("Doctor"))
            {
                id = HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject)?.Value;
                apiURL = "api/patient/doctor";
            }
            //else if check each role and upate the id and url accordingly

            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.SetBearerToken(accessToken);

            var content = await client.GetAsync("http://localhost:1822/" + apiURL);
            

            //parse the http response and deserialize the json into patient object
            //and return the models a list of patient to view

            return View();
        }

        //[Authorize(Policy = "Doctor")]
        [Authorize]
        //[Authorize(Roles = "Doctor")]
        public IActionResult Create()
        {
            return View();
        }

        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            await HttpContext.Authentication.SignOutAsync("oidc");
        }
    }
}