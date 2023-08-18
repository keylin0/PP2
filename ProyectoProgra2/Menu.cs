using System;
using System.Collections.Generic;

namespace ProyectoProgra2
{
    internal class Menu
    {
        private static void Main(string[] args)
        {
            string rutaEmpleado = @"C:\Proyecto2\ProyectoProgra2\archivos\Empleado.txt";
            string rutaPlanilla = @"C:\Proyecto2\ProyectoProgra2\archivos\Planilla.txt";
            LeerArchivo archivoEmpleado = new LeerArchivo(rutaEmpleado);
            LeerArchivo archivoPlanilla = new LeerArchivo(rutaPlanilla);

            List<string> cedulas = new List<string>();
            List<string> salarioHora = new List<string>();
            List<string> horasTrabajadas = new List<string>();
            List<string> rebajo = new List<string>();
            List<string> nombres = new List<string>();

            string menuPrincipal = " ***** Menu *****\n" +
                        "1 - Ver salarios\n" +
                        "2 - Agregar Empleados\n" +
                        "3 - Salir\n" +
                        "Eliga una opcion: ";

            string menuEmpleado = "1. Guardar\n" +
                                  "2. Salir\n" +
                                  "Eliga una opcion: ";

            string menuPlanilla = "1. Guardar\n" +
                                  "2. Salir\n" +
                                  "Eliga una opcion: ";

            string menuSalarios = "1. Todos los salarios\n" +
                                  "2. Buscar salario por ID\n" +
                                  "3. Salir\n" +
                                  "Elija una opcion: \n";

            int opcionMenuPrincipal = 0;
            int opcionMenuEmpleado = 0;
            int opcionMenuSalario = 0;
            bool validaMenuPrincipal = false;
            bool validaMenuEmpleado = false;
            bool validaMenuSalario = false;
            while (opcionMenuPrincipal != 3)
            {
                Console.WriteLine(menuPrincipal);
                validaMenuPrincipal = int.TryParse(Console.ReadLine(), out opcionMenuPrincipal);
                // menu principal
                do
                {
                    if (validaMenuPrincipal)
                    {
                        if (opcionMenuPrincipal >= 1 & opcionMenuPrincipal <= 3)
                        {
                            if (opcionMenuPrincipal == 1)
                            {
                                Console.WriteLine(menuSalarios);
                                validaMenuSalario = int.TryParse(Console.ReadLine(), out opcionMenuSalario);
                                do
                                {
                                    if (validaMenuSalario)
                                    {
                                        if (opcionMenuSalario == 1)
                                        {
                                            cedulas = archivoPlanilla.cargarCedula();
                                            salarioHora = archivoPlanilla.cargarSalarioHora();
                                            horasTrabajadas = archivoPlanilla.cargarHorasTrabajadas();
                                            rebajo = archivoPlanilla.cargarRebajo();
                                            nombres = archivoEmpleado.cargarNombre();

                                            for (int i = 0; i < cedulas.Count; i++)
                                            {
                                                Console.WriteLine(nombres[i] + " " + horasTrabajadas[i] + " " + salarioHora[i] + " " + rebajo[i] +
                                                    " " + archivoPlanilla.calcularSalarioBruto(salarioHora[i], horasTrabajadas[i]) + " "
                                                    + archivoPlanilla.calcularSalarioNeto(salarioHora[i], horasTrabajadas[i], rebajo[i]));
                                            }
                                            Console.WriteLine();
                                            Console.ReadLine();
                                        }
                                        else if (opcionMenuSalario == 2)
                                        {
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion invalida, intente nuevamente...");
                                        validaMenuSalario = int.TryParse(Console.ReadLine(), out opcionMenuSalario);
                                    }
                                } while (opcionMenuSalario != 3);
                            }
                            else if (opcionMenuPrincipal == 2)
                            {
                                Console.Clear();
                                //datos empleado
                                string cedula = "";
                                string nombreCompleto = "";
                                string correo = "";
                                string datoEmpleado = "";
                                Console.WriteLine("Complete los datos del empleado");
                                Console.Write("Cedula: ");
                                cedula = Console.ReadLine();
                                Console.Write("Nombre y Apellidos: ");
                                nombreCompleto = Console.ReadLine();
                                Console.Write("Correo: ");
                                correo = Console.ReadLine();
                                datoEmpleado = cedula + " " + nombreCompleto + " " + correo;
                                Console.Clear();
                                Console.Write("Desea guardar los siguientes datos: ");
                                Console.WriteLine(datoEmpleado);
                                Console.WriteLine(menuEmpleado);
                                validaMenuEmpleado = int.TryParse(Console.ReadLine(), out opcionMenuEmpleado);
                                do
                                {
                                    if (validaMenuEmpleado)
                                    {
                                        if (opcionMenuEmpleado == 1)
                                        {
                                            archivoEmpleado.GuardarDato(datoEmpleado);
                                            Console.WriteLine("presione cualquier tecla para continuar con la planilla...");
                                            Console.ReadLine();
                                            Console.Clear();
                                            // menu planilla
                                            string profesion = "";
                                            string horasTrabajada = "";
                                            string salarioHoras = "";
                                            string rebajos = "";
                                            string datoPlanilla = "";
                                            Console.WriteLine("Complete datos para planilla");
                                            Console.Write("Profesion: ");
                                            profesion = Console.ReadLine();
                                            Console.Write("Salario hora: ");
                                            salarioHoras = Console.ReadLine();
                                            Console.Write("Horas trabajadas: ");
                                            horasTrabajada = Console.ReadLine();
                                            Console.Write("Rebajos: ");
                                            rebajos = Console.ReadLine();
                                            datoPlanilla = cedula + " " + profesion + " " + salarioHoras + " " + horasTrabajada + " " + rebajos;

                                            archivoPlanilla.GuardarDato(datoPlanilla);
                                            archivoPlanilla.Leerdato();
                                            Console.WriteLine("carga");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion invalida, intente nuevamente...");
                                        validaMenuEmpleado = int.TryParse(Console.ReadLine(), out opcionMenuEmpleado);
                                    }
                                } while (opcionMenuEmpleado != 2);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                            validaMenuPrincipal = int.TryParse(Console.ReadLine(), out opcionMenuPrincipal);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opcion invalida, intente nuevamente...");
                        validaMenuPrincipal = int.TryParse(Console.ReadLine(), out opcionMenuPrincipal);
                    }
                } while (opcionMenuPrincipal != 3);
            }
        }
    }
}