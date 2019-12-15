using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class cls_Pessoa
    {
        public int acao { get; set; }
        public int codigo { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public int cep { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public DateTime datanascimento { get; set; }
        public string estadocivil { get; set; }
        public int filhos { get; set; }
        public string conjugue { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
        public string genero { get; set; }
        public string naturalidade { get; set; }
        public string nacionalidade { get; set; }
        public bool antecedentes { get; set; }
        public DateTime datacadastro { get; set; }
        public string observ { get; set; }

    }
}
