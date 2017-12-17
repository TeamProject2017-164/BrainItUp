using System;
using System.Windows;

namespace BrainItUp
{
    public static class BrainItUpMessageBox
    {
        public static void Warning(string warning)
        {
            MessageBox.Show(warning, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void Error(Exception ex)
        {
            MessageBox.Show("Something went wrong! " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

