using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentINFO.Models;

namespace StudentINFO.Controllers
{
    public class HomeController : Controller
    {
        private StudentInfoDBEntities db = new StudentInfoDBEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SchedulePage()
        {
            var faculties = db.Faculties.Select(x => x.ShortName).ToList();
            var groups = db.Groups.Select(x => x.Number).ToList();
            ViewBag.Faculties = faculties;
            ViewBag.Groups = groups;
            return View();
        }

        [HttpPost]
        public ActionResult Schedule(int group)
        {
            //int groupN = (int)groupNum;
            var items = db.Classes.Where(x => x.Group.Number == group).ToList();
            //string[][] classes = new string[6][];
            //for (int i = 0; i < 6; i++)
            //    classes[i] = new string[6];
            string[] allClasses = new string[36];
            
            string[] days = {"ПОНЕДЕЛЬНИК", "ВТОРНИК", "СРЕДА", "ЧЕТВЕРГ", "ПЯТНИЦА", "СУББОТА" };
            ViewBag.Days = days;
            foreach(var item in items)
                allClasses[item.NumClass - 1 + (item.FK_DayId - 1) * 6] = item.Discipline.ShortName;

            //foreach (var item in items)
            //{
            //    switch (item.FK_DayId)
            //    {
            //        case 1:
            //            classes[0][item.NumClass - 1] = item.Discipline.ShortName;
            //            break;
            //        case 2:
            //            classes[1][item.NumClass - 1] = item.Discipline.ShortName;
            //            break;
            //        case 3:
            //            classes[2][item.NumClass - 1] = item.Discipline.ShortName;
            //            break;
            //        case 4:
            //            classes[3][item.NumClass - 1] = item.Discipline.ShortName;
            //            break;
            //        case 5:
            //            classes[4][item.NumClass - 1] = item.Discipline.ShortName;
            //            break;
            //        case 6:
            //            classes[5][item.NumClass - 1] = item.Discipline.ShortName;
            //            break;
            //    }
            //}
            return PartialView(allClasses);
        }

        public ActionResult AcademicPerformance()
        {
            //var faculties = db.Faculties.Select(x => x.ShortName).ToList();
            var groups = db.Groups.Select(x => x.Number).ToList();
            var disciplines = db.Disciplines.Select(x => x.ShortName).ToList();
            //ViewBag.Faculties = faculties;
            ViewBag.Groups = groups;
            ViewBag.Disciplines = disciplines;
            return View();
        }

        public ActionResult PreformanceResult(int group, string discipline)
        {
            var items = db.AcademicPerformances.Where(x => x.Student.Group.Number == group && x.Discipline.ShortName == discipline).ToList();
            PerformanceTable table = new PerformanceTable();
            List<(Student, int[])> set = new List<(Student, int[])>();
            (Student, int?[]) couple;
            Student curr;
            List<Student> students = new List<Student>();
            int?[] grades;
            foreach(var item in items)
            {
                curr = item.Student;

                if (!students.Contains(curr))
                {
                    students.Add(curr);
                    grades = new int?[16];
                    foreach (var new_item in items.Where(x => x.Student == curr))
                        grades[new_item.NumSeminar - 1] = (int)new_item.Grade;
                    couple = (curr, grades);
                    table.Table.Add(couple);
                }
            }
            return PartialView(table);
        }

        public ActionResult Info()
        {
            var items = db.News.ToList();
            return View(items);
        }

        //public ActionResult GroupsInputSelect(string faculty)
        //{
        //    var groups = db.Groups.Where(x => x.Faculty.ShortName == faculty).Select(x => x.Number).ToList();
        //    ViewBag.Groups = groups;
        //    return PartialView();
        //}
    }
}