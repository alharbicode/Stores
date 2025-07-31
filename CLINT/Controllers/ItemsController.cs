using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using CLINT.Models;

namespace tryclient.Controllers
{
    public class ItemsController : Controller
    {
        // عرض قائمة المتاجر
        public async Task<ActionResult> Index()
        {
            List<Item>? dataList = new List<Item>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7082/api/Stocks");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    dataList = JsonConvert.DeserializeObject<List<Item>>(sections);
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
            Item? model = new Item();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7082/api/Stocks/{id}");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    model = JsonConvert.DeserializeObject<Item>(sections);
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
        public async Task<ActionResult> Create(Item store)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("https://localhost:7082/api/Stocks", content);
                var apiResponse = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(apiResponse))
                {
                    var model = JsonConvert.DeserializeObject<Item>(apiResponse);
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
            Item? dataList = new Item();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://localhost:7082/api/Stocks/{id}");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    dataList = JsonConvert.DeserializeObject<Item>(sections);
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
        public async Task<ActionResult> Edit(int id, Item store)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"https://localhost:7082/api/Stocks/{id}", content);
                var apiResponse = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(apiResponse))
                {
                    var model = JsonConvert.DeserializeObject<Item>(apiResponse);
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
            Item? dataList = new Item();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://localhost:7082/api/Stocks/{id}");
                var sections = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                {
                    dataList = JsonConvert.DeserializeObject<Item>(sections);
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
                    var response = await httpClient.DeleteAsync($"https://localhost:7082/api/Stocks/{id}");
                    var sections = await response.Content.ReadAsStringAsync();

                    if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(sections))
                    {
                        var dataList = JsonConvert.DeserializeObject<Item>(sections);
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
            Item? store = new Item();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7082/api/Stocks/" + id);
                string apiResponse = await response.Content.ReadAsStringAsync();

                if (response.Content.Headers.ContentType.MediaType == "application/json" && !string.IsNullOrEmpty(apiResponse))
                {
                    store = JsonConvert.DeserializeObject<Item>(apiResponse);
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
