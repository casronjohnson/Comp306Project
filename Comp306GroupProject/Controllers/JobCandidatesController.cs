using Comp306GroupProject.Data;
using Comp306GroupProject.Models;
using Comp306GroupProject.Views.JobCandidates;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Net.Http.Headers;
using System.Text;

namespace Comp306GroupProject.Controllers
{
    public class JobCandidatesController : Controller
    {
        HttpClient client;
        string baseUrl;
        string apiKey;

        public JobCandidatesController(AppDbContext context)
        {
            client = new HttpClient();
            baseUrl = "";
            apiKey = "";
        }

        public async Task<IActionResult> Index()
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", apiKey);
            IEnumerable<JobCandidate> jobCandidates = new List<JobCandidate>();

            HttpResponseMessage response = await client.GetAsync(baseUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                // convert json to joboffers object
                jobCandidates = JsonConvert.DeserializeObject<IEnumerable<JobCandidate>>(json);
            }
            return View(jobCandidates);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCandidates = await JobCandidateExists((int)id);

            if (jobCandidates == null)
            {
                return NotFound();
            }

            return View(jobCandidates);
        }

        // GET: JobCandidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCandidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateId,CandidateName,CandidateEmail,CandidateMajor,Skill,CandidateCity,CandidateCountry")] JobCandidate jobCandidate)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", apiKey);

            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(jobCandidate);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl, content);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));

            }
            return View(jobCandidate);
        }

        // GET: JobCandidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCandidate = await JobCandidateExists((int)id);
            if (jobCandidate == null)
            {
                return NotFound();
            }
            return View(jobCandidate);
        }

        // POST: JobCandidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidateId,CandidateName,CandidateEmail,CandidateMajor,Skill,CandidateCity,CandidateCountry")] JobCandidate jobCandidate)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", apiKey);

            if (id != jobCandidate.CandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string url = baseUrl + id.ToString();
                string json = JsonConvert.SerializeObject(jobCandidate);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
            }
            return View(jobCandidate);
        }

        // GET: JobCandidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCandidate = await JobCandidateExists((int)id);

            if (jobCandidate == null)
            {
                return NotFound();
            }

            return View(jobCandidate);
        }

        // POST: JobCandidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", apiKey);

            string url = baseUrl + id.ToString();
            //HttpResponseMessage response = 
            await client.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        }

        private async Task<JobCandidate> JobCandidateExists(int id)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("apikey", apiKey);
            JobCandidate jobCandidate = new JobCandidate();

            HttpResponseMessage response = await client.GetAsync(baseUrl + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                // convert json to jobCandidate object
                jobCandidate = JsonConvert.DeserializeObject<JobCandidate>(json);
            }

            return jobCandidate;
        }
    }
}
