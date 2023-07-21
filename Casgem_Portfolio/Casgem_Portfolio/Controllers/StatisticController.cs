using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployee.Count();
            var salary = db.TblEmployee.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select(y=>y.EmployeeName+ " "
            + y.EmployeeSurname).FirstOrDefault();
            ViewBag.totalCityCount = db.TblEmployee.Select(x => x.EmployeeCity).Distinct().Count();
            ViewBag.avgEmployeeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);

            ViewBag.CountCity = db.TblEmployee.Where(x => x.EmployeeDepartment == db.TblDepartment.Where(z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentId).FirstOrDefault()).Count();
            //şehri ankara veya adana olanları toplam
            ViewBag.CityAnkaraOrAdanaSumSalary = db.TblEmployee.Where(x => x.EmployeeCity == "Adana" || x.EmployeeCity =="Ankara").Sum(y=>y.EmployeeSalary);
            //ankarada yazılımda çalışan toplam kişi
            ViewBag.sumSalaryFromSoftwareDepartment = db.TblEmployee.Where(
                x => x.EmployeeCity == "Ankara" && x.EmployeeDepartment == db.TblDepartment.Where(
                    z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentId).FirstOrDefault()).Sum(w => w.EmployeeSalary);
            return View();
        }
    }
}