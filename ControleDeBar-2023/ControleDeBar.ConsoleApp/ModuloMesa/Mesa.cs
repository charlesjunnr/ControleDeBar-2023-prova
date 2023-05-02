using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public int numero;
        public string localizacao;
        public int quantidadeLugares;
        public bool estaDisponivel;

        //implementar disponibilidade com uma booleana

        public Mesa(int numero, string localizacao, int quantidadeLugares, bool estaDisponivel)
        {
            this.numero = numero;
            this.localizacao = localizacao;
            this.quantidadeLugares = quantidadeLugares;
            this.estaDisponivel = estaDisponivel;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            numero = mesaAtualizada.numero;
            localizacao = mesaAtualizada.localizacao;
            quantidadeLugares = mesaAtualizada.quantidadeLugares;
            estaDisponivel = mesaAtualizada.estaDisponivel;
        }
    }
}
