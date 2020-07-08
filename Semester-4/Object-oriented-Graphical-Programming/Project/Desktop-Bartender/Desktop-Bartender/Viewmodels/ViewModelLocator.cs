using Desktop_Bartender.Helpers;
using Desktop_Bartender.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Desktop_Bartender.Viewmodels
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<ForgotPasswordViewModel>();
            SimpleIoc.Default.Register<IngredientsViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            SimpleIoc.Default.Register<CocktailListViewModel>();
            SimpleIoc.Default.Register<CocktailViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Login", new Uri("../Views/Login.xaml", UriKind.Relative));
            navigationService.Configure("Register", new Uri("../Views/Register.xaml", UriKind.Relative));
            navigationService.Configure("ForgotPassword", new Uri("../Views/ForgotPassword.xaml", UriKind.Relative));
            navigationService.Configure("Ingredients", new Uri("../Views/Ingredients.xaml", UriKind.Relative));
            navigationService.Configure("User", new Uri("../Views/User.xaml", UriKind.Relative));
            navigationService.Configure("CocktailList", new Uri("../Views/CocktailList.xaml", UriKind.Relative));
            navigationService.Configure("Cocktail", new Uri("../Views/Cocktail.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        public RegisterViewModel RegisterViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>();
            }
        }
        public ForgotPasswordViewModel ForgotPasswordViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ForgotPasswordViewModel>();
            }
        }
        public IngredientsViewModel IngredientsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IngredientsViewModel>();
            }
        }
        public UserViewModel UserViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewModel>();
            }
        }
        public CocktailListViewModel CocktailListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CocktailListViewModel>();
            }
        }
        public CocktailViewModel CocktailViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CocktailViewModel>();
            }
        }
        public static void Cleanup()
        {
        }
    }
}
