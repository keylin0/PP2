using System;

namespace ProyectoProgra2
{
    internal class Menu
    {
        private static void Main(string[] args)
        {
            string path = @"C:\Proyecto2\ProyectoProgra2\archivos\Empleado.txt";
            LeerArchivo archivo = new LeerArchivo(path);
            string menuPrincipal = " ***** Menu ***** \n" +
                            "1 - Ver salarios \n" +
                            "2 - Agregar Empleados \n" +
                            "3 - Salir \n" +
                            "Elija una opcion: ";
            string menuSalarios = "***** Salarios de los empleados *****\n" +
                "**** Imprimir o salir **** \n" +
                "1. Imprimir \n" +
                "2. Salir \n" +
                "Elija una opcion: ";
            int opcionMenu = 0;
            bool validaMenu = false;
            bool validaOpcion = true;
            int opcionCliente;
            while (opcionMenu != 3)
            {
                Console.WriteLine(menuPrincipal);
                validaMenu = int.TryParse(Console.ReadLine(), out opcionMenu);
                if (validaMenu == true)
                {
                    if (opcionMenu == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(menuSalarios);
                        validaMenu = int.TryParse(Console.ReadLine(), out opcionCliente);
                        do
                        {
                            if (opcionCliente == 1)
                            {
                                Console.Clear();
                            }
                            else if (opcionCliente == 2)
                            {
                                Console.Clear();
                                validaOpcion = false;
                            }
                            else
                            {
                                Console.WriteLine("opcion invalida, intente nuevamente");
                                validaMenu = int.TryParse(Console.ReadLine(), out opcionCliente);
                            }
                        } while (validaOpcion);
                    }
                    else if (opcionMenu == 2)
                    {
                        Console.Clear();
                        archivo.CargarDatos(path);
                    }
                    else if (opcionMenu == 3)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("El valor no es parte del menu");
                }
                validaOpcion = true;
            }
        }
    }
}