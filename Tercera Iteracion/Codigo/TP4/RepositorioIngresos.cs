using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class RepositorioIngresos
    {
        public static List<Ingreso> listaIngresoPositivo = new List<Ingreso>();
        public static List<Ingreso> listaIngresoNegativo = new List<Ingreso>();

        public static void RegistrarIngresoPositivo(Ingreso ingreso)
        {
            listaIngresoPositivo.Add(ingreso);
        }
        public static void RegistrarIngresoNegativo(Ingreso ingreso)
        {
            listaIngresoNegativo.Add(ingreso);
        }
    }
}
