using System;
using FireRegister.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FireRegister.MobileAppService.Controllers
{
   [Route("api/[controller]")]
   public class EmployeeController : Controller
   {

      private readonly IEmployeeRepository _employeeRepository;

      public EmployeeController(IEmployeeRepository itemRepository)
      {
         _employeeRepository = itemRepository;
      }

      [HttpGet]
      public IActionResult List()
      {
         return Ok(_employeeRepository.GetAll());
      }

      [HttpGet("{id}")]
      public Employee GetEmployee(string id)
      {
         Employee item = _employeeRepository.Get(id);
         return item;
      }

      [HttpPost]
      public IActionResult Create([FromBody]Employee item)
      {
         try
         {
            if (item == null || !ModelState.IsValid)
            {
               return BadRequest("Invalid State");
            }

            _employeeRepository.Add(item);

         }
         catch (Exception)
         {
            return BadRequest("Error while creating");
         }
         return Ok(item);
      }

      [HttpPut]
      public IActionResult Edit([FromBody] Employee employee)
      {
         try
         {
            if (employee == null || !ModelState.IsValid)
            {
               return BadRequest("Invalid State");
            }
            _employeeRepository.Update(employee);
         }
         catch (Exception)
         {
            return BadRequest("Error while creating");
         }
         return NoContent();
      }

      [HttpDelete("{id}")]
      public void Delete(string id)
      {
         _employeeRepository.Remove(id);
      }
   }
}
