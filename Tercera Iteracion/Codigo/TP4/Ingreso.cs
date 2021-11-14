using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class Ingreso
    {
        public DateTime fechaIngreso;
        public DateTime fechaEgreso;
        public Persona persona;
        public double temperatura;
        public string patenteVehiculo;
        public string destino;
        public bool estadoIngreso;

        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaEgreso { get => fechaEgreso; set => fechaEgreso = value; }
        public Persona Persona { get => persona; set => persona = value; }
        public double Temperatura { get => temperatura; set => temperatura = value; }
        public string PatenteVehiculo { get => patenteVehiculo; set => patenteVehiculo = value; }
        public string Destino { get => destino; set => destino = value; }
        public bool EstadoIngreso { get => estadoIngreso; set => estadoIngreso = value; }

        public void MostrarIngreso()
        {
            Console.WriteLine("INGRESO DE: \n");
            persona.MostrarPersona();
            Console.WriteLine("Fecha de entrada: " + fechaIngreso);
            Console.WriteLine("Temperatura: " + temperatura);
            Console.WriteLine("Patente Vehiculo: " + patenteVehiculo);
            Console.WriteLine("Destino: " + destino);
            Console.WriteLine("Fecha de salida: " + fechaEgreso);
            Console.WriteLine("Estado de Ingreso: " + estadoIngreso);

        }
    }
}
