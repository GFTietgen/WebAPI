using System;

namespace Application.API.ViewModel
{
    public class UsuarioViewModel
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string DATA_CADASTRO { get; set; }
        public string CPF_CNPJ { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public char TIPO { get; set; }
        public string TELEFONE { get; set; }
        public string EMAIL { get; set; }
        public string CEP { get; set; }
        public string LOGRADOURO { get; set; }
        public string NUMERO { get; set; }
        public string BAIRRO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string CIDADE { get; set; }
        public string UF { get; set; }
    }
}
