using System;
using System.Windows.Forms;

namespace Othello
{
    public static class Program
    {
        /// The main entry point for the application.
        [STAThread]

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameSettings());
        }

    }
}
