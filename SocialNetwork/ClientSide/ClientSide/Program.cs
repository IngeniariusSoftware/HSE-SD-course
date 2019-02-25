
namespace ClientSide
{
    using System;
    using System.Windows.Forms;

    using ClientSide.UI.MainPage;
    using ClientSide.UI.Аuthentication;

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new АuthenticationForm());
            if (Client.Instance.User != null)
            {
                Application.Run(new MainPageForm());
            }
        }
    }
}