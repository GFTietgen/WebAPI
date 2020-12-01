using Application.Models.Concretas;
using System;
using System.Collections.Generic;

namespace Application.Repository
{
    public class UsuarioRepository : AbstractDAL<Usuario>
    {
        public UsuarioRepository() : base() { }

        public override string Create(Usuario data)
        {
            string retorno = string.Empty;
            string sql = "INSERT INTO dbcliente.cliente(NOME, DATA_CADASTRO, CPF_CNPJ, DATA_NASCIMENTO, TIPO, TELEFONE, EMAIL, CEP, LOGRADOURO, NUMERO, BAIRRO, COMPLEMENTO, CIDADE, UF)";
                   sql += $"VALUES('{data.NOME}', '{data.DATA_CADASTRO.ToString("yyyy/MM/dd")}', '{data.CPF_CNPJ}', '{data.DATA_NASCIMENTO.ToString("yyyy/MM/dd")}', '{data.TIPO}', '{data.TELEFONE}', '{data.EMAIL}', '{data.CEP}', '{data.LOGRADOURO}', '{data.NUMERO}', '{data.BAIRRO}', '{data.COMPLEMENTO}', '{data.CIDADE}', '{data.UF}')";

            try
            {
                ExecutarComandoSql(sql);

                return retorno = "CADASTRADO";
            }
            catch (Exception ex)
            {
                return retorno = ex.Message;
            }
        }

        public override List<Usuario> Read()
        {
            string sql = $"SELECT * FROM cliente";
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                var response = RetornaDataTable(sql);
                if (response.Rows.Count > 0)
                {
                    for (int i = 0; i < response.Rows.Count; i++)
                    {
                        Usuario user = new Usuario
                        (
                        Convert.ToInt32(response.Rows[i]["ID"].ToString()),
                        Convert.ToString(response.Rows[i]["NOME"].ToString()),
                        Convert.ToDateTime(response.Rows[i]["DATA_CADASTRO"].ToString()),
                        Convert.ToString(response.Rows[i]["CPF_CNPJ"].ToString()),
                        Convert.ToDateTime(response.Rows[i]["DATA_NASCIMENTO"].ToString()),
                        Convert.ToChar(response.Rows[i]["TIPO"].ToString()),
                        Convert.ToString(response.Rows[i]["TELEFONE"].ToString()),
                        Convert.ToString(response.Rows[i]["EMAIL"].ToString()),
                        Convert.ToString(response.Rows[i]["CEP"].ToString()),
                        Convert.ToString(response.Rows[i]["LOGRADOURO"].ToString()),
                        Convert.ToString(response.Rows[i]["NUMERO"].ToString()),
                        Convert.ToString(response.Rows[i]["BAIRRO"].ToString()),
                        Convert.ToString(response.Rows[i]["COMPLEMENTO"].ToString()),
                        Convert.ToString(response.Rows[i]["CIDADE"].ToString()),
                        Convert.ToString(response.Rows[i]["UF"].ToString())
                        );

                        usuarios.Add(user);
                    }
                    return usuarios;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override Usuario Read(int id)
        {
            string sql = $"SELECT * FROM cliente WHERE ID = {id}";

            try
            {
                var response = RetornaDataTable(sql);
                if(response.Rows.Count > 0)
                {
                    Usuario user = new Usuario
                        (
                        Convert.ToInt32(response.Rows[0]["ID"].ToString()),
                        Convert.ToString(response.Rows[0]["NOME"].ToString()),
                        Convert.ToDateTime(response.Rows[0]["DATA_CADASTRO"].ToString()),
                        Convert.ToString(response.Rows[0]["CPF_CNPJ"].ToString()),
                        Convert.ToDateTime(response.Rows[0]["DATA_NASCIMENTO"].ToString()),
                        Convert.ToChar(response.Rows[0]["TIPO"].ToString()),
                        Convert.ToString(response.Rows[0]["TELEFONE"].ToString()),
                        Convert.ToString(response.Rows[0]["EMAIL"].ToString()),
                        Convert.ToString(response.Rows[0]["CEP"].ToString()),
                        Convert.ToString(response.Rows[0]["LOGRADOURO"].ToString()),
                        Convert.ToString(response.Rows[0]["NUMERO"].ToString()),
                        Convert.ToString(response.Rows[0]["BAIRRO"].ToString()),
                        Convert.ToString(response.Rows[0]["COMPLEMENTO"].ToString()),
                        Convert.ToString(response.Rows[0]["CIDADE"].ToString()),
                        Convert.ToString(response.Rows[0]["UF"].ToString())
                        );

                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string Update(Usuario data)
        {
            string retorno = string.Empty;
            string sql = "UPDATE cliente SET                                          ";
            sql += $"NOME           ='{data.NOME}',                                   ";
            sql += $"DATA_CADASTRO  ='{data.DATA_CADASTRO.ToString("yyyy/MM/dd")}',   ";
            sql += $"CPF_CNPJ       ='{data.CPF_CNPJ}',                               ";
            sql += $"DATA_NASCIMENTO='{data.DATA_NASCIMENTO.ToString("yyyy/MM/dd")}', ";
            sql += $"TIPO           ='{data.TIPO}',                                   ";
            sql += $"TELEFONE       ='{data.TELEFONE}',                               ";
            sql += $"EMAIL          ='{data.EMAIL}',                                  ";
            sql += $"CEP            ='{data.CEP}',                                    ";
            sql += $"LOGRADOURO     ='{data.LOGRADOURO}',                             ";
            sql += $"NUMERO         ='{data.NUMERO}',                                 ";
            sql += $"BAIRRO         ='{data.BAIRRO}',                                 ";
            sql += $"COMPLEMENTO    ='{data.COMPLEMENTO}',                            ";
            sql += $"CIDADE         ='{data.CIDADE}',                                 ";
            sql += $"UF             ='{data.UF}'                                      ";
            sql += $"WHERE ID={data.ID}                                             ";

            try
            {
                ExecutarComandoSql(sql);
                retorno = "Atualizado";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public override string Delete(int id)
        {
            string retorno = string.Empty;
            string sql = $"DELETE FROM cliente WHERE ID={id}";

            try
            {
                ExecutarComandoSql(sql);
                retorno = "Apagado";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }
    }
}
