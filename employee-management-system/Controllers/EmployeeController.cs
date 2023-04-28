using employee_management_system.DAL;
using employee_management_system.Migrations;
using employee_management_system.Models;
using employee_management_system.Models.DBEntites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee_management_system.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context) 
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            if (employees != null)
            {
                foreach(var employee in employees) 
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Email = employee.Email,
                        PhoneNo = employee.PhoneNo,
                        JobTitle    = employee.JobTitle,
                    };
                    employeeList.Add(EmployeeViewModel);
                }
                return View(employeeList);
            }
            return View(employeeList);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeData) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Name = employeeData.Name,
                        Email = employeeData.Email,
                        PhoneNo = employeeData.PhoneNo,
                        JobTitle = employeeData.JobTitle,

                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee Created successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id) 
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == Id);
                if (employee != null)
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Email = employee.Email,
                        PhoneNo = employee.PhoneNo,
                        JobTitle = employee.JobTitle
                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the id: {Id}";
                    return RedirectToAction("Index");
                }
        }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
        }

    }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        EmployeeId = model.EmployeeId,
                        Name = model.Name,
                        Email = model.Email,
                        PhoneNo = model.PhoneNo,
                        JobTitle = model.JobTitle
                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["successmessage"] = "Employee updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details are invalid.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == Id);
                if (employee != null)
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        Email = employee.Email,
                        PhoneNo = employee.PhoneNo,
                        JobTitle = employee.JobTitle
                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Delete(EmployeeViewModel model) 
        {
            var employee = _context.Employees.SingleOrDefault(x => x.EmployeeId == model.EmployeeId);
            if(employee != null) 
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                TempData["successmessage"] = "Employee deleted successfully";
                return RedirectToAction("Index");
            }
            else 
            {
                TempData["errorMessage"] = $"Employee details are invalid.";
                return RedirectToAction("Index");
            }
        }
    }
}
