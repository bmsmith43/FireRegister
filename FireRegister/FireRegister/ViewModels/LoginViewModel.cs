using FireRegister.Views;
using Xamarin.Forms;

namespace FireRegister.ViewModels
{
   public class LoginViewModel : BaseViewModel
   {
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
         return true;
      }

      private void Login()
      {
         Application.Current.MainPage = new MainPage();
      }

      #endregion
   }
}
