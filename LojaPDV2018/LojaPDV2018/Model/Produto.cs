using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaPDV2018Cliente.Model
{
   public class Produto
    {
        public long id_produto { get; set; }
        public string Codigo_produto { get; set; }
        public string Ean_produto { get; set; }
        public string Nome_produto { get; set; }
        public string Descricao_produto{ get; set; }
        public int Valor_produto { get; set; }
        public string Categoria_produto { get; set; }

   }
}
