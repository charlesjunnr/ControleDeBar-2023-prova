using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloFuncionario;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;


using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Mesa mesa;
        public Funcionario funcionario;
        public ArrayList pedido;
        public DateTime data;
        public bool contaAberta;
        public decimal valorTotal;

        public Conta(Mesa mesa, Funcionario funcionario, ArrayList pedido, DateTime data, bool contaAberta, decimal valorTotal)
        {
            this.mesa = mesa;
            this.funcionario = funcionario;
            this.pedido = pedido;
            this.data = data;
            this.contaAberta = contaAberta;
            this.valorTotal = valorTotal;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizada = (Conta) registroAtualizado;

            this.mesa = contaAtualizada.mesa;
            this.funcionario = contaAtualizada.funcionario;
            this.pedido = contaAtualizada.pedido;
            this.data = contaAtualizada.data;
            this.contaAberta = contaAtualizada.contaAberta;
            this.valorTotal = contaAtualizada.valorTotal;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (contaAberta == false)
            {
                erros.Add("Essa conta já está fechou!");
            }
            if (mesa.estaDisponivel == false)
            {
                erros.Add("Mesa indisponível!");
            }
            return erros;
        }
    }
}
