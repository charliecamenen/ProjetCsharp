using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEspionKeyLogger
{
    class Enregistrement
    {
        //Contenu de l'enregistrement courrant
        private String contenu;


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
