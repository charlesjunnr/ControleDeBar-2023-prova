using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    internal class RepositorioMesa : RepositorioBase
    {
        public RepositorioMesa(ArrayList listaMesa)
        {
            listaRegistros = listaMesa;
        }

        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Mesa)base.SelecionarPorId(id);
        }
    }
}
