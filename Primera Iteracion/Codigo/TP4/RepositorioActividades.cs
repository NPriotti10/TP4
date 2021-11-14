using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class RepositorioActividades
    {
        public static List<Actividad> listaActividades = new List<Actividad>();

        public static void AgregarActividad(Actividad actividad)
        {
            listaActividades.Add(actividad);
        }
    }
}
