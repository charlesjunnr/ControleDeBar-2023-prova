using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : TelaBase
    {
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            repositorioBase = repositorioFuncionario;
            nomeEntidade = "Funcionario";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            MostrarCabecalho("Bar do Jão - Visualizando funcionários: ");

            Console.WriteLine("{0,-5} | {1, -10} | {2, -15} | {3, -15} | {4, -10}", "Id", "Nome", "Telefone", "Endereço", "Turno");
            Console.WriteLine(" ----------------------------------------------------------------- ");
            foreach (Funcionario funcionario in registros)
            {
                Console.WriteLine("{0,-5} | {1, -10} | {2, -15} | {3, -15} | {4, -10}", funcionario.id, funcionario.nome, funcionario.telefone, funcionario.endereco, funcionario.turno);
            }
            
        }

        protected override EntidadeBase ObterRegistro()
        {

            MostrarCabecalho("Bar do Jão - Inserir funcionários");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Console.Write("Turno: ");
            string turno = Console.ReadLine().ToUpper();

            return new Funcionario(nome, telefone, endereco, turno);
        }
    }
}
