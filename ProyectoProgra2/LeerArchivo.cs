using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoProgra2
{
    public class LeerArchivo
    {
        private string _ruta;

        public LeerArchivo(string rutaNueva)
        {
            _ruta = rutaNueva;
        }

        public void crearArchivo(string datos, string ruta)
        {
            using (StreamWriter lector = new StreamWriter(ruta, false))
            {
                lector.WriteLine(datos);
                lector.Close();
            }
        }

        public void Leerdato()
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

        public void GuardarDato(string dato)
        {
            using (StreamWriter lector = new StreamWriter(_ruta, true))
            {
                lector.WriteLine(dato);
                lector.Close();
            }
        }

        public int calcularSalarioBruto(string salarioHora, string horasTrabajo)
        {
            return int.Parse(salarioHora) * int.Parse(horasTrabajo);
        }

        public double calcularSalarioNeto(string salarioHora, string horasTrabajo, string rebajo)
        {
            int bruto = calcularSalarioBruto(salarioHora, horasTrabajo);
            double rebajoTotal = bruto * (double.Parse(rebajo) / 100.0);
            Console.WriteLine(bruto);
            Console.WriteLine(rebajoTotal);
            return bruto - rebajoTotal;
        }

        public List<string> cargarCedula()
        {
            List<string> cedulas = new List<string>();
            using (StreamReader lector = new StreamReader(_ruta))
            {
                while (lector.EndOfStream != true)
                {
                    string str = lector.ReadLine();
                    string[] lista = str.Split(' ');
                    cedulas.Add(lista[0]);
                }
            }
            return cedulas;
        }

        public List<string> cargarSalarioHora()
        {
            List<string> salarioHora = new List<string>();
            using (StreamReader lector = new StreamReader(_ruta))
            {
                while (lector.EndOfStream != true)
                {
                    string str = lector.ReadLine();
                    string[] lista = str.Split(' ');
                    salarioHora.Add(lista[2]);
                }
            }
            return salarioHora;
        }

        public List<string> cargarHorasTrabajadas()
        {
            List<string> horasTrabajadas = new List<string>();
            using (StreamReader lector = new StreamReader(_ruta))
            {
                while (lector.EndOfStream != true)
                {
                    string str = lector.ReadLine();
                    string[] lista = str.Split(' ');
                    horasTrabajadas.Add(lista[3]);
                }
            }
            return horasTrabajadas;
        }

        public List<string> cargarRebajo()
        {
            List<string> rebajo = new List<string>();
            using (StreamReader lector = new StreamReader(_ruta))
            {
                while (lector.EndOfStream != true)
                {
                    string str = lector.ReadLine();
                    string[] lista = str.Split(' ');
                    rebajo.Add(lista[4]);
                }
            }
            return rebajo;
        }
        public List<string> cargarNombre()
        {
            List<string> nombres = new List<string>();
            using (StreamReader lector = new StreamReader(_ruta))
            {
                while (lector.EndOfStream != true)
                {
                    string str = lector.ReadLine();
                    string[] lista = str.Split(' ');
                    nombres.Add(lista[1]);
                }
            }
            return nombres;
        }
    }
}