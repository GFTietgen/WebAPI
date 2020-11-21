using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Repository
{
    public abstract class AbstractDAL<TEntity> : IDAL<TEntity>
    {
        #region .:PARAMETROS:.
        private static string Server   = "localhost";
        private static string Database = "dbCliente";
        private static string User     = "root";
        private static string Pwd      = "";

        private static string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Pwd};Sslmode=none;Convert Zero Datetime=True";
        #endregion

        #region .:MySQl:.
        private MySqlConnection Connection;
        #endregion

        public AbstractDAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        /// <summary>
        /// Executa: INSERT, UPDATE e DELETE
        /// </summary>
        /// <param name="sql">Query SQL</param>
        public void ExecutarComandoSql(string sql) 
        {
            MySqlCommand command = new MySqlCommand(sql, Connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Executa: SELECT
        /// </summary>
        /// <param name="sql">Comando SQL</param>
        /// <returns>DataTable preenchido</returns>
        public DataTable RetornaDataTable(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            
            adapter.Fill(dataTable);

            return dataTable;
        }

        public abstract string Create(TEntity data);
        public abstract string Delete(int id);
        public abstract List<TEntity> Read();
        public abstract TEntity Read(int id);
        public abstract string Update(TEntity data);
    }
}
