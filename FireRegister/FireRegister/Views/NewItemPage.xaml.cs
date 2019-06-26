using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FireRegister.Models;

namespace FireRegister.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class NewItemPage : ContentPage
   {
      public Employee Item { get; set; }

      public NewItemPage()
      {
         InitializeComponent();

         Item = new Employee
         {
            Id = "New ID",
            Name = "Employee Name"
         };

         BindingContext = this;
      }

      async void Save_Clicked(object sender, EventArgs e)
      {
         MessagingCenter.Send(this, "AddItem", Item);
         await Navigation.PopModalAsync();
      }
   }
}