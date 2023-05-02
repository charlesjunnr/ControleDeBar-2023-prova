using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public RepositorioFuncionario(ArrayList listaFuncionario)
        {
            listaRegistros = listaFuncionario;
        }

        public override EntidadeBase SelecionarPorId(int id)
        {
            return (Funcionario)base.SelecionarPorId(id);
        }
    }
}
