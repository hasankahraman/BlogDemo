using BlogDemo.API.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var context = new Context();
            var values = context.Employees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var context = new Context();
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var context = new Context();
            var employeeToDelete = context.Employees.Find(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(employeeToDelete);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var context = new Context();
            var employeeToUpdate = context.Find<Employee>(employee.Id);
            if (employeeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                employeeToUpdate.Name = employee.Name;
                context.Update(employeeToUpdate);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
