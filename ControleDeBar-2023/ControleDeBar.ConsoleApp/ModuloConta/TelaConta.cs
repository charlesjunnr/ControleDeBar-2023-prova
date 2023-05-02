using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using Microsoft.Win32;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    internal class TelaConta : TelaBase
    {
        private RepositorioFuncionario repositorioFuncionario;
        private RepositorioMesa repositorioMesa;
        private RepositorioProduto repositorioProduto;

        private TelaFuncionario telaFuncionario;
        private TelaMesa telaMesa;
        private TelaProduto telaProduto;

        bool ehContinuar = true;

        public TelaConta(RepositorioConta repositorioConta, 
            RepositorioFuncionario repositorioFuncionario, 
            RepositorioMesa repositorioMesa, 
            RepositorioProduto repositorioProduto, TelaFuncionario telaFuncionario, TelaMesa telaMesa, TelaProduto telaProduto)
        {
            repositorioBase = repositorioConta;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioProduto = repositorioProduto;
            this.repositorioMesa = repositorioMesa;
            this.telaFuncionario = telaFuncionario;
            this.telaMesa = telaMesa;
            this.telaProduto = telaProduto;

            nomeEntidade = "Conta";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            MostrarCabecalho("Bar do Jão", "Visualizando Contas: ");
            
            Console.WriteLine("{0,-5} | {1, -10} | {2, -15} | {3, -20} | {4, -20} | {5, -10} |", "Id", "Mesa", "Funcionario", "Data", "Status");

            string mensagem;

            foreach (Conta conta in registros)
            {
                if (conta.contaAberta == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    mensagem = "Conta aberta";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    mensagem = "Conta fechada";
                }
                
                Console.WriteLine("{0,-5} | {1, -10} | {2, -15} | {3, -20} | {4, -20} | {5, -10} |",
                    conta.id,
                    conta.mesa.numero,
                    conta.funcionario.nome,
                    conta.data.ToShortDateString(), mensagem);
                
                Console.Write("Pedido");

                foreach (ArrayList item in conta.pedido)
                {
                    Console.WriteLine(conta.pedido);
                }

                Console.ResetColor();
            }
            
        }

        protected override EntidadeBase ObterRegistro()
        {
            MostrarCabecalho("Bar do Jão", "Conta Nova");

            Funcionario funcionario = ObterFuncionario();

            Mesa mesa = ObterMesa();

            ArrayList pedido = ObterPedido();

            DateTime dataAtual = DateTime.Now;

            bool statusConta = true;

            return new Conta(mesa, funcionario, pedido, dataAtual, statusConta);
        }

        private ArrayList ObterPedido()
        {
            ArrayList pedido = new ArrayList();

            telaProduto.VisualizarRegistros(false);

            do{

                Console.Write("Digite o Id do produto para fazer o pedido: ");
                int idProduto = Convert.ToInt32(Console.ReadLine());

                Produto produto = (Produto)repositorioProduto.SelecionarPorId(idProduto);

                pedido.Add(produto);
                
                Console.WriteLine();

                Console.WriteLine("Deseja adicionar mais itens? \n1 - sim \n2 - não");

                string opcao = Console.ReadLine();

                if (opcao == "2")
                {
                    ehContinuar = false;

                }
                else if (opcao == "1")
                {
                    ehContinuar = true;
                }

            } while (ehContinuar == true);

            Console.WriteLine("Confirmando Pedido: ");

            Console.WriteLine("{0, -5} | {1, -10} | {2, -10} ", "Id", "Nome", "Valor");
            Console.WriteLine(" ---------------------------------------- ");

            foreach (Produto produtos in pedido)
            {
                Console.WriteLine("{0, -5} | {1, -10} | {2, -10} ", produtos.id, produtos.nome, produtos.valor);

            }
            Console.ReadLine();

            return pedido;
        }

        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Console.WriteLine("Digite o Id da Mesa: ");
            int idMesa = Convert.ToInt32(Console.ReadLine());

            Mesa mesa = (Mesa)repositorioMesa.SelecionarPorId(idMesa);
            return mesa;
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            Console.WriteLine("Digite o Id do Funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            
            return funcionario;
        }

        internal void FecharConta()
        {
            throw new NotImplementedException();
        }
    }
}
