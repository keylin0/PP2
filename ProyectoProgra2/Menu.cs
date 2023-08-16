using System;

namespace ProyectoProgra2
{
    internal class Menu
    {
        private static void Main(string[] args)
        {
            string path = @"C:\Proyecto2\ProyectoProgra2\archivos\Empleado.txt";
            LeerArchivo archivo = new LeerArchivo(path);

            //List<string> cedulas = new List<string>();

            string menuPrincipal = " ***** Menu ***** \n" +
                        "1 - Ver salarios \n" +
                        "2 - Agregar Empleados \n" +
                        "Elija una opcion: ";
            string menuSalarios = "1. Todos los salarios\n" +
                                  "2. Buscar salario por ID \n" +
                                  "3. Salir \n" +
                                  "Elija una opcion: \n";

            int opcionMenu = 0;
            bool validaMenu = false;
            bool validaOpcion = true;
            int opcionCliente;
            int opcionEmpleados;
            while (opcionMenu != 2)
            {
                Console.WriteLine(menuPrincipal);
                validaMenu = int.TryParse(Console.ReadLine(), out opcionMenu);
                if (validaMenu == true)
                {
                    if (opcionMenu == 1) //Pantalla 1
                    {
                        Console.Clear();
                        Console.WriteLine(menuSalarios);

                        validaMenu = int.TryParse(Console.ReadLine(), out opcionCliente);
                        do
                        {
                            if (opcionCliente == 1)
                            {
                            }
                            else if (opcionCliente == 3)
                            {
                                Console.Clear();
                                validaOpcion = false;
                            }
                            else if (opcionCliente == 2)
                            {
                                Console.WriteLine("Ingrese la cedula del empleado que desea encontrar:");
                                //string[] campos = new string[3];
                                if (validaOpcion == true)
                                {
                                    Console.Clear();
                                    archivo.CargarDatos(path);
                                }
                            }
                            else
                            {
                                Console.WriteLine("opcion invalida, intente nuevamente");
                                validaMenu = int.TryParse(Console.ReadLine(), out opcionCliente);
                            }
                        } while (validaOpcion);
                    }
                    else if (opcionMenu == 2) //pantalla 2
                    {
                        Console.Clear();
                        string datoEmpleado;
                        Console.WriteLine("Ingrese los datos del nuevo empleado: \n");
                        Console.WriteLine("Cedula:");
                        datoEmpleado = Console.ReadLine();
                        Console.WriteLine("Nombre y Apellido:");
                        datoEmpleado = Console.ReadLine();
                        Console.WriteLine("Email:");
                        datoEmpleado = Console.ReadLine();
                        Console.WriteLine("Datos ingresados");
                        Console.WriteLine($"Cedula: {datoEmpleado}");
                        Console.WriteLine($"Nombre y Apellido: {datoEmpleado}");
                        Console.WriteLine($"Email: {datoEmpleado}");
                        Console.WriteLine("*********************** \n" +
                                          "1. Guardar / 2. Salir");

                        validaMenu = int.TryParse(Console.ReadLine(), out opcionEmpleados);
                        do
                        {
                            if (opcionEmpleados == 1)
                            {
                                archivo.LeerEmpleado();
                                while (archivo != null)
                                {
                                    archivo.AgregarEmpleado(datoEmpleado);
                                    archivo.AgregarEmpleado(Console.ReadLine());
                                    Console.WriteLine(archivo);
                                    archivo.CargarDatos(Console.ReadLine());

                                    Console.ReadKey();
                                }
                            }
                            else if (opcionEmpleados == 2)
                            {
                                Console.Clear();
                                validaOpcion = false;
                            }
                        } while (validaOpcion);
                    }
                }
                else
                {
                    Console.WriteLine("El valor no es parte del menu");
                }
                validaOpcion = true;
            }
        }

        private static string PedirDatoNoVacio(string campo)
        {
            string dato;
            do
            {
                Console.Write($"{campo}: ");
                dato = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("El campo no puede estar vacío, intente nuevamente.");
                }
            } while (string.IsNullOrWhiteSpace(dato));

            return dato;
        }
    }
}