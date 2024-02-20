using System;
using System.Collections.Generic;

namespace API_Almoxa.Models
{
    public partial class Produto
    {
        public Produto()
        {
            EntradaEstoques = new HashSet<EntradaEstoque>();
            Lotes = new HashSet<Lote>();
            SaidaEstoques = new HashSet<SaidaEstoque>();
        }

        public int IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public int? IdFornecedor { get; set; }

        public virtual Fornecedor? IdFornecedorNavigation { get; set; }
        public virtual ICollection<EntradaEstoque> EntradaEstoques { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
        public virtual ICollection<SaidaEstoque> SaidaEstoques { get; set; }
    }
}
