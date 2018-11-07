using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaPDV2018.Model
{
   public class cliente
    {
        public long id_cliente { get; set; }
        public string Nome_cliente { get; set; }
        public string Logradouro_cliente { get; set; }
        public int Numero_cliente { get; set; }
        public string Bairro_cliente { get; set; }
        public string Cep_cliente { get; set; }
        public string Cidade_cliente { get; set; }
        public string Estado_cliente { get; set; }
        public string Cpf_cliente { get; set; }
        public int Ddd_cliente { get; set; }
        public string Contato_cliente { get; set; }
        public string Email_cliente { get; set; }
    }
}
