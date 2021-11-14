using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    public class Persona
    {
        public string nombreApellido;
        public int dni;
        public string domicilio;
        public string telefono;
        public string email;
        public string actividad;


        public int Dni { get => dni; set => dni = value; }
        public string Nombre_apelido { get => nombreApellido; set => nombreApellido = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Actividad { get => actividad; set => actividad = value; }



        public void MostrarPersona()
        {            
            Console.WriteLine("Nombre: " + nombreApellido);
            Console.WriteLine("Dni: " + dni);
            Console.WriteLine("Domicilio: " + domicilio);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Telefono: " + telefono);
            Console.WriteLine("Actividad Realizada: " + actividad);

            Console.WriteLine("--------------------------- \n");
        }
    }
}
