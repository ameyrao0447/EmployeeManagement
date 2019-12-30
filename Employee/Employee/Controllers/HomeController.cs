using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmployee obj;

        public HomeController(IEmployee obj)
        {
            this.obj = obj;
        }
        [Route("~/")]
        [Route("[action]")]
        public ViewResult Index()
        {
            return View(obj.GetAll());
        }

        [HttpGet]
        [Route("[action]")]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(EmployeeTem emp)
        {
            if (ModelState.IsValid)
            {
                obj.Add(emp);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [Route("[action]")]
        public ViewResult ViewEmployee(int id)
        {
            return View(obj.Get(id));
        }
        
        [HttpGet]
        [Route("[action]")]
        public ViewResult Edit(int id)
        {
            EmployeeTem em = obj.Get(id);
            return View(em);
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit(EmployeeTem emp)
        {
            if (ModelState.IsValid)
            {
                obj.Update(emp);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult DeleteEmployee(int id)
        {
            obj.Delete(id);
            return RedirectToAction("index");
        }
    }
}
