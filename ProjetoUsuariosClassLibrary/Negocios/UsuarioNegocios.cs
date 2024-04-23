using ProjetoUsuariosClassLibrary.Dados;
using ProjetoUsuariosClassLibrary.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUsuariosClassLibrary.Negocios
{
    public class UsuarioNegocios
    {
      public void CreateUsuario(Usuarios usuario)
        {
            //Colocar as regras de negocio
            if (String.IsNullOrWhiteSpace(usuario.Nome))
            {
                throw new ValidationException("Favor Inserir um Nome");
            }
            if (String.IsNullOrWhiteSpace(usuario.Email))
            {
                throw new ValidationException("Favor Inserir um Email");
            }

            new UsuariosDados().CreateUsuario(usuario);
        }
    }
}
