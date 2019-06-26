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
            Text = "Item name",
            Description = "This is an item description."
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