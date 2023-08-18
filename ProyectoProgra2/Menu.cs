using System;
using System.Collections.Generic;

namespace ProyectoProgra2
{
    internal class Menu
    {
        private static void Main(string[] args)
        {
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
            string menuSalarioID = "Elija una opcion: \n" +
                                   "1. Imprimir \n" +
                                   "2. Salir \n";

            int opcionMenuSalarioID = 0;//Declaramos variables de tipo int y bool que se utilizaran para manejar las opciones del menu
            int opcionMenuPrincipal = 0;
            int opcionMenuEmpleado = 0;
            int opcionMenuSalario = 0;
            int opcionMenuPlanilla = 0;
            bool validaMenuPrincipal = false; //Declaramos variables de tipo bool
            bool validaMenuEmpleado = false;
            bool validaMenuSalario = false;
            bool validaMenuPlanilla = false;
            bool validaMenuSalarioID = false;

            while (opcionMenuPrincipal != 3) //Abrimos un while que se ejecutara hasta que sea diferente a 3, es decir hasta que se cumpla el bucle dejara de repetirse
            {
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
                                                Console.Clear();
                                                plantillaMes = nombres[i] + " " + horasTrabajadas[i] + " " + salarioHora[i] + " " + rebajo[i] + //La variable i se usa como un indice para acceder a los elementos en las otras listas
                                                    " " + archivoPlanilla.calcularSalarioBruto(salarioHora[i], horasTrabajadas[i]) + " "
                                                    + archivoPlanilla.calcularSalarioNeto(salarioHora[i], horasTrabajadas[i], rebajo[i]);
                                                archivoPlantillaMes.GuardarDato(plantillaMes); // Luego esa cadena se guardara en un nuevo archivo el cual seria plantilla del mes
                                                Console.WriteLine(plantillaMes);
                                            }
                                            Console.WriteLine();
                                            Console.ReadLine(); //Esperamos que el usuario precione una tecla para continuar
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
                                                Console.WriteLine(menuSalarioID);
                                                validaMenuSalarioID = int.TryParse(Console.ReadLine(), out opcionMenuSalarioID);
                                                if (validaMenuSalarioID)
                                                {
                                                    if (opcionMenuSalarioID == 1)
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
                                            }
                                            else
                                            {
                                                Console.WriteLine("El ID no existe \n" +
                                                                  "1. Intentar de nuevo\n" +
                                                                  "2. Salir");
                                                Console.ReadLine();
                                            }
                                            //if (idEncontrada ==  )
                                            {
                                                string rutaCedulaEmpleado = @"C:\Proyecto2\ProyectoProgra2\archivos\" + cedulas + "Numero_de_cedula.txt";
                                            }
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
                                Console.Write("Cedula: ");
                                cedula = Console.ReadLine();
                                Console.Write("Nombre y Apellidos: ");
                                nombreCompleto = Console.ReadLine();
                                Console.Write("Correo: ");
                                correo = Console.ReadLine();
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
                                            Console.Write("Profesion: ");
                                            profesion = Console.ReadLine();
                                            Console.Write("Salario hora: ");
                                            salarioHoras = Console.ReadLine();
                                            Console.Write("Horas trabajadas: ");
                                            horasTrabajada = Console.ReadLine();
                                            Console.Write("Rebajos: ");
                                            rebajos = Console.ReadLine();
                                            datoPlanilla = cedula + " " + profesion + " " + salarioHoras + " " + horasTrabajada + " " + rebajos; //Volvemos a concatenar los datos
                                            Console.WriteLine(menuPlanilla); //Mostramos la opcion de guardar

                                            Console.Clear(); //aLimpiamos

                                            archivoPlanilla.GuardarDato(datoPlanilla); //Si la persona guardo, los nuevos datos se guardan en planilla
                                            archivoPlanilla.Leerdato(); // Se leen los datos para que sean ingresados al archivo de planilla
                                            Console.WriteLine("    ********************************************************************************************\n" +
                                                              "Los datos han sido guardados correctamente, precione cualquier tecla para volver al menu principal\n");
                                            Console.ReadKey(); //Mostramos un mensaje y se manda al menu
                                            Console.Clear();
                                            break;
                                        }
                                        else //Declaramos validaciones para todas las pantallas
                                        {
                                            Console.WriteLine("Opcion invalida, intente nuevamente...");
                                            validaMenuPlanilla = int.TryParse(Console.ReadLine(), out opcionMenuPlanilla);
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

        private string DatoNoVacio(string campo) //Declaramos un metodo tipo string para evitar que el usuario de enter sin llenar los datos, es decir evitar un campo vacio
        {
            string dato;
            do
            {
                Console.Write($"{campo}: ");
                dato = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("El campo no puede estar vacío. Ingrese nuevamente.");
                }
            } while (string.IsNullOrWhiteSpace(dato));

            return dato;
        }
    }
}