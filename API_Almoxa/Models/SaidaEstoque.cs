using System;
using System.Collections.Generic;

namespace API_Almoxa.Models
{
    public partial class SaidaEstoque
    {
        public int IdSaida { get; set; }
        public int? IdProduto { get; set; }
        public int? QuantidadeSaida { get; set; }
        public DateTime? DataSaida { get; set; }

        public virtual Produto? IdProdutoNavigation { get; set; }
    }
}
