using _01.MVCIntro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _01.MVCIntro.Controllers
{
    public class PersonelController : Controller
    {
        private static List<Personel> personeller = new List<Personel>
        {
                new Personel { Id = 1, Ad = "Efnan", Soyad = "Genç"},
                new Personel { Id = 2, Ad = "Samet", Soyad = "Biçer"},
                new Personel { Id = 3, Ad = "Batıkan", Soyad = "Özbakır"}
        };

        
        public IActionResult PersonelIndex()
        {
            return View(personeller);
        }

        [HttpGet]
        public IActionResult PersonelEkle()
        {
            return View(personeller);
        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel personel)
        {
            personel.Id = personeller.Count + 1;
            personeller.Add(personel);
            return RedirectToAction("PersonelIndex");           
        }

        [HttpGet]
        public IActionResult PersonelGuncelle(int Id)
        {
            var personel = personeller.FirstOrDefault(x => x.Id == Id);
            if (personel == null)
            { 
                return NotFound();
            }
            return View(personel);
        }

        [HttpPost]
        public IActionResult PersonelGuncelle(Personel personel)
        {
            var mevcutPersonel = personeller.FirstOrDefault(x => x.Id == personel.Id);
            if (personel == null)
            {
                return NotFound();
            }
            mevcutPersonel.Ad = personel.Ad;
            mevcutPersonel.Soyad = personel.Soyad;

            return RedirectToAction("PersonelIndex");
        }


        [HttpGet]

        public IActionResult PersonelSil(int Id)
        {
            var personel = personeller.FirstOrDefault(x => x.Id==Id);
            if (personel != null)
            {
                personeller.Remove(personel);
            }
            return RedirectToAction("PersonelIndex");
        }

    }
}
