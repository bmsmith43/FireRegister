using System;
using FireRegister.MobileAppService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FireRegister.MobileAppService.Controllers
{
   [Route("api/[controller]")]
   public class EmployeeController : Controller
   {

      private readonly IEmployeeRepository IemployeeRepository;

      public EmployeeController(IEmployeeRepository itemRepository)
      {
         IemployeeRepository = itemRepository;
      }

      [HttpGet]
      public IActionResult List()
      {
         return Ok(IemployeeRepository.GetAll());
      }

      [HttpGet("{id}")]
      public Employee GetItem(string id)
      {
         Employee item = IemployeeRepository.Get(id);
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

            IemployeeRepository.Add(item);

         }
         catch (Exception)
         {
            return BadRequest("Error while creating");
         }
         return Ok(item);
      }

      [HttpPut]
      public IActionResult Edit([FromBody] Employee item)
      {
         try
         {
            if (item == null || !ModelState.IsValid)
            {
               return BadRequest("Invalid State");
            }
            IemployeeRepository.Update(item);
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
         IemployeeRepository.Remove(id);
      }
   }
}
