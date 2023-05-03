using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using Microsoft.Win32;
using System;
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

        public override string ApresentarMenu()
        {
            Console.Clear();

            MostrarCabecalho($"Bar do Jão - Conta ");

            Console.WriteLine(" [1] - Abrir conta nova");
            Console.WriteLine(" [2] - Visualizar Contas");
            Console.WriteLine(" [3] - Fechar Conta");
            Console.WriteLine(" [4] - Visualizar Faturamento\n");

            Console.WriteLine(" [5] - para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public string ApresentarMenuVisualizacaoContas()
        {
            Console.Clear();

            MostrarCabecalho($"Bar do Jão - Visualização de Contas ");

            Console.WriteLine(" [1] - Visualizar Contas ");
            Console.WriteLine(" [2] - Visualizar Contas em Aberto ");
            Console.WriteLine(" [3] - Visualizar Contas do Dia \n");

            Console.WriteLine(" [4] - para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            MostrarCabecalho("Bar do Jão - Visualizando Contas: ");

            Console.WriteLine("| {0,-5} | {1, -10} | {2, -15} | {3, -20} | {4, -20} | {5, -10} |", "Id", "Mesa", "Funcionario", "Data", "Status", "Total");
            Console.WriteLine(" -------------------------------------------------------------------------------------------------- ");

            string mensagem;

            foreach (Conta conta in registros)
            {
                mensagem = VerificarDisponibilidade(conta);

                Console.WriteLine("| {0,-5} | {1, -10} | {2, -15} | {3, -20} | {4, -20} | {5, -10} |",
                    conta.id,
                    conta.mesa.numero,
                    conta.funcionario.nome,
                    conta.data.ToShortDateString(),
                    mensagem,
                    $"R${conta.valorTotal}");

                //Console.WriteLine(" -------------------------------------------------------------------------------------------------- ");
                //Console.WriteLine("| {0, -25} |", "Pedido");
                //Console.WriteLine(" --------------------------- ");


                //foreach (Produto produto in conta.pedido)
                //{
                //    Console.WriteLine("| {0, -25} |", produto.nome);
                //    Console.WriteLine(" --------------------------- ");

                //}

                Console.ResetColor();
            }
        }

        private static string VerificarDisponibilidade(Conta conta)
        {
            string mensagem;
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

            return mensagem;
        }

        protected override EntidadeBase ObterRegistro()
        {
            MostrarCabecalho("Bar do Jão - Conta Nova");

            Funcionario funcionario = ObterFuncionario();

            Mesa mesa = ObterMesa();

            ArrayList pedido = ObterPedido();

            DateTime dataAtual = DateTime.Today;

            bool statusConta = true;

            decimal valorTotal = ObterValorTotal(pedido);

            return new Conta(mesa, funcionario, pedido, dataAtual, statusConta, valorTotal);
        }

        private static decimal ObterValorTotal(ArrayList pedido)
        {
            decimal valorTotal = 0;

            foreach (Produto produto in pedido)
            {
                valorTotal += produto.valor;
            }

            return valorTotal;
        }

        private ArrayList ObterPedido()
        {
            ArrayList pedido = new ArrayList();

            do
            {
                Console.Clear();

                telaProduto.VisualizarRegistros(false);

                Console.Write("Id do produto: ");
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

            ConcluirPedido(pedido);

            Console.WriteLine();

            Console.ReadLine();

            return pedido;
        }

        private static void ConcluirPedido(ArrayList pedido)
        {
            Console.WriteLine("\n\nConfirmando Pedido: \n");

            Console.WriteLine("{0, -5} | {1, -25} | {2, -10} |", "Id", "Nome", "Valor");
            Console.WriteLine(" --------------------------------------------------- ");

            foreach (Produto produtos in pedido)
            {
                Console.WriteLine("{0, -5} | {1, -25} | {2, -10} |", produtos.id, produtos.nome, produtos.valor);

            }
        }

        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Console.WriteLine("Id da Mesa: ");
            int idMesa = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Mesa mesa = (Mesa)repositorioMesa.SelecionarPorId(idMesa);

            return mesa;
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistros(false);

            Console.WriteLine();

            Console.WriteLine("Id do Funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionario = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            return funcionario;
        }

        internal void FecharConta()
        {
            MostrarCabecalho("Bar do Jão - Fechamento de conta");

            VisualizarContasEmAberto();

            Console.WriteLine("Digite o Id da conta:");
            int id = Convert.ToInt32(Console.ReadLine());

            Conta conta = (Conta)repositorioBase.SelecionarPorId(id);

            conta.contaAberta = false;

            MostrarMensagem("Conta fechada com sucesso!", ConsoleColor.Green);
        }

        internal void VisualizarFaturamento()
        {
            MostrarCabecalho("Bar do Jão - Faturamento do dia");

            VisualizarRegistros(false);

            ArrayList contas = repositorioBase.SelecionarTodos();

            decimal faturamentoDiario = 0;

            foreach (Conta conta in contas)
            {
                if (conta.data == DateTime.Today)
                {
                    faturamentoDiario += conta.valorTotal;
                }
                else
                {
                    continue;
                }
            }
            MostrarMensagem($"O faturamento total de hoje foi de R${faturamentoDiario}", ConsoleColor.Cyan);
        }

        internal void VisualizarContasEmAberto()
        {
            MostrarCabecalho("Bar do Jão - Visualizando Contas em Aberto: ");

            ArrayList registros = repositorioBase.SelecionarTodos();

            Console.WriteLine("| {0,-5} | {1, -10} | {2, -15} | {3, -20} |  {4, -10} |", "Id", "Mesa", "Funcionario", "Data", "Total");
            Console.WriteLine(" -------------------------------------------------------------------------------------------------- ");

            foreach (Conta conta in registros)
            {
                if (conta.contaAberta == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("| {0,-5} | {1, -10} | {2, -15} | {3, -20} | {4, -10} |",
                     conta.id,
                     conta.mesa.numero,
                     conta.funcionario.nome,
                     conta.data.ToShortDateString(),
                     $"R${conta.valorTotal}");

                    //Console.WriteLine(" -------------------------------------------------------------------------------------------------- ");
                    //Console.WriteLine("| {0, -25} |", "Pedido");
                    //Console.WriteLine(" --------------------------- ");


                    //foreach (Produto produto in conta.pedido)
                    //{
                    //    Console.WriteLine("| {0, -25} |", produto.nome);
                    //    Console.WriteLine(" --------------------------- ");

                    //}
                }
                else
                {
                    continue;
                }
                Console.ResetColor();
            }
        }

        internal void VisualizarContasDia()
        {
            MostrarCabecalho("Bar do Jão - Visualizando Contas do Dia: ");

            ArrayList registros = repositorioBase.SelecionarTodos();

            Console.WriteLine("| {0,-5} | {1, -10} | {2, -15} | {3, -20} |  {4, -10} | {5, -10} |", "Id", "Mesa", "Funcionario", "Data", "Total", "Status");
            Console.WriteLine(" -------------------------------------------------------------------------------------------------- ");

            foreach (Conta conta in registros)
            {
                string mensagem = VerificarDisponibilidade(conta);

                if (conta.data == DateTime.Today)
                {
                    Console.WriteLine("| {0,-5} | {1, -10} | {2, -15} | {3, -20} | {4, -10} | {5, -10} |",
                     conta.id,
                     conta.mesa.numero,
                     conta.funcionario.nome,
                     conta.data.ToShortDateString(),
                     $"R${conta.valorTotal}",
                     mensagem);

                    //Console.WriteLine(" -------------------------------------------------------------------------------------------------- ");
                    //Console.WriteLine("| {0, -25} |", "Pedido");
                    //Console.WriteLine(" --------------------------- ");


                    //foreach (Produto produto in conta.pedido)
                    //{
                    //    Console.WriteLine("| {0, -25} |", produto.nome);
                    //    Console.WriteLine(" --------------------------- ");

                    //}
                }
                else
                {
                    continue;
                }
                Console.ResetColor();
            }
        }
    }
}
