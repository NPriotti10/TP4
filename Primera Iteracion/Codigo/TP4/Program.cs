using System;
using System.Collections.Generic;
using System.Text;


namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanciarValoresPredeterminados();
            int num;            
            do
            {
                Console.WriteLine("---MENU---");
                Console.WriteLine("Por favor ingrese: \n");
                Console.WriteLine("1)-Si desea verificar la autorizacion de una persona. \n");
                Console.WriteLine("2)-Si desea registrar una persona. \n");
                Console.WriteLine("Ingrese 0 si desea salir del programa\n");
                Console.WriteLine("-----------------------------------------------------------\n");

                num = int.Parse(Console.ReadLine());

                while (num < 0 || num > 2)
                {
                    Console.WriteLine("Ingrese una opcion valida \n");
                    num = int.Parse(Console.ReadLine());
                }

                if (num == 1)
                {
                    int dni;
                    Console.WriteLine("Ingrese el DNI de la persona \n");
                    dni = int.Parse(Console.ReadLine());
                    foreach (Persona personaActual in RepositorioPersonas.listaPersonas)
                    {
                        if (dni == personaActual.Dni)
                        {
                            Console.WriteLine("PERSONA AUTORIZADA");
                            personaActual.MostrarPersona();
                        }
                    }
                }
                if (num == 2)
                {
                    RegistrarPersona();   
                }
            } while (num != 0);
        }
        
        public static void RegistrarPersona()
        {            
            Persona persona = new Persona();
            Console.WriteLine("Ingrese su nombre y apellido. \n");
            persona.nombreApellido = Console.ReadLine();
            Console.WriteLine("Ingrese su dni. \n");
            persona.dni = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese su domicilio. \n");
            persona.domicilio = Console.ReadLine();
            Console.WriteLine("Ingrese su telefono. \n");
            persona.telefono = Console.ReadLine();
            Console.WriteLine("Ingrese su email. \n");
            persona.email = Console.ReadLine();

            Console.WriteLine("Seleccione una actividad\n");
            int i = 1;
            foreach(var actividadActual in RepositorioActividades.listaActividades)
            {
                Console.WriteLine("Áctividad" + i + ": " + actividadActual.nombre);
                i++;
            }
            int opcion = int.Parse(Console.ReadLine());
            string nombre;
            foreach(var actividadActual in RepositorioActividades.listaActividades)
            {
                if(opcion == actividadActual.idActividad)
                {
                    nombre = actividadActual.nombre.ToString();
                    persona.actividad = nombre;
                }
            }
            RepositorioPersonas.AgregarPersona(persona);
        }

        public static void InstanciarValoresPredeterminados()
        {


            //Declaracion de actividades
            Actividad actividad1 = new Actividad
            {
                idActividad = 1,
                nombre = "Medico"

            };
            Actividad actividad2 = new Actividad
            {
                idActividad = 2,
                nombre = "Electricista"
            };

            Actividad actividad3 = new Actividad
            {
                idActividad = 3,
                nombre = "Plomero"
            };


            RepositorioActividades.AgregarActividad(actividad1);
            RepositorioActividades.AgregarActividad(actividad2);
            RepositorioActividades.AgregarActividad(actividad3);

            //Declaracion de personas

            Persona persona1 = new Persona
            {
                nombreApellido = "Nicolas Priotti",
                dni = 40505080,
                domicilio = "Los andes",
                email = "nico@gmail.com",
                telefono = "3562-445234",
                actividad = actividad1.nombre
            };

            Persona persona2 = new Persona
            {
                nombreApellido = "Franco",
                dni = 44234234,
                domicilio = "25 de mayo",
                email = "franco@gmail.com",
                telefono = "3562-423444",
                actividad = actividad2.nombre
            };

            Persona persona3 = new Persona
            {
                nombreApellido = "Juan",
                dni = 40987297,
                domicilio = "9 de julio",
                email = "juan@gmail.com",
                telefono = "3562-9876544",
                actividad = actividad3.nombre
            };
            RepositorioPersonas.AgregarPersona(persona1);
            RepositorioPersonas.AgregarPersona(persona2);
            RepositorioPersonas.AgregarPersona(persona3);


        }







    }
       
    
}
