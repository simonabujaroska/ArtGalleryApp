using ArtGalleryAdminApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ArtGalleryAdminApplication.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44384/api/Admin/GetOrders";
            HttpResponseMessage response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsAsync<List<Order>>().Result;

            return View(data);
            
        }
        
        public IActionResult OrderDetails(Guid orderId)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44384/api/Admin/GetDetailsForOrder";
            

            var model = new
            {
                Id = orderId
            };
            //isprakjame model na BaseEntity so Id=orderId preku POST req
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            var data = response.Content.ReadAsAsync<Order>().Result;

            return View(data);
        }
    }
}
