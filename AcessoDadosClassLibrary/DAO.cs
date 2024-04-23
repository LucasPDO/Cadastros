using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoDadosClassLibrary
{
    public class DAO
    {
        public static string connectionString = "coloque_sua_connection_string_aqui";

        public static DbConnection _DbConnection;

        public static DbConnection RetornaConexao
        {
            get
            {
                if (_DbConnection == null)
                    _DbConnection = new SqlConnection(connectionString);

                if (_DbConnection.State == ConnectionState.Broken)
                    _DbConnection.Close();

                if (_DbConnection.State == ConnectionState.Closed)
                    _DbConnection.Open();

                return _DbConnection;
            }
        }

        public static void FechaConexao()
        {
            if (_DbConnection != null)
                _DbConnection.Close();
        }

        public static DataTable RetornoProcedure(DbCommand cmd, int idTabela = 0)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[idTabela];
                conn.Close();
            }
            return dt;
        }

        public static DataTable RetornaDataTable(string sql, int idTabela = 0)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[idTabela];
                conn.Close();
            }
            return dt;
        }

        public static DataSet RetornaDataSet(DbCommand dbCommand)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                dbCommand.Connection = conn;
                dbCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)dbCommand);
                da.Fill(ds);
                conn.Close();
            }
            return ds;
        }

        public static IDataReader ExecutaDataReader(DbCommand dbCommand)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                dbCommand.Connection = connection;
                dbCommand.CommandType = CommandType.StoredProcedure;
                using (SqlCommand cmd = (SqlCommand)dbCommand)
                {
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public static IDataReader ExecutaDataReader(DbCommand dbCommand, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            dbCommand.Connection = connection;
            using (SqlCommand cmd = (SqlCommand)dbCommand)
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// Executa uma procedure no banco de dados a partir de um command
        /// </summary>
        /// <param name="command"></param>
        public static void ExecutaProcedure(DbCommand command)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public static DbParameter RetornaDbParameter(string nomeParametro, object valorParametro, DbType tipoParametro, int value = 0, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = nomeParametro;
            parameter.DbType = tipoParametro;
            parameter.Direction = direction;

            if (valorParametro != null)
                parameter.Value = valorParametro;

            if (value != 0)
                parameter.Value = value;

            return parameter;

        }

    }
}
