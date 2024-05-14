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
            command.CommandText = "InserirCarro";
            command.Parameters.Add("@Marca", SqlDbType.NVarChar, 100).Value = carro.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.NVarChar, 100).Value = carro.Modelo;
            command.Parameters.Add("@Cor", SqlDbType.NVarChar, 100).Value = carro.Cor;
            command.Parameters.Add("@Ano", SqlDbType.NVarChar, 100).Value = carro.Ano;
            DAO.ExecutaProcedure(command);
        }
    }
}
