using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using FireRegister.Models;
using FireRegister.Views;

namespace FireRegister.ViewModels
{
   public class RegisterViewModel : BaseViewModel
   {
      public ObservableCollection<Employee> Employees { get; set; }
      public Command LoadItemsCommand { get; set; }

      public RegisterViewModel()
      {
         Title = "Register";
         Employees = new ObservableCollection<Employee>();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

         MessagingCenter.Subscribe<NewItemPage, Employee>(this, "AddItem", async (obj, employee) =>
         {
            Employees.Add(employee);
            await DataStore.AddEmployeeAsync(employee);
         });
      }

      async Task ExecuteLoadItemsCommand()
      {
         if (IsBusy)
            return;

         IsBusy = true;

         try
         {
            Employees.Clear();
            var employees = await DataStore.GetEmployeesAsync(true);
            foreach (var employee in employees.Where(e => e.SignedIn).OrderBy(e => e.Name))
            {
               Employees.Add(employee);
            }
         }
         catch (Exception ex)
         {
            Debug.WriteLine(ex);
         }
         finally
         {
            IsBusy = false;
         }
      }
   }
}