using System;

using FireRegister.Models;

namespace FireRegister.ViewModels
{
   public class NewUserViewModel : BaseViewModel
   {
      public Employee Item { get; set; }
      public NewUserViewModel(Employee item = null)
      {
         Title = item?.Name;
         Item = item;
      }
   }
}
