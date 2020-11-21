using System;

namespace Application.Models.Concretas
{
    public class Usuario : EntidadeDominio
    {
        #region .:Construtores:.
        /// <summary>
        /// Construtor genérico para classe
        /// </summary>
        public Usuario() { }

        /// <summary>
        /// Construtor para alteração de dados cadastrais
        /// </summary>
        public Usuario(int _id, 
                       string _nome, 
                       DateTime _cadastro, 
                       string _cpf_cnpj, 
                       DateTime _nascimento, 
                       char _tipo, 
                       string _telefone, 
                       string _email, 
                       string _cep, 
                       string _logradouro, 
                       string _numero, 
                       string _bairro,
                       string _complemento, 
                       string _cidade, 
                       string _uf)
        {
            ID              = _id;
            NOME            = _nome;
            DATA_CADASTRO   = _cadastro;
            CPF_CNPJ        = _cpf_cnpj;
            DATA_NASCIMENTO = _nascimento;
            TIPO            = _tipo;
            TELEFONE        = _telefone;
            EMAIL           = _email;
            CEP             = _cep;
            LOGRADOURO      = _logradouro;
            NUMERO          = _numero;
            BAIRRO          = _bairro;
            COMPLEMENTO     = _complemento;
            CIDADE          = _cidade;
            UF              = _uf;
        }

        /// <summary>
        /// Construtor para apresentação de dados cadastrados
        /// </summary>
        public Usuario(string _nome,
                       DateTime _cadastro,
                       string _cpf_cnpj,
                       DateTime _nascimento,
                       char _tipo,
                       string _telefone,
                       string _email,
                       string _cep,
                       string _logradouro,
                       string _numero,
                       string _bairro,
                       string _complemento,
                       string _cidade,
                       string _uf)
        {
            NOME            = _nome;
            DATA_CADASTRO   = _cadastro;
            CPF_CNPJ        = _cpf_cnpj;
            DATA_NASCIMENTO = _nascimento;
            TIPO            = _tipo;
            TELEFONE        = _telefone;
            EMAIL           = _email;
            CEP             = _cep;
            LOGRADOURO      = _logradouro;
            NUMERO          = _numero;
            BAIRRO          = _bairro;
            COMPLEMENTO     = _complemento;
            CIDADE          = _cidade;
            UF              = _uf;
        }
        #endregion

        #region .:PROPRIEDADES:.
        public string   NOME            { get; private set; }
        public DateTime DATA_CADASTRO   { get; private set; }
        public string   CPF_CNPJ        { get; private set; }
        public DateTime DATA_NASCIMENTO { get; private set; }
        public char     TIPO            { get; private set; }
        public string   TELEFONE        { get; private set; }
        public string   EMAIL           { get; private set; }
        public string   CEP             { get; private set; }
        public string   LOGRADOURO      { get; private set; }
        public string   NUMERO          { get; private set; }
        public string   BAIRRO          { get; private set; }
        public string   COMPLEMENTO     { get; private set; }
        public string   CIDADE          { get; private set; }
        public string   UF              { get; private set; }
        #endregion
    }
}
