using EmploTaskTwo.UI.Helpers;
using System.Windows;
using System;

namespace EmploTaskTwo.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (args.ExceptionObject is Exception ex)
                {
                    GlobalExceptionHandler.Handle(ex);
                }
            };

            DispatcherUnhandledException += (sender, args) =>
            {
                GlobalExceptionHandler.Handle(args.Exception);
                args.Handled = true;
            };

            base.OnStartup(e);
        }
    }
}
