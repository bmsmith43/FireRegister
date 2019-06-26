using System.Net.Http;
using FireRegister.Models;
using FireRegister.Views;
using Xamarin.Forms;

namespace FireRegister.ViewModels
{
   public class LoginViewModel : BaseViewModel
   {
      private string _initials;
      private string _error;

      public string Initials
      {
         get => _initials;
         set
         {
            if (SetProperty(ref _initials, value)) 
               LoginCommand.ChangeCanExecute();
         }
      }

      public string Error
      {
         get => _error;
         set => SetProperty(ref _error, value);
      }

      #region Constructors
      public LoginViewModel()
      {
         Title = "Login";
         LoginCommand = new Command(Login, CanLogin);
      }

      #endregion

      #region Command Properties
      public Command LoginCommand { get; private set; }

      #endregion

      #region Command Handling Methods
      private bool CanLogin()
      {
         return !string.IsNullOrEmpty(Initials);
      }

      private async void Login()
      {
         Employee employee = null;
         try
         {
            employee = await DataStore.GetEmployeeAsync(Initials);
         }
         catch (HttpRequestException)
         {
         }

         if (employee != null)
         {
            Application.Current.MainPage = new MainPage(employee);
         }
         else
         {
            Error = "Couldn't find employee";
         }
      }

      #endregion
   }
}
