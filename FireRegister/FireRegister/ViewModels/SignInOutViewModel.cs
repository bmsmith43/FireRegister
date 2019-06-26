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
      private bool _isSignedIn;

      #endregion

      #region Constructors
      public SignInOutViewModel()
      {
         IsSignedIn = false; // TODO: Load sign-in status from cloud.
         Title = IsSignedIn ? _signOutTitle : _signInTitle;

         SignInCommand = new Command(SignIn, CanSignIn);
         SignOutCommand = new Command(SignOut, CanSignOut);
      }

      #endregion

      #region Properties
      public bool IsSignedIn
      {
         get { return _isSignedIn; }
         set { SetProperty(ref _isSignedIn, value); }
      }

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
         return IsSignedIn == false;
      }

      private void SignIn()
      {
         IsSignedIn = true;
         Title = _signOutTitle;

         RefreshCommands();
      }

      private bool CanSignOut()
      {
         return IsSignedIn;
      }

      private void SignOut()
      {
         IsSignedIn = false;
         Title = _signInTitle;

         RefreshCommands();
      }

      #endregion
   }
}
