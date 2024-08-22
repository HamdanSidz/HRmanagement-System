//using HRmanagement.Models;
using HRmanagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRmanagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
  
        public async Task<IActionResult> Home(){
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet("/EmployeeController/NotFound")]
        public new IActionResult NotFound()
        {
            return View();
        }

        [HttpGet("/EmployeeController/CreateEmployee")]
        public IActionResult CreateEmployee(){
            return View();
        }

        [HttpPost("/EmployeeController/CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid){
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home");
            }
             return View(employee);
        }

        [HttpGet("/EmployeeController/EditEmployee/{id?}")]
        public async Task<IActionResult> EditEmployee(int? id)
        {
            if( id == null || _context.Employees == null)
            {
                return RedirectToAction("NotFound");
            }

            var data = await _context.Employees.FindAsync(id);

            if (data == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(data);
        }


        [HttpPost("/EmployeeController/EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(int id,Employee employee)
        {
            if (id!=employee.Emp_id)
            {
                return RedirectToAction("NotFound");
            }
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home");
            }
            return View(employee);
        }

        [HttpGet("/Employee/DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(employee); 
        }

        [HttpPost("/Employee/DeleteEmployeeConfirmed/{id}")]
        public async Task<IActionResult> DeleteEmployeeConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return RedirectToAction("NotFound");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home");

        }
    }
}
