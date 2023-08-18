using System;

namespace ProyectoProgra2
{
    public class Validaciones
    {
        public string PedirDatoNoVacio(string campo) 
        {
            string dato;
            do
            {
                Console.Write(campo);
                dato = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("El campo no puede estar vacío, intente nuevamente...");
                }
            } while (string.IsNullOrWhiteSpace(dato));

            return dato;
        }

        public string DatoNumerico(string campo)
        {
            string dato;
            bool esDigito = true;
            Console.Write(campo);
            dato = Console.ReadLine();
            do
            {
                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("El campo no puede estar vacío. Ingrese nuevamente.");
                    dato = Console.ReadLine();
                }

                foreach (char c in dato)
                {
                    if (Char.IsDigit(c))
                    {
                        esDigito = true;
                    }
                    else
                    {
                        esDigito = false;
                        break;
                    }
                }
                if (esDigito == false)
                {
                    Console.WriteLine("El campo no es un numero, intente nuevamente...");
                    dato = Console.ReadLine();
                }
            } while (esDigito == false);

            return dato;
        }

        public string DatoCaracter(string campo)
        {

            string dato;
            bool esLetra = true;
            Console.Write(campo);
            dato = Console.ReadLine();
            do
            {
                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("El campo no puede estar vacío. Ingrese nuevamente.");
                    dato = Console.ReadLine();
                }

                foreach (char c in dato)
                {
                    if (Char.IsLetter(c))
                    {
                        esLetra = true;
                    }
                    else
                    {
                        esLetra = false;
                        break;
                    }
                }
                if (esLetra == false)
                {
                    Console.WriteLine("El campo no es un caracter, intente nuevamente...");
                    dato = Console.ReadLine();
                }
            } while (esLetra == false);

            return dato;
        }

        public string DatoCaracterNumerico(string campo)
        {

            string dato;
            bool esLetra = true;
            Console.Write(campo);
            dato = Console.ReadLine();
            do
            {
                if (string.IsNullOrWhiteSpace(dato))
                {
                    Console.WriteLine("El campo no puede estar vacío. Ingrese nuevamente.");
                    dato = Console.ReadLine();
                }

                foreach (char c in dato)
                {
                    if (Char.IsSymbol(c))
                    {
                        esLetra = true;
                    }
                    else
                    {
                        esLetra = false;
                        break;
                    }
                }
                if (esLetra == false)
                {
                    Console.WriteLine("El campo no es un correo, intente nuevamente...");
                    dato = Console.ReadLine();
                }
            } while (esLetra == false);

            return dato;
        }
    }
}