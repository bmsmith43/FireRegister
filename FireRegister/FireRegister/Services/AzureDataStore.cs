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

      public async Task<IEnumerable<Employee>> GetItemsAsync(bool forceRefresh = false)
      {
         if (forceRefresh)
         {
            var json = await client.GetStringAsync($"api/item");
            items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Employee>>(json));
         }

         return items;
      }

      public async Task<Employee> GetItemAsync(string id)
      {
         if (id != null)
         {
            var json = await client.GetStringAsync($"api/item/{id}");
            return await Task.Run(() => JsonConvert.DeserializeObject<Employee>(json));
         }

         return null;
      }

      public async Task<bool> AddItemAsync(Employee item)
      {
         if (item == null)
            return false;

         var serializedItem = JsonConvert.SerializeObject(item);

         var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

         return response.IsSuccessStatusCode;
      }

      public async Task<bool> UpdateItemAsync(Employee item)
      {
         if (item == null || item.Id == null)
            return false;

         var serializedItem = JsonConvert.SerializeObject(item);
         var buffer = Encoding.UTF8.GetBytes(serializedItem);
         var byteContent = new ByteArrayContent(buffer);

         var response = await client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

         return response.IsSuccessStatusCode;
      }

      public async Task<bool> DeleteItemAsync(string id)
      {
         if (string.IsNullOrEmpty(id))
            return false;

         var response = await client.DeleteAsync($"api/item/{id}");

         return response.IsSuccessStatusCode;
      }
   }
}