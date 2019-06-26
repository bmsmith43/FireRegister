using System.Runtime.CompilerServices;
using FireRegister.Models;
using Xamarin.Forms;

namespace FireRegister.ViewModels
{
   public class SignInOutViewModel : BaseViewModel
   {
      #region Constants
      private const string _signInTitle = "Sign In";
      private const string _signOutTitle = "Sign Out";

      #endregion

      #region Fields
      private Employee _employee;

      #endregion

      #region Constructors
      public SignInOutViewModel(Employee employee)
      {
         _employee = employee;
         Title = _employee.SignedIn ? _signOutTitle : _signInTitle;

         SignInCommand = new Command(SignIn, CanSignIn);
         SignOutCommand = new Command(SignOut, CanSignOut);
      }

      #endregion

      #region Properties
      public Employee Employee => _employee;

      #endregion

      #region Command Properties
      public Command SignInCommand { get; private set; }

      public Command SignOutCommand { get; private set; }

      #endregion

      #region Private Methods
      private void RefreshCommands()
      {
         SignInCommand.ChangeCanExecute();
         SignOutCommand.ChangeCanExecute();
      }

      #endregion

      #region Command Handling Methods
      private bool CanSignIn()
      {
         return !_employee.SignedIn;
      }

      private async void SignIn()
      {
         _employee.SignedIn = true;
         await DataStore.UpdateEmployeeAsync(_employee);
         Title = _signOutTitle;

         RefreshCommands();
      }

      private bool CanSignOut()
      {
         return _employee.SignedIn;
      }

      private async void SignOut()
      {
         _employee.SignedIn = false;
         await DataStore.UpdateEmployeeAsync(_employee);
         Title = _signInTitle;

         RefreshCommands();
      }

      #endregion
   }
}
