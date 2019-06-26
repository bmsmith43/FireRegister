using System;

using FireRegister.Models;

namespace FireRegister.ViewModels
{
   public class ItemDetailViewModel : BaseViewModel
   {
      public Employee Item { get; set; }
      public ItemDetailViewModel(Employee item = null)
      {
         Title = item?.Text;
         Item = item;
      }
   }
}
