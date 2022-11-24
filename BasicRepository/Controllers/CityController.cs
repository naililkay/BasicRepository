using BasicRepository.Data;
using BasicRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BasicRepository.Controllers
{
    public class CityController : Controller
    {
        private readonly Repository<City> _rep;
        public CityController(Repository<City> rep)
        {
            _rep = rep;
        }

        public IActionResult List()
        {
            return View(_rep.Liste());
        }

        public IActionResult Create()
        {
            City city = new City();
            return View("Crud", city);
        }
        [HttpPost]
        public IActionResult Create(City c)
        {
            _rep.Create(c);
            _rep.Save();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            City city = _rep.Find(Id);
            return View("Crud", city);
        }
        [HttpPost]
        public IActionResult Edit(City c)
        {
            _rep.Update(c);
            _rep.Save();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            City city = _rep.Find(Id);
            return View("Crud", city);
        }
        [HttpPost]
        public IActionResult Delete(City c)
        {
            _rep.Delete(c);
            _rep.Save();
            return RedirectToAction("List");
        }
    }
}
