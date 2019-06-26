using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireRegister.Models;

namespace FireRegister.Services
{
   public class MockDataStore : IDataStore<Employee>
   {
      List<Employee> items;

      public MockDataStore()
      {
         items = new List<Employee>();
         var mockItems = new List<Employee>
            {
                new Employee { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Employee { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Employee { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Employee { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Employee { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Employee { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

         foreach (var item in mockItems)
         {
            items.Add(item);
         }
      }

      public async Task<bool> AddItemAsync(Employee item)
      {
         items.Add(item);

         return await Task.FromResult(true);
      }

      public async Task<bool> UpdateItemAsync(Employee item)
      {
         var oldItem = items.Where((Employee arg) => arg.Id == item.Id).FirstOrDefault();
         items.Remove(oldItem);
         items.Add(item);

         return await Task.FromResult(true);
      }

      public async Task<bool> DeleteItemAsync(string id)
      {
         var oldItem = items.Where((Employee arg) => arg.Id == id).FirstOrDefault();
         items.Remove(oldItem);

         return await Task.FromResult(true);
      }

      public async Task<Employee> GetItemAsync(string id)
      {
         return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
      }

      public async Task<IEnumerable<Employee>> GetItemsAsync(bool forceRefresh = false)
      {
         return await Task.FromResult(items);
      }
   }
}