using Microsoft.AspNetCore.Mvc;
using CLINT.Models;
using System.Text;
using Newtonsoft.Json;
using CLINT.Models;

namespace tryclient.Controllers
{
    public class Storecontroller : Controller
    {
        // عرض قائمة المتاجر
        public async Task<ActionResult> Index()
        {
            List<Store>? dataList = new List<Store>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7158/api/Project");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    dataList = JsonConvert.DeserializeObject<List<Store>>(sections);
                }
                else
                {
                    Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                }
            }
            return View(dataList);
        }

        // عرض تفاصيل متجر معين
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            Store? model = new Store();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7158/api/Project/{id}");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    model = JsonConvert.DeserializeObject<Store>(sections);
                }
                else
                {
                    Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                }
            }

            return View(model);
        }

        // إضافة متجر جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Store store)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://localhost:7158/api/Project", content);
                var apiResponse = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(apiResponse))
                {
                    var model = JsonConvert.DeserializeObject<Store>(apiResponse);
                }
                else
                {
                    Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // تعديل متجر قائم
        public async Task<ActionResult> Edit(int id)
        {
            Store? dataList = new Store();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://localhost:7158/api/Project/{id}");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    dataList = JsonConvert.DeserializeObject<Store>(sections);
                }
                else
                {
                    Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                }
            }
            return View(dataList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Store store)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"https://localhost:7158/api/Project/{id}", content);
                var apiResponse = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(apiResponse))
                {
                    var model = JsonConvert.DeserializeObject<Store>(apiResponse);
                }
                else
                {
                    Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // حذف متجر
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Store? dataList = new Store();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://localhost:7158/api/Project/{id}");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    dataList = JsonConvert.DeserializeObject<Store>(sections);
                }
                else
                {
                    Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                }
            }
            return View(dataList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"https://localhost:7158/api/Project/{id}");
                    var sections = await response.Content.ReadAsStringAsync();

                    if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                    {
                        var dataList = JsonConvert.DeserializeObject<Store>(sections);
                    }
                    else
                    {
                        Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // تحديد متجر
        public async Task<ActionResult> Select(int id)
        {
            Store? store = new Store();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7158/api/Project/" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(apiResponse))
                {
                    store = JsonConvert.DeserializeObject<Store>(apiResponse);
                }
                else
                {
                    Console.WriteLine("الاستجابة كانت فارغة أو غير صالحة");
                }
            }
            if (store != null)
                return View(store);
            return Ok("لا يوجد صنف بهذا الرقم!!!");
        }
    }
}
