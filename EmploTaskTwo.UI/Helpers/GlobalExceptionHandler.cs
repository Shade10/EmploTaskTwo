using System;
using System.Windows;

namespace EmploTaskTwo.UI.Helpers
{
    public static class GlobalExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
