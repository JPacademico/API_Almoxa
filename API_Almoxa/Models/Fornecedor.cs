using System;
using System.Collections.Generic;

namespace API_Almoxa.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            EntradaEstoques = new HashSet<EntradaEstoque>();
            Produtos = new HashSet<Produto>();
        }

        public int IdFornecedor { get; set; }
        public string? NomeFornecedor { get; set; }
        public string? ContatoFornecedor { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual ICollection<EntradaEstoque> EntradaEstoques { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
