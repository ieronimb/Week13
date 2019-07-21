using EO.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using RazorEngine;
using Students.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Students.Web.Controllers
{


    public class StudentController : Controller
    {
        List<StudentViewModel> Students = new List<StudentViewModel>
        {
            new StudentViewModel {Id = 1, UserName = "petrica", Email = "petrica@yahoo.com", StudentName = "Petrica Agafitei", Age = 26, Gender = new Gender(), Address = new AddressViewModel()},
            new StudentViewModel {Id = 2, UserName = "petronela", Email = "petronela@yahoo.com", StudentName = "Petronela Moraru", Age = 24, Gender = new Gender(), Address = new AddressViewModel()},
             new StudentViewModel {Id = 3, UserName = "gabriel", Email = "gabriel@yahoo.com", StudentName = "Gabriel Mihai", Age = 22, Gender = new Gender(), Address = new AddressViewModel()},
        };

        [HttpGet]
        public ActionResult Index()
        {
            return View(Students);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var std = Students.Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            if (student.Id != null && student.Id != 0)
            {
                var existingUser = Students.Find(x => x.Id == student.Id);
                existingUser.Address = student.Address;
                existingUser.Email = student.Email;
                existingUser.UserName = student.UserName;
            }
            else
            {
                student.Id = Students.Count + 1;
                Students.Add(student);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleteUser = Students.FirstOrDefault(x => x.Id == id);

            Students.Remove(deleteUser);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = Students.FirstOrDefault(x => x.Id == id);

            return View(model);
        }

    }
}
    

