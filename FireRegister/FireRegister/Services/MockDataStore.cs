using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireRegister.Models;

namespace FireRegister.Services
{
   public class MockDataStore : IDataStore<Employee>
   {
      List<Employee> _employees;

      public MockDataStore()
      {
         _employees = new List<Employee>();
         var mockItems = new List<Employee>
            {
                new Employee { Id = "First item", Name = "This is an item description." },
                new Employee { Id = "Second item", Name = "This is an item description." },
                new Employee { Id = "Third item", Name = "This is an item description." },
                new Employee { Id = "Fourth item", Name = "This is an item description." },
                new Employee { Id = "Fifth item", Name = "This is an item description." },
                new Employee { Id = "Sixth item", Name = "This is an item description." },
            };

         foreach (var item in mockItems)
         {
            _employees.Add(item);
         }
      }

      public async Task<bool> AddEmployeeAsync(Employee item)
      {
         _employees.Add(item);

         return await Task.FromResult(true);
      }

      public async Task<bool> UpdateEmployeeAsync(Employee item)
      {
         var oldItem = _employees.FirstOrDefault(arg => arg.Id == item.Id);
         _employees.Remove(oldItem);
         _employees.Add(item);

         return await Task.FromResult(true);
      }

      public async Task<bool> DeleteEmployeeAsync(string id)
      {
         var oldItem = _employees.FirstOrDefault(arg => arg.Id == id);
         _employees.Remove(oldItem);

         return await Task.FromResult(true);
      }

      public async Task<Employee> GetEmployeeAsync(string id)
      {
         return await Task.FromResult(_employees.FirstOrDefault(s => s.Id == id));
      }

      public async Task<IEnumerable<Employee>> GetEmployeeAsync(bool forceRefresh = false)
      {
         return await Task.FromResult(_employees);
      }
   }
}