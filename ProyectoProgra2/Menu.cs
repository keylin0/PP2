using System;
using System.Collections.Generic;

namespace ProyectoProgra2
{
    internal class Menu
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Definimos las rutas de archivos que vamos a utilizar para manipular/utilizar los archivos
            string rutaEmpleado = @"C:\Proyecto2\ProyectoProgra2\archivos\Empleado.txt";
            string rutaPlanilla = @"C:\Proyecto2\ProyectoProgra2\archivos\Planilla.txt";
            string rutaPlantillaMes = @"C:\Proyecto2\ProyectoProgra2\archivos\Plantilla_del_mes.txt";
            string rutaSalarioEmpleado = @"C:\Proyecto2\ProyectoProgra2\archivos\";

            //Creamos tres instancias para acceder y procesar los datos almacenados que se necesiten de los archivos
            LeerArchivo archivoEmpleado = new LeerArchivo(rutaEmpleado);
            LeerArchivo archivoPlanilla = new LeerArchivo(rutaPlanilla);
            LeerArchivo archivoPlantillaMes = new LeerArchivo(rutaPlantillaMes);
            //Creamos las listas que seran para almacenar y utilizar los datos
            List<string> cedulas = new List<string>();
            List<string> salarioHora = new List<string>();
            List<string> horasTrabajadas = new List<string>();
            List<string> rebajo = new List<string>();
            List<string> nombres = new List<string>();

            Validaciones validar = new Validaciones();

            string menuPrincipal = " ***** Menu *****\n" + // Se crean los menus
                        "1 - Ver salarios\n" +
                        "2 - Agregar Empleados\n" +
                        "3 - Salir\n" +
                        "Eliga una opcion: ";

            string menuEmpleado = "1. Guardar\n" +
                                  "2. Salir\n" +
                                  "Eliga una opcion: ";

            string menuPlanilla = "1. Guardar\n" +
                                  "Eliga una opcion: ";

            string menuSalarios = "1. Todos los salarios\n" +
                                  "2. Buscar salario por ID\n" +
                                  "3. Salir\n" +
                                  "Elija una opcion: \n";
            string menuSalario = "Elija una opcion: \n" +
                                   "1. Imprimir \n" +
                                   "2. Salir \n";
            string menuSalarioID = "1. Intentar de nuevo\n" +
                                   "2. Salir";

            //Declaramos variables de tipo int y bool que se utilizaran para manejar las opciones del menu
            int opcionMenuPrincipal = 0;
            int opcionMenuEmpleado = 0;
            int opcionMenuSalario = 0;
            int opcionMenuPlanilla = 0;
            int opcionSubMenuSalario = 0;
            int opcionSubMenuSalarioSalir = 0;
            bool validaMenuPrincipal = false; //Declaramos variables de tipo bool
            bool validaMenuEmpleado = false;
            bool validaMenuSalario = false;
            bool validaMenuPlanilla = false;
            bool validaSubMenuSalario = false;
            bool validaSubMenuSalarioSalir = false;
            bool validaSalir = true;

            while (opcionMenuPrincipal != 3) //Abrimos un while que se ejecutara hasta que sea diferente a 3, es decir hasta que se cumpla el bucle dejara de repetirse
            {
                validaMenuPrincipal = false; //Declaramos variables de tipo bool
                validaMenuEmpleado = false;
                validaMenuSalario = false;
                validaMenuPlanilla = false;
                validaSubMenuSalario = false;
                validaSubMenuSalarioSalir = false;
                validaSalir = true;
                Console.Clear();
                Console.WriteLine(menuPrincipal); //mostramos el menu principal
                validaMenuPrincipal = int.TryParse(Console.ReadLine(), out opcionMenuPrincipal); // Este es un metodo que intenta convertir una cadena en un numero entero
                // menu principal
                do //Abrimos un do while que se ejecutara hasta que se cumpla la funcion
                {
                    if (validaMenuPrincipal)
                    {
                        if (opcionMenuPrincipal >= 1 & opcionMenuPrincipal <= 3) // Verificamos que este entre el rango de 1 y 3
                        {
                            if (opcionMenuPrincipal == 1) // Si es asi se ejecutara el siguiente if
                            {
                                Console.Clear(); //limpiamos y mostramos el menu salarios
                                Console.WriteLine(menuSalarios);
                                validaMenuSalario = int.TryParse(Console.ReadLine(), out opcionMenuSalario);
                                do
                                {
                                    if (validaMenuSalario)
                                    {
                                        if (opcionMenuSalario >= 1 & opcionMenuSalario <= 3)
                                        {
                                            if (opcionMenuSalario == 1)
                                            {
                                                Console.Clear(); //Limpiamos y cargamos los datos de los diferentes listas creadas en la clase LeerArchivo para mostrar los salarios
                                                cedulas = archivoPlanilla.cargarCedula();
                                                salarioHora = archivoPlanilla.cargarSalarioHora();
                                                horasTrabajadas = archivoPlanilla.cargarHorasTrabajadas();
                                                rebajo = archivoPlanilla.cargarRebajo();
                                                nombres = archivoEmpleado.cargarNombre();
                                                string plantillaMes = "";

                                                for (int i = 0; i < cedulas.Count; i++) //Abrimos un for que realiza operaciones en cada iteración para crear una cadena
                                                {
                                                    plantillaMes = nombres[i] + " " + horasTrabajadas[i] + " " + salarioHora[i] + " " + rebajo[i] + //La variable i se usa como un indice para acceder a los elementos en las otras listas
                                                        " " + archivoPlanilla.calcularSalarioBruto(salarioHora[i], horasTrabajadas[i]) + " "
                                                        + archivoPlanilla.calcularSalarioNeto(salarioHora[i], horasTrabajadas[i], rebajo[i]);
                                                    Console.WriteLine(plantillaMes);
                                                }

                                                Console.WriteLine(menuSalario);
                                                validaSubMenuSalario = int.TryParse(Console.ReadLine(), out opcionSubMenuSalario);
                                                do
                                                {
                                                    if (validaSubMenuSalario)
                                                    {
                                                        if (opcionSubMenuSalario >= 1 & opcionSubMenuSalario <= 2)
                                                        {
                                                            if (opcionSubMenuSalario == 1)
                                                            {
                                                                archivoPlantillaMes.GuardarDato(plantillaMes); //se guarda datos en planilla del mes
                                                                archivoPlantillaMes.Leerdato();
                                                                Console.WriteLine("Guardado con exito, presione cualquier tecla para continuar...");
                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                            validaSubMenuSalario = int.TryParse(Console.ReadLine(), out opcionSubMenuSalario);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                        validaSubMenuSalario = int.TryParse(Console.ReadLine(), out opcionSubMenuSalario);
                                                    }
                                                } while (opcionSubMenuSalario != 2);
                                                break;
                                            }
                                            else if (opcionMenuSalario == 2) //Ahora buscaremos el salario por ID
                                            {
                                                Console.Clear();
                                                cedulas = archivoPlanilla.cargarCedula();
                                                salarioHora = archivoPlanilla.cargarSalarioHora();
                                                horasTrabajadas = archivoPlanilla.cargarHorasTrabajadas();
                                                rebajo = archivoPlanilla.cargarRebajo();
                                                nombres = archivoEmpleado.cargarNombre();
                                                Console.WriteLine("Digite el ID que desea encontrar: ");
                                                String ID = Console.ReadLine();

                                                string idEncontrada = cedulas.Find(dato => dato == ID);
                                                string datoSalarioEmpleado = "";
                                                if (idEncontrada != null)
                                                {
                                                    Console.WriteLine(menuSalario);
                                                    validaSubMenuSalario = int.TryParse(Console.ReadLine(), out opcionSubMenuSalario);
                                                    do
                                                    {
                                                        if (validaSubMenuSalario)
                                                        {
                                                            if (opcionSubMenuSalario >= 1 & opcionSubMenuSalario <= 2)
                                                            {
                                                                if (opcionSubMenuSalario == 1)
                                                                {
                                                                    for (int i = 0; i < cedulas.Count; i++) //Abrimos un for que realiza operaciones en cada iteración para crear una cadena
                                                                    {
                                                                        if (idEncontrada == cedulas[i])
                                                                        {
                                                                            datoSalarioEmpleado = nombres[i] + " " + horasTrabajadas[i] + " " + salarioHora[i] + " " + rebajo[i] + //La variable i se usa como un indice para acceder a los elementos en las otras listas
                                                                                " " + archivoPlanilla.calcularSalarioBruto(salarioHora[i], horasTrabajadas[i]) + " "
                                                                                + archivoPlanilla.calcularSalarioNeto(salarioHora[i], horasTrabajadas[i], rebajo[i]);
                                                                            archivoPlantillaMes.crearArchivo(datoSalarioEmpleado, rutaSalarioEmpleado + cedulas[i] + ".txt"); // Luego esa cadena se guardara en un nuevo archivo el cual seria plantilla del mes
                                                                            Console.WriteLine(datoSalarioEmpleado);
                                                                            Console.ReadLine();
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                                validaSubMenuSalario = int.TryParse(Console.ReadLine(), out opcionSubMenuSalario);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                            validaSubMenuSalario = int.TryParse(Console.ReadLine(), out opcionSubMenuSalario);
                                                        }
                                                    } while (opcionSubMenuSalario != 2);
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No existe el id: " + ID);
                                                    Console.WriteLine(menuSalarioID);
                                                    validaSubMenuSalarioSalir = int.TryParse(Console.ReadLine(), out opcionSubMenuSalarioSalir);
                                                    do
                                                    {
                                                        if (validaSubMenuSalarioSalir)
                                                        {
                                                            if (opcionSubMenuSalarioSalir >= 1 & opcionSubMenuSalarioSalir <= 2)
                                                            {
                                                                if (opcionSubMenuSalarioSalir == 1)
                                                                {
                                                                    break;
                                                                }
                                                                else if (opcionSubMenuSalarioSalir == 2)
                                                                {
                                                                    validaSalir = false;
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                                validaSubMenuSalarioSalir = int.TryParse(Console.ReadLine(), out opcionSubMenuSalarioSalir);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                            validaSubMenuSalarioSalir = int.TryParse(Console.ReadLine(), out opcionSubMenuSalarioSalir);
                                                        }
                                                    } while (opcionSubMenuSalarioSalir != 2);
                                                    if (validaSalir == false)
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                                            validaMenuSalario = int.TryParse(Console.ReadLine(), out opcionMenuSalario);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion invalida, intente nuevamente...");
                                        validaMenuSalario = int.TryParse(Console.ReadLine(), out opcionMenuSalario);
                                        //El in.tryParse intenta convertir esa entrada en un numero entero,si la conversión es exitosa,
                                        //el valor convertido se almacena en la variable opcionMenuSalario y validaMenuSalario se establece en verdadero
                                        //Pero si falla e ingresa una letra en vez de numero se establece en falso
                                    }
                                } while (opcionMenuSalario != 3); //Abrimos otro while para la segunda pantalla
                                break;
                            }
                            else if (opcionMenuPrincipal == 2) //Si la primera opcion del menu fue 2 entonces
                            {
                                Console.Clear(); //limpiamos
                                //comenzamos pidiendo los datos del nuevo empleado
                                string cedula = ""; //Utilizamos variables tipo string para almacenar la informacion del empleado
                                string nombreCompleto = "";
                                string correo = "";
                                string datoEmpleado = "";
                                Console.WriteLine("Complete los datos del empleado");
                                cedula = validar.DatoNumerico("Cedula: ");
                                nombreCompleto = validar.DatoCaracter("Nombre y Apellidos: ");
                                correo = validar.PedirDatoNoVacio("Correo: ");
                                datoEmpleado = cedula + " " + nombreCompleto + " " + correo; //Concatenamos las 3 variables para formar una cadena con la informacion
                                Console.Clear();
                                Console.Write("Desea guardar los siguientes datos: ");
                                Console.WriteLine(datoEmpleado); // Mostramos el contenido de la variable
                                Console.WriteLine(menuEmpleado); //Mostramos las opciones de guardar o salir
                                validaMenuEmpleado = int.TryParse(Console.ReadLine(), out opcionMenuEmpleado); //Volvemos a validar
                                do
                                {
                                    if (validaMenuEmpleado)
                                    {
                                        if (opcionMenuEmpleado >= 1 & opcionMenuEmpleado <= 2)
                                        {
                                            if (opcionMenuEmpleado == 1) //Si la persona le da a guardar se muestra la pantalla de planilla
                                            {
                                                Console.Clear();
                                                archivoEmpleado.GuardarDato(datoEmpleado); //Si la persona le dio guardar se guarda la informacion del empleado y llenara el de planilla
                                                Console.WriteLine("presione cualquier tecla para continuar con la planilla...");
                                                Console.ReadLine();
                                                Console.Clear();
                                                // menu planilla
                                                string profesion = ""; //Declaramos variables tipo string para almacenar los datos de planilla
                                                string horasTrabajada = "";
                                                string salarioHoras = "";
                                                string rebajos = "";
                                                string datoPlanilla = "";
                                                Console.WriteLine("Complete datos para planilla");
                                                profesion = validar.DatoCaracter("Profesion: ");
                                                salarioHoras = validar.DatoNumerico("Salario hora: ");
                                                horasTrabajada = validar.DatoNumerico("Horas trabajadas: ");
                                                rebajos = validar.DatoNumerico("Rebajos: ");
                                                datoPlanilla = cedula + " " + profesion + " " + salarioHoras + " " + horasTrabajada + " " + rebajos; //Volvemos a concatenar los datos
                                                Console.WriteLine(menuPlanilla); //Mostramos la opcion de guardar
                                                validaMenuPlanilla = int.TryParse(Console.ReadLine(), out opcionMenuPlanilla);
                                                do
                                                {
                                                    if (validaMenuPlanilla)
                                                    {
                                                        if (opcionMenuPlanilla >= 1 & opcionMenuPlanilla <= 2)
                                                        {
                                                            archivoPlanilla.GuardarDato(datoPlanilla); //Si la persona guardo, los nuevos datos se guardan en planilla
                                                            archivoPlanilla.Leerdato(); // Se leen los datos para que sean ingresados al archivo de planilla
                                                            Console.WriteLine("    ********************************************************************************************\n" +
                                                                              "Los datos han sido guardados correctamente, precione cualquier tecla para volver al menu principal\n");
                                                            Console.ReadKey(); //Mostramos un mensaje y se manda al menu
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                            validaMenuPlanilla = int.TryParse(Console.ReadLine(), out opcionMenuPlanilla);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                        validaMenuPlanilla = int.TryParse(Console.ReadLine(), out opcionMenuPlanilla);
                                                    }
                                                } while (opcionMenuPlanilla != 2);
                                                break;
                                            }
                                            else if (opcionMenuEmpleado == 2)
                                            {
                                                break;
                                            }
                                            else //Declaramos validaciones para todas las pantallas
                                            {
                                                Console.WriteLine("Opcion invalida, intente nuevamente...");
                                                validaMenuEmpleado = int.TryParse(Console.ReadLine(), out opcionMenuEmpleado);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                                            validaMenuEmpleado = int.TryParse(Console.ReadLine(), out opcionMenuEmpleado);
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