using System;
using System.Collections.Generic;
using System.Text;

namespace TP4
{
    class RepositorioEmpresas
    {
        public static List<Empresa> listaEmpresas = new List<Empresa>();

        public static void AgregarEmpresa(Empresa empresa)
        {
            listaEmpresas.Add(empresa);
        }

    }
}
