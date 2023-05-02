using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    internal class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList listaConta)
        {
            listaRegistros = listaConta;
        }

        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Conta)base.SelecionarPorId(id);
        }
    }
}
