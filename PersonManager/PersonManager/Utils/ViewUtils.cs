using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PersonManager.Utils
{
    public static class ViewUtils
    {
        public static void EnableButton(Button btn)
        {
            btn.Visibility = Visibility.Visible;
            btn.IsEnabled = true;
        }

        public static void DisableButton(Button btn)
        {
            btn.Visibility = Visibility.Hidden;
            btn.IsEnabled = false;
        }

        internal static void DisplayErrorMessage(string message)
        {
            string messageBoxText = message;
            string caption = "Error in Delete";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }
    }
}
