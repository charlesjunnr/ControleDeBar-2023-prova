using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);

            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);

            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);

            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());
            TelaConta telaConta = new TelaConta(repositorioConta, repositorioFuncionario, repositorioMesa, repositorioProduto, telaFuncionario, telaMesa, telaProduto);

            GerarRegistros(repositorioProduto, repositorioMesa, repositorioFuncionario);

            while(true)
            {
                string opcao = ApresentarMenuPrincipal();
                if(opcao == "6")
                {
                    break;
                }else if(opcao == "1")
                {
                    string opcaoMenu = telaProduto.ApresentarMenu();
                    if(opcaoMenu == "5")
                    {
                        break;
                    }
                    else if(opcaoMenu == "1")
                    {
                        telaProduto.InserirNovoRegistro();
                    }
                    else if (opcaoMenu == "2")
                    {
                        telaProduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if(opcaoMenu == "3")
                    {
                        telaProduto.EditarRegistro();
                    }
                    else if(opcaoMenu == "4")
                    {
                        telaProduto.ExcluirRegistro();
                    }
                }else if(opcao == "2")
                {
                    string opcaoMenu2 = telaFuncionario.ApresentarMenu();
                    if (opcaoMenu2 == "5")
                    {
                        break;
                    }
                    else if (opcaoMenu2 == "1")
                    {
                        telaFuncionario.InserirNovoRegistro();
                    }
                    else if (opcaoMenu2 == "2")
                    {
                        telaFuncionario.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (opcaoMenu2 == "3")
                    {
                        telaFuncionario.EditarRegistro();
                    }
                    else if (opcaoMenu2 == "4")
                    {
                        telaFuncionario.ExcluirRegistro();
                    }
                }
                else if(opcao == "3")
                {
                    string opcaoMenu3 = telaMesa.ApresentarMenu();
                    if (opcaoMenu3 == "5")
                    {
                        break;
                    }
                    else if (opcaoMenu3 == "1")
                    {
                        telaMesa.InserirNovoRegistro();
                    }
                    else if (opcaoMenu3 == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (opcaoMenu3 == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (opcaoMenu3 == "4")
                    {
                        telaMesa.ExcluirRegistro();
                    }

                }else if (opcao=="4")
                {
                    string opcaoMenu4 = telaConta.ApresentarMenu();
                    if (opcaoMenu4 == "5")
                    {
                        break;
                    }
                    else if (opcaoMenu4 == "1")
                    {
                        telaConta.InserirNovoRegistro();
                    }
                    else if (opcaoMenu4 == "2")
                    {
                        telaConta.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (opcaoMenu4 == "3")
                    {
                        telaConta.EditarRegistro();
                    }
                    else if (opcaoMenu4 == "4")
                    {
                        telaConta.FecharConta();
                    }
                }
            }
        }
        public static string ApresentarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine(" ------ Bar do Jão ------");
            Console.WriteLine(" [1] - Produtos");
            Console.WriteLine(" [2] - Funcionários");
            Console.WriteLine(" [3] - Mesas");
            Console.WriteLine(" [4] - Contas");
            Console.WriteLine(" [5] - Faturamento\n");

            Console.WriteLine(" [6] - Sair");

            string opcao = Console.ReadLine();
            return opcao;
        }

        private static void GerarRegistros(RepositorioProduto repositorioProduto,
        RepositorioMesa repositorioMesa, RepositorioFuncionario repositorioFuncionario)
        {
            Produto produto1 = new Produto("Coca-cola lata", 6);
            Produto produto2 = new Produto("Batata-frita porção", 12);
            Produto produto3 = new Produto("Cachorro-quente", 15);

            repositorioProduto.Inserir(produto1);
            repositorioProduto.Inserir(produto2);
            repositorioProduto.Inserir(produto3);

            Mesa mesa1 = new Mesa(22, "Interior", 4, true);
            Mesa mesa2 = new Mesa(2, "Balcão", 1, false);
            Mesa mesa3 = new Mesa(4, "Exterior", 3, false);

            repositorioMesa.Inserir(mesa1);
            repositorioMesa.Inserir(mesa2);
            repositorioMesa.Inserir(mesa3);

            Funcionario funcionario1 = new Funcionario("Jão", "(49) 9922-2337", "Rua das Hortaliças", "Manhã");
            Funcionario funcionario2 = new Funcionario("Fernanda", "(49) 9122-4447", "Rua das Flores", "Tarde");
            Funcionario funcionario3 = new Funcionario("Kaio", "(49) 9911-4437", "Rua das Frutas", "Noite");

            repositorioFuncionario.Inserir(funcionario1);
            repositorioFuncionario.Inserir(funcionario2);
            repositorioFuncionario.Inserir(funcionario3);
        }
    }
}