using System;
using System.Collections.Generic;

namespace API_Almoxa.Models
{
    public partial class Lote
    {
        public int IdLote { get; set; }
        public DateTime? DataValidade { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? Quantidade { get; set; }
        public int? IdProduto { get; set; }

        public virtual Produto? IdProdutoNavigation { get; set; }
    }
}
