using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FireRegister.Models;

namespace FireRegister.Services
{
   public class AzureDataStore : IDataStore<Employee>
   {
      HttpClient client;
      IEnumerable<Employee> items;

      public AzureDataStore()
      {
         client = new HttpClient();
         client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

         items = new List<Employee>();
      }

      public async Task<IEnumerable<Employee>> GetEmployeesAsync(bool forceRefresh = false)
      {
         if (forceRefresh)
         {
            var json = await client.GetStringAsync($"api/employee");
            items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Employee>>(json));
         }

         return items;
      }

      public async Task<Employee> GetEmployeeAsync(string id)
      {
         if (id != null)
         {
            var json = await client.GetStringAsync($"api/employee/{id}");
            return await Task.Run(() => JsonConvert.DeserializeObject<Employee>(json));
         }

         return null;
      }

      public async Task<bool> AddEmployeeAsync(Employee item)
      {
         if (item == null)
            return false;

         var serializedItem = JsonConvert.SerializeObject(item);

         var response = await client.PostAsync($"api/employee", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

         return response.IsSuccessStatusCode;
      }

      public async Task<bool> UpdateEmployeeAsync(Employee employee)
      {
         if (employee == null || employee.Id == null)
            return false;

         var serializedItem = JsonConvert.SerializeObject(employee);

         var response = await client.PutAsync("api/employee", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

         return response.IsSuccessStatusCode;
      }

      public async Task<bool> DeleteEmployeeAsync(string id)
      {
         if (string.IsNullOrEmpty(id))
            return false;

         var response = await client.DeleteAsync($"api/employee/{id}");

         return response.IsSuccessStatusCode;
      }
   }
}