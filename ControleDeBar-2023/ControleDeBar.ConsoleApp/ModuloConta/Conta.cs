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

        public Conta(Mesa mesa, Funcionario funcionario, ArrayList pedido, DateTime data, bool contaAberta)
        {
            this.mesa = mesa;
            this.funcionario = funcionario;
            this.pedido = pedido;
            this.data = data;
            this.contaAberta = contaAberta;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizada = (Conta) registroAtualizado;

            this.mesa = contaAtualizada.mesa;
            this.funcionario = contaAtualizada.funcionario;
            this.pedido = contaAtualizada.pedido;
            this.data = contaAtualizada.data;
            this.contaAberta = contaAtualizada.contaAberta;

        }
    }
}
