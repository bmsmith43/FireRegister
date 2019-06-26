using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireRegister.Services
{
   public interface IDataStore<T>
   {
      Task<bool> AddEmployeeAsync(T item);
      Task<bool> UpdateEmployeeAsync(T item);
      Task<bool> DeleteEmployeeAsync(string id);
      Task<T> GetEmployeeAsync(string id);
      Task<IEnumerable<T>> GetEmployeesAsync(bool forceRefresh = false);
   }
}
