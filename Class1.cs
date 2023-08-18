using System;
using System.Collections.Generic;
using System.IO;
using practicabuscarporid.files;

namespace practicabuscarporid
{
    internal class Program
    {
        // Ruta del archivo que contiene la información de los empleados
        static string path = @"C:\Users\Usuario\source\repos\practicabuscarporid\files\Id.txt";

        static void Main(string[] args)
        {
            // Se crea una lista de tipo string llamada 'nombres' para almacenar las líneas del archivo
            List<string> nombres = new List<string>();

            // Crear una instancia de la clase LeerArchivo para leer los datos del archivo
            LeerArchivo leer = new LeerArchivo(path);
            nombres = leer.LeerArchivoId();

            // Solicitar al usuario que ingrese el ID del empleado a buscar
            Console.WriteLine("Digite el id que necesita encontrar");
            string id = Console.ReadLine();// se lee la opcion que el usuario ingresó

            // Utilizar el método Find para buscar al empleado por ID, utilizando Contains para buscar coincidencias
            string empleadoEncontrado = nombres.Find(i => i.Contains(id + " "));

            // Verificar si el empleado fue encontrado en la lista
            if (empleadoEncontrado == null)
            {
                Console.WriteLine("El ID no ha sido encontrado");
            }
            else
            {
                // Dividir la línea del empleado en un array utilizando el espacio como separador
                string[] datosEmpleado = empleadoEncontrado.Split(' ');

                // Mostrar los datos del empleado encontrado
                Console.WriteLine($"Cedula: {datosEmpleado[0]}");
                Console.WriteLine($"Cédula: {datosEmpleado[1]}");
                Console.WriteLine($"Nombre: {datosEmpleado[2]}");
                Console.WriteLine($"Correo: {datosEmpleado[3]}");

                // Mostrar opciones para el usuario
                Console.WriteLine("Opciones:");
                Console.WriteLine("1. Imprimir");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción: ");
                int opcionEmpleado = int.Parse(Console.ReadLine());

                switch (opcionEmpleado)
                {
                    case 1:
                        // Crear un archivo y escribir los datos del empleado en él
                        string rutaNuevoArchivo = @"C:\Users\Usuario\source\repos\practicabuscarporid\files\archivoguardado.txt";
                        using (StreamWriter sw = new StreamWriter(rutaNuevoArchivo))
                        {
                            sw.WriteLine($"Cédula: {datosEmpleado[1]}");
                            sw.WriteLine($"Nombre: {datosEmpleado[2]}");
                            sw.WriteLine($"Correo: {datosEmpleado[3]}");
                        }
                        Console.WriteLine("Archivo creado con los datos del empleado.");
                        break;
                    case 2:
                        // Salir
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}
