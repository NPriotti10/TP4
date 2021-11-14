using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class RepositorioPersonas
    {
        public static List<Persona> listaPersonas = new List<Persona>();

        public static void AgregarPersona(Persona persona)
        {
            listaPersonas.Add(persona);
        }
    }
}
