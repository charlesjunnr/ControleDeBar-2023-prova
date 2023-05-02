using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public string nome;
        public decimal valor;

        public Produto(string nome, decimal valor)
        {
            this.nome = nome;
            this.valor = valor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;
            
            nome = produtoAtualizado.nome;
            valor = produtoAtualizado.valor;
        }

        //public override ArrayList Validar()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
