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
      NewUserViewModel viewModel;

      public ItemDetailPage(NewUserViewModel viewModel)
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

         viewModel = new NewUserViewModel(item);
         BindingContext = viewModel;
      }
   }
}