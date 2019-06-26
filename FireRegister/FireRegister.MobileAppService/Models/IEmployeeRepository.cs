using System.Collections.Generic;

namespace FireRegister.MobileAppService.Models
{
   public interface IEmployeeRepository
   {
      void Add(Employee item);
      void Update(Employee item);
      Employee Remove(string key);
      Employee Get(string id);
      IEnumerable<Employee> GetAll();
   }
}
