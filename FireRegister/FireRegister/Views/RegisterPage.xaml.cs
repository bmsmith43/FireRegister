using FireRegister.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireRegister.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
   {
		public RegisterPage ()
		{
			InitializeComponent ();
		}

      protected override void OnAppearing()
      {
         base.OnAppearing();

         var viewModel = BindingContext as RegisterViewModel;

         viewModel?.LoadItemsCommand.Execute(null);
      }

   }
}