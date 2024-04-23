using AcessoDadosClassLibrary;
using ProjetoUsuariosClassLibrary.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUsuariosClassLibrary.Dados
{
    public class UsuariosDados
    {
        internal void CreateUsuario(Usuarios usuario)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "procedure aqui";
            command.Parameters.Add(DAO.RetornaDbParameter(@usuario.Nome, usuario.Nome, DbType.String));
            command.Parameters.Add(DAO.RetornaDbParameter(@usuario.Email, usuario.Email, DbType.String));
            DAO.ExecutaProcedure(command);
        }

    }
}
