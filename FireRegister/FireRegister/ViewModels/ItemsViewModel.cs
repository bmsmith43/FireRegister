using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FireRegister.Models;
using FireRegister.Views;

namespace FireRegister.ViewModels
{
   public class ItemsViewModel : BaseViewModel
   {
      public ObservableCollection<Employee> Items { get; set; }
      public Command LoadItemsCommand { get; set; }

      public ItemsViewModel()
      {
         Title = "Browse";
         Items = new ObservableCollection<Employee>();
         LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

         MessagingCenter.Subscribe<NewItemPage, Employee>(this, "AddItem", async (obj, item) =>
         {
            var newItem = item as Employee;
            Items.Add(newItem);
            await DataStore.AddItemAsync(newItem);
         });
      }

      async Task ExecuteLoadItemsCommand()
      {
         if (IsBusy)
            return;

         IsBusy = true;

         try
         {
            Items.Clear();
            var items = await DataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
               Items.Add(item);
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