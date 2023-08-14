using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoProgra2
{
    public class LeerArchivo
    {
        private string _ruta;
        private List<string> nombres = new List<string>();
        private List<string> cedulas = new List<string>();
        private List<string> correos = new List<string>();

        public LeerArchivo(string rutaNueva)
        {
            _ruta = rutaNueva;
        }

        public void LeerEmpleado()
        {
            using (StreamReader lector = new StreamReader(_ruta))
            {
                while (lector.EndOfStream != true)
                {
                    Console.WriteLine(lector.ReadLine());
                }
                lector.Close();
            }
        }

        public void AgregarEmpleado(string empleado)
        {
            using (StreamWriter lector = new StreamWriter(_ruta, true))
            {
                lector.WriteLine(empleado);
                lector.Close();
            }
        }

        public void crearArchivo(string datos, string ruta) {
            using (StreamWriter lector = new StreamWriter(ruta, false))
            {
                lector.WriteLine(datos);
                lector.Close();
            }
        }

        public void CargarDatos(string ruta) {
            using (StreamReader lector = new StreamReader(_ruta))
            {
                while (lector.EndOfStream != true)
                {
                    string str = lector.ReadLine();
                    string[] lista = str.Split(' ');
                    cedulas.Add(lista[0]);
                    nombres.Add(lista[1]);
                }
                foreach (var emple in cedulas)
                {
                    Console.WriteLine(emple);
                }
                lector.Close();
            }
        }
    }
}