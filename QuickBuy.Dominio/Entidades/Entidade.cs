using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }
        private List<string> mensagemValidacao
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
            //?? verifica se a variavel está vazia, se sim, faz oq pede na sequencia, nesse caso uma instancia vazia
        }

        protected void LimparMensagemValidacao()
        {
            mensagemValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);
        }

        public abstract void Validate(); //usando abstract forca as filhas a usarem
        protected bool EhValido
        {
            get { return !mensagemValidacao.Any(); }//Exclamacao é para negar, ou seja, senao...
        }
    }
}
