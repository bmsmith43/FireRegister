﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FireRegister.Services;
using FireRegister.Views;
using FireRegister.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FireRegister
{
   public partial class App : Application
   {
      //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
      public static string AzureBackendUrl = "http://fireregister.azurewebsites.net"; //"http://localhost:5000";
      public static bool UseMockDataStore = false;

      public App()
      {
         InitializeComponent();

         if (UseMockDataStore)
            DependencyService.Register<MockDataStore>();
         else
            DependencyService.Register<AzureDataStore>();

         LoginPage loginPage = new LoginPage();
         loginPage.BindingContext = new LoginViewModel();

         MainPage = loginPage;
      }

      protected override void OnStart()
      {
         // Handle when your app starts
      }

      protected override void OnSleep()
      {
         // Handle when your app sleeps
      }

      protected override void OnResume()
      {
         // Handle when your app resumes
      }
   }
}
