using AcessoDadosClassLibrary;
using ProjetoUsuariosClassLibrary.Entidade;
using System;
using System.Collections;
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
            command.CommandText = "CadastrarNomeEmail";
            command.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = usuario.Nome;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = usuario.Email;
            DAO.ExecutaProcedure(command);
        }
       


    }
}
