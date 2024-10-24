using _01.MVCIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01.MVCIntro.Controllers
{
    public class UrunController : Controller
    {
        private static List<Urun> list = new List<Urun>
        {
                new Urun { Id = 1, Ad = "Ürün 1", Fiyat = 100},
                new Urun { Id = 2, Ad = "Ürün 2", Fiyat = 200},
                new Urun { Id = 3, Ad = "Ürün 3", Fiyat = 300}
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(list);
        }

        [HttpGet]

        public IActionResult Ekle()

        {

            return View(list);

        }
        [HttpPost]

        public IActionResult Ekle(Urun urun)

        {

            urun.Id = list.Count + 1; //ürün eklendiğinde IDsi artar

            list.Add(urun);

            return RedirectToAction("List");

        }

    }
}
