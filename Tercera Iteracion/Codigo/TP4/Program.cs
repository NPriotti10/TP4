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
                Console.WriteLine("1)-Verificar Autorizacion. \n");
                Console.WriteLine("2)-Registrar Empleado. \n");
                Console.WriteLine("3)-Registrar Empresa. \n");
                Console.WriteLine("4)-Registrar Ingreso de un empleado. \n");
                Console.WriteLine("5)-Registrar Egreso de un empleado. \n");
                Console.WriteLine("6)-Dar de baja empleado. \n");
                Console.WriteLine("7)-Mostrar registro de ingresos. \n");
                Console.WriteLine("Ingrese 0 si desea salir del programa\n");
                Console.WriteLine("-----------------------------------------------------------\n");

                num = int.Parse(Console.ReadLine());

                while (num < 0 || num > 7)
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
                if(num == 3)
                {
                    RegistrarEmpresa();
                }
                if(num == 4)
                {
                    RegistrarIngreso();
                }
                if(num == 5)
                {
                    RegistrarEgreso();
                }
                if (num == 6)
                {
                    DarBajaEmpleado();
                }
                if(num == 7)
                {
                    Console.WriteLine("LISTA DE INGRESOS: \n");
                    foreach(var ingresoActual in RepositorioIngresos.listaIngresoPositivo)
                    {
                        ingresoActual.MostrarIngreso();
                    }
                    Console.WriteLine("LISTA DE PERSONAS QUE NO PUDIERON INGRESAR");
                    foreach (var ingresoActual in RepositorioIngresos.listaIngresoNegativo)
                    {
                        ingresoActual.MostrarIngreso();
                    }
                }
            } while (num != 0);
        }
        
        public static void RegistrarEgreso()
        {
            Console.WriteLine("Ingrese el DNI de la persona que sale: \n");
            int dniPersonaSale = int.Parse(Console.ReadLine());
            foreach(var ingresoActual in RepositorioIngresos.listaIngresoPositivo)
            {
                if(dniPersonaSale == ingresoActual.persona.dni)
                {
                    Console.Write("Registro de Salida realizado con exito \n");
                    ingresoActual.fechaEgreso = DateTime.Now;
                }
            }


        }
        public static void RegistrarIngreso()
        {
            int dniPersonaIngresa, opcion;
            Console.WriteLine("Ingrese el DNI de la persona que desea ingresar: \n");
            Console.WriteLine("Ingrese 1 si debe registrar una nueva persona: \n");
            dniPersonaIngresa = int.Parse(Console.ReadLine());
            Ingreso ingresoPersona = new Ingreso();

            foreach (var personaActual in RepositorioPersonas.listaPersonas)
            {
                if(dniPersonaIngresa == personaActual.dni)
                {
                    ingresoPersona.persona = personaActual;
                }
            }

            if (dniPersonaIngresa == 1)
            {
                RegistrarPersona();
            }

            ingresoPersona.fechaIngreso = DateTime.Now;
            Console.WriteLine("Ingrese la temperatura corporal de la persona: \n");
            ingresoPersona.temperatura = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese 1 si ingresa con un vehiculo: \n");
            opcion = int.Parse(Console.ReadLine());
            if(opcion == 1)
            {
                Console.WriteLine("Ingrese la patente del vehiculo: \n");
                ingresoPersona.patenteVehiculo= Console.ReadLine();
            }
            else
            {
                ingresoPersona.patenteVehiculo = "Ingreso sin vehiculo";
            }
            Console.WriteLine("Ingrese el destino al que se dirige: \n");
            ingresoPersona.destino = Console.ReadLine();
            
            if(ingresoPersona.temperatura > 37)
            {
                Console.WriteLine("La persona no puede ingresar debido a tener temperatura superior a 37 grados");
                ingresoPersona.estadoIngreso = false;
                RepositorioIngresos.RegistrarIngresoNegativo(ingresoPersona);
            }
            else
            {
                Console.WriteLine("Registro de ingreso con exito");
                ingresoPersona.estadoIngreso = true;
                RepositorioIngresos.RegistrarIngresoPositivo(ingresoPersona);
            }
            
            

           
        }
        public static void DarBajaEmpleado()
        {
            Console.WriteLine("Ingrese el DNI del empleado: ");
            Persona eliminarPersona = new Persona();
            int dniEmpleadoBaja = int.Parse(Console.ReadLine());
            foreach (Persona empleadoActual in RepositorioPersonas.listaPersonas)
            {
                if(dniEmpleadoBaja == empleadoActual.Dni)
                {
                    eliminarPersona = empleadoActual;
                    Console.WriteLine("Empleado eliminado correctamente");
                }
            }
            RepositorioPersonas.EliminarPersona(eliminarPersona);

        }
        public static void RegistrarEmpresa()
        {
            Empresa empresa = new Empresa();
            Console.WriteLine("Ingrese el nombre de la empresa. \n");
            empresa.nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la razon social de la empresa. \n");
            empresa.razonSocial = Console.ReadLine();
            Console.WriteLine("Ingrese cuit. \n");
            empresa.cuit = Console.ReadLine();
            Console.WriteLine("Ingrese el domicilio. \n");
            empresa.domicilio = Console.ReadLine();
            Console.WriteLine("Ingrese la localidad. \n");
            empresa.localidad = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono. \n");
            empresa.telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el email. \n");
            empresa.email = Console.ReadLine();
            

            Console.WriteLine("Seleccione una actividad\n");
            int i = 1;
            foreach (var actividadActual in RepositorioActividades.listaActividades)
            {
                Console.WriteLine("Áctividad" + i + ": " + actividadActual.nombre);
                i++;
            }
            int opcion = int.Parse(Console.ReadLine());
            string nombre;
            foreach (var actividadActual in RepositorioActividades.listaActividades)
            {
                if (opcion == actividadActual.idActividad)
                {
                    nombre = actividadActual.nombre.ToString();
                    empresa.actividad = nombre;
                }
            }
            RepositorioEmpresas.AgregarEmpresa(empresa);
            Console.WriteLine("Empresa registrada con exito");
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
                Console.WriteLine("Actividad" + i + ": " + actividadActual.nombre);
                i++;
            }
            int opcion = int.Parse(Console.ReadLine());
            string nombreActividad;
            foreach(var actividadActual in RepositorioActividades.listaActividades)
            {
                if(opcion == actividadActual.idActividad)
                {
                    nombreActividad = actividadActual.nombre.ToString();
                    persona.actividad = nombreActividad;
                }
            }
            
            int j = 1;
            Console.WriteLine("Seleccione la empresa en la que trabaja");
            foreach(var empresaActual in RepositorioEmpresas.listaEmpresas)
            {
                Console.WriteLine("Empresa" + j + ": " + empresaActual.nombre);
                j++;
            }
            int opcion2 = int.Parse(Console.ReadLine());
            string nombreEmpresa;
            foreach(var empresaActual in RepositorioEmpresas.listaEmpresas)
            {
                if(opcion2 == empresaActual.idEmpresa)
                {
                    nombreEmpresa = empresaActual.nombre.ToString();
                    persona.empresa = nombreEmpresa;
                }
            }

            persona.fechaDesde = DateTime.Now;
            persona.fechaHasta = DateTime.Now.AddDays(15);

            RepositorioPersonas.AgregarPersona(persona);
            Console.WriteLine("Persona registrada con exito");
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
            
            // Declaracion de Empresas

            Empresa empresa1 = new Empresa
            {
                idEmpresa = 1,
                nombre = "Piamontesa",
                razonSocial = "SRL",
                cuit = "40-234234234-3",
                domicilio = "rivadavia 444",
                localidad = "san francisco",
                email = "empresa1@gmail.com",
                telefono = "3564-564323",
                actividad = actividad1.nombre

            };
            Empresa empresa2 = new Empresa
            {
                idEmpresa = 2,
                nombre = "Manfrey",
                razonSocial = "SRL",
                cuit = "40-987654356-3",
                domicilio = "santa fe 444",
                localidad = "san francisco",
                email = "empresa2@gmail.com",
                telefono = "3564-543345",
                actividad = actividad2.nombre

            };
            Empresa empresa3 = new Empresa
            {
                idEmpresa = 3,
                nombre = "Arla",
                razonSocial = "SA",
                cuit = "40-998667343-3",
                domicilio = "caseros 220",
                localidad = "cordoba",
                email = "empresa3@gmail.com",
                telefono = "3541-654332",
                actividad = actividad3.nombre

            };

            RepositorioEmpresas.AgregarEmpresa(empresa1);
            RepositorioEmpresas.AgregarEmpresa(empresa2);
            RepositorioEmpresas.AgregarEmpresa(empresa3);

            //Declaracion de personas

            Persona persona1 = new Persona
            {
                nombreApellido = "Nicolas Priotti",
                dni = 40505080,
                domicilio = "Los andes",
                email = "nico@gmail.com",
                telefono = "3562-445234",
                actividad = actividad1.nombre,
                empresa = empresa1.nombre,
                fechaDesde = DateTime.Now,
                fechaHasta = DateTime.Now.AddDays(10)
            };

            Persona persona2 = new Persona
            {
                nombreApellido = "Franco",
                dni = 44234234,
                domicilio = "25 de mayo",
                email = "franco@gmail.com",
                telefono = "3562-423444",
                actividad = actividad2.nombre,
                empresa = empresa2.nombre,
                fechaDesde = DateTime.Now,
                fechaHasta = DateTime.Now.AddDays(10)
            };

            Persona persona3 = new Persona
            {
                nombreApellido = "Juan",
                dni = 40987297,
                domicilio = "9 de julio",
                email = "juan@gmail.com",
                telefono = "3562-9876544",
                actividad = actividad3.nombre,
                empresa = empresa3.nombre,
                fechaDesde = DateTime.Now,
                fechaHasta = DateTime.Now.AddDays(10)
            };
            RepositorioPersonas.AgregarPersona(persona1);
            RepositorioPersonas.AgregarPersona(persona2);
            RepositorioPersonas.AgregarPersona(persona3);
        }







    }


}
