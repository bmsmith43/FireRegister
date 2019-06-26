using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FireRegister.MobileAppService.Models
{
   public class EmployeeRepository : IEmployeeRepository
   {
      private static readonly ConcurrentDictionary<string, Employee> Employees =
          new ConcurrentDictionary<string, Employee>(StringComparer.OrdinalIgnoreCase);

      public EmployeeRepository()
      {
         var employees = new []
         {
            new Employee {Id = "ADu", Name = "Adrian Dunn"},
            new Employee {Id = "ABh", Name = "Amine Bahouali"},
            new Employee {Id = "BRo", Name = "Bradley Robinson"},
            new Employee {Id = "CFe", Name = "Clive Ferguson"},
            new Employee {Id = "DMa", Name = "David Maffioli"},
            new Employee {Id = "Eve", Name = "Ela Verdigi"},
            new Employee {Id = "FLe", Name = "Fergus Leah"},
            new Employee {Id = "GDa", Name = "Georgious Lamprinos"},
            new Employee {Id = "JCh", Name = "Julian Chubb"},
            new Employee {Id = "JDa", Name = "Joshua Davies"},
            new Employee {Id = "JEd", Name = "Joshua Eddy"},
            new Employee {Id = "JJa", Name = "Jack Jacques"},
            new Employee {Id = "JKee", Name = "Jannine Krenzel"},
            new Employee {Id = "JMo", Name = "Joanne Morgan"},
            new Employee {Id = "JSm", Name = "Joss Smith"},
            new Employee {Id = "JLo", Name = "James Lowe"},
            new Employee {Id = "JSp", Name = "John Speed"},
            new Employee {Id = "KRi", Name = "Kyle Richardson"},
            new Employee {Id = "LGo", Name = "Lukasz Golda"},
            new Employee {Id = "MRo", Name = "Martin Rossiter"},
            new Employee {Id = "MiWe", Name = "Michelle Weale"},
            new Employee {Id = "MMc", Name = "Michael McHugh"},
            new Employee {Id = "MRa", Name = "Michael Ravenscroft"},
            new Employee {Id = "MRo", Name = "Malcolm Ross"},
            new Employee {Id = "MSm", Name = "Mark Smith"},
            new Employee {Id = "MWe", Name = "Mark Westwood"},
            new Employee {Id = "MWo", Name = "Marta Wodzinska"},
            new Employee {Id = "NBe", Name = "Nicholas Bentley"},
            new Employee {Id = "NRa", Name = "Natalie Ravenhill"},
            new Employee {Id = "OBe", Name = "Okera Beckford"},
            new Employee {Id = "PDa", Name = "Paul Davies"},
            new Employee {Id = "PTc", Name = "Paul Thane-Clarke"},
            new Employee {Id = "PDu", Name = "Peter Undery"},
            new Employee {Id = "RBa", Name = "Ryan Basterfield"},
            new Employee {Id = "SZh", Name = "Shufen Zhang"},
            new Employee {Id = "VCo", Name = "Vincent Couturier"},};

         foreach (var employee in employees)
         {
            Add(employee);

         }
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
         Employees[item.Id] = item;
      }

      public Employee Find(string id)
      {
         Employees.TryGetValue(id, out var item);

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
