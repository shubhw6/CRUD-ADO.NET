using Crud_ADO.Data;
using Crud_ADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_ADO.Controllers
{
    public class StudentController : Controller
    {
        // GET: StudentController
        
       
        public ActionResult Index()
        {
          StudentData studentData = new StudentData();
           
          var c = studentData.GetAllStudent();

            return View(c);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)


        {
            StudentData studentData = new StudentData();    
            Student student=studentData.DetailStudent(id);
            
          
            return View(student);
        }

        // GET: StudentController/Create
       
        public ActionResult Create( )
        {
              

            
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student model)
        {
            try
            {
                StudentData studentData = new StudentData();
                studentData.AddStudent(model);



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {

            StudentData studentData = new StudentData();
            Student student = studentData.DetailStudent(id);
            return View(student);   

         
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                StudentData studentData = new StudentData();
                studentData.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            

            StudentData studentData = new StudentData();
            Student student = studentData.DetailStudent(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student model)
        {
            try
            {

                StudentData student = new StudentData();
                student.DeleteStudent(model.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
