using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practical_17_View.Helper;
using Practical_17_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Practical_17_View.Controllers
{
    public class PersonsController : Controller
    {
        PersonAPI personAPI = new PersonAPI();
        public async Task<IActionResult> Index()
        {
           
            List<PersonData> students = new List<PersonData>();
            HttpClient client = personAPI.Initial();
           
            HttpResponseMessage res = await client.GetAsync("api/Person");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<PersonData>>(result);
            }
            return View(students);
            
        }


        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            PersonData person = new PersonData();
            if (id == null)
            {
                return NotFound();
            }
            HttpClient client = personAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Person/"+id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                person = JsonConvert.DeserializeObject<PersonData>(result) ;
            }
            return View(person);
        }
        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonData person)
        {
            if (ModelState.IsValid)
            {

                HttpClient client = personAPI.Initial();

                var postdata = client.PostAsJsonAsync("api/Person", person);
                postdata.Wait();
                var res = postdata.Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            PersonData person = new PersonData();
            if (id == null)
            {
                return NotFound();
            }
            HttpClient client = personAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Person/" + id);
            if (res.IsSuccessStatusCode)
            {
                var reslut = res.Content.ReadAsStringAsync().Result;
                 person = JsonConvert.DeserializeObject<PersonData>(reslut);
               
            }
            return View(person);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PersonData person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    HttpClient client = personAPI.Initial();

                    var postdata = client.PutAsJsonAsync("api/Person/" + id, person);
                    postdata.Wait();
                    var res = postdata.Result;
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception e)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PersonData person = new PersonData();
           HttpClient client = personAPI.Initial();
           HttpResponseMessage res = await client.DeleteAsync("api/Person/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}
