using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoProgra2
{
    public class LeerArchivo
    {
        private string _ruta;
        private List<string> empleados = new List<string>();

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
    }
}