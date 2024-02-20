using System;
using System.Collections.Generic;

namespace API_Almoxa.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Fornecedors = new HashSet<Fornecedor>();
        }

        public int IdCategoria { get; set; }
        public string? NomeCategoria { get; set; }

        public virtual ICollection<Fornecedor> Fornecedors { get; set; }
    }
}
