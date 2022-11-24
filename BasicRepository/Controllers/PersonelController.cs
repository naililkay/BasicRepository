using BasicRepository.Data;
using BasicRepository.Models;
using BasicRepository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BasicRepository.Controllers
{
    public class PersonelController : Controller
    {
        Repository<Personel> _rep;
        ErrorModel _model;
        public PersonelController(Repository<Personel> rep, ErrorModel model)
        {
            _rep = rep;
            _model = model;
        }

        public IActionResult List()
        {
            return View(_rep.Liste());
        }

        //public int GetLastId()
        //{
        //    return _rep.Liste().ToList().Max(x => x.Id) + 1;
        //}

        public IActionResult Create()
        {
            Personel personel = new Personel();
            //personel.Id = GetLastId();
            return View("Crud", personel);
        }
        [HttpPost]
        public IActionResult Create(Personel p)
        {
            _rep.Create(p);
            _rep.Save();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int Id)
        {
            Personel personel = _rep.Find(Id);
            return View("Crud", personel);
        }
        [HttpPost]
        public IActionResult Edit(Personel p)
        {
            var msg = _rep.Update(p);
            if (msg == "OK")
            {
                _rep.Save();
                return RedirectToAction("List");
            }
            ViewBag.Message = msg;
            return View("Crud", p);
            
        }

        public IActionResult Delete(int Id)
        {
            Personel personel = _rep.Find(Id);
            return View("Crud", personel);
        }
        [HttpPost]
        public IActionResult Delete(Personel p)
        {
            _rep.Delete(p);
            _rep.Save();
            return RedirectToAction("List");
        }
    }
}
