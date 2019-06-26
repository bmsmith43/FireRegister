using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FireRegister.MobileAppService.Models
{
   public class EmployeeRepository : IEmployeeRepository
   {
      private static readonly ConcurrentDictionary<string, Employee> Employees =
          new ConcurrentDictionary<string, Employee>();

      public EmployeeRepository()
      {
         Add(new Employee { Id = Guid.NewGuid().ToString(), Text = "Item 1", Description = "This is an item description." });
         Add(new Employee { Id = Guid.NewGuid().ToString(), Text = "Item 2", Description = "This is an item description." });
         Add(new Employee { Id = Guid.NewGuid().ToString(), Text = "Item 3", Description = "This is an item description." });
      }

      public Employee Get(string id)
      {
         return Employees[id];
      }

      public IEnumerable<Employee> GetAll()
      {
         return Employees.Values;
      }

      public void Add(Employee item)
      {
         item.Id = Guid.NewGuid().ToString();
         Employees[item.Id] = item;
      }

      public Employee Find(string id)
      {
         Employee item;
         Employees.TryGetValue(id, out item);

         return item;
      }

      public Employee Remove(string id)
      {
         Employee item;
         Employees.TryRemove(id, out item);

         return item;
      }

      public void Update(Employee item)
      {
         Employees[item.Id] = item;
      }
   }
}
