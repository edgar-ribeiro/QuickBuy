using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; } //Relacionamento se da pelo 'Usuario'ID ser igaul ao Usuario abaixo
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }

        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        //Deve ter ao menos 1 item
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();

            if(!ItensPedido.Any())
            {
                AdicionarCritica("Crítica - Pedido não pode ficar sem item de Pedido");
            }
            if(string.IsNullOrEmpty(CEP))
            {
                AdicionarCritica("Crítica - CEP deve estar preenchido");
            }
            if (FormaPagamentoId == 0)
            {
                AdicionarCritica("Crítica - Forma de pagamento não foi informada");
            }
        }
    }
}
