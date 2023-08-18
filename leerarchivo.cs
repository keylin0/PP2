using System;
using System.IO;
using System.Collections.Generic;

namespace practicabuscarporid.files
{
    internal class LeerArchivo
    {
        // Almacena la ruta del archivo a leer
        private string _path;

        // Lista para almacenar las líneas leídas del archivo
        private List<string> nombres = new List<string>();

        // Constructor de la clase, recibe la ruta del archivo como parámetro
        public LeerArchivo(string path)
        {
            _path = path;
        }

        // Método para leer el archivo y obtener una lista de líneas
        public List<string> LeerArchivoId()
        {
            // Utiliza la clase StreamReader para abrir y leer el archivo 
            using (StreamReader sr = new StreamReader(_path))
            {
                // Ciclo que se ejecuta mientras no se haya llegado al final del archivo
                while (!sr.EndOfStream)
                {
                    // Lee una línea del archivo y la agrega a la lista 'nombres'
                    nombres.Add(sr.ReadLine());
                }

                // Retorna la lista de líneas del archivo
                return nombres;
            }
        }
    }
}
