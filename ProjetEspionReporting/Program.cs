using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjetEspionReporting
{
    static class Program
    {
        [STAThread]
        static void Main()

        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Reporting());
        }
    }
}
