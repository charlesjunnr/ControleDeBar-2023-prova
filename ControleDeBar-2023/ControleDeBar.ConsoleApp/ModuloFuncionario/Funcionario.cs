using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string nome;
        public string telefone;
        public string endereco;
        public string turno;

        public Funcionario(string nome, string telefone, string endereco, string turno)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
            this.turno = turno;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Funcionario FuncionarioAtualizado = (Funcionario)registroAtualizado;
            
            nome = FuncionarioAtualizado.nome;
            telefone = FuncionarioAtualizado.telefone;
            endereco = FuncionarioAtualizado.endereco;
            turno = FuncionarioAtualizado.turno;

        }
    }
}
