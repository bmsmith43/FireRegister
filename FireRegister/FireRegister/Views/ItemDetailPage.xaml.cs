using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FireRegister.Models;
using FireRegister.ViewModels;

namespace FireRegister.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class ItemDetailPage : ContentPage
   {
      ItemDetailViewModel viewModel;

      public ItemDetailPage(ItemDetailViewModel viewModel)
      {
         InitializeComponent();

         BindingContext = this.viewModel = viewModel;
      }

      public ItemDetailPage()
      {
         InitializeComponent();

         var item = new Employee
         {
            Id = "New ID",
            Name = "Employee Name"
         };

         viewModel = new ItemDetailViewModel(item);
         BindingContext = viewModel;
      }
   }
}