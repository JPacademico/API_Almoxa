using System;
using System.Collections.Generic;

namespace API_Almoxa.Models
{
    public partial class EntradaEstoque
    {
        public int IdEntrada { get; set; }
        public int? IdProduto { get; set; }
        public int? IdFornecedor { get; set; }
        public int? QuantidadeEntrada { get; set; }
        public DateTime? DataEntrada { get; set; }

        public virtual Fornecedor? IdFornecedorNavigation { get; set; }
        public virtual Produto? IdProdutoNavigation { get; set; }
    }
}
