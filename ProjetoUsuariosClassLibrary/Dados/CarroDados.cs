using AcessoDadosClassLibrary;
using ProjetoUsuariosClassLibrary.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUsuariosClassLibrary.Dados
{
    public class CarroDados
    {
        internal void CreateCarro(Carro carro)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "procedure aqui";
            command.Parameters.Add(DAO.RetornaDbParameter(@carro.Marca, carro.Marca, DbType.String));
            command.Parameters.Add(DAO.RetornaDbParameter(@carro.Modelo, carro.Modelo, DbType.String));
            command.Parameters.Add(DAO.RetornaDbParameter(@carro.Cor, carro.Cor, DbType.String));
            command.Parameters.Add(DAO.RetornaDbParameter(Convert.ToString(@carro.Ano), carro.Ano, DbType.Int32));
            DAO.ExecutaProcedure(command);
        }
    }
}
