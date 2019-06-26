using FireRegister.Models;
using FireRegister.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireRegister.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MainPage : TabbedPage
   {
      private readonly Employee _employee;
      private readonly SignInOutViewModel _signInOutViewModel;

      public SignInOutViewModel SignInOutViewModel
      {
         get { return _signInOutViewModel; }
      }

      public MainPage(Employee employee)
      {
         _employee = employee;
         _signInOutViewModel = new SignInOutViewModel(_employee);
         InitializeComponent();
      }
   }
}