using ProjetoUsuariosClassLibrary.Dados;
using ProjetoUsuariosClassLibrary.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoUsuariosClassLibrary.Negocios
{
    public class CarroNegocios
    {
        public void CreateCarro(Carro carro)
        {
            //Colocar as regras de negocio
          
            new CarroDados().CreateCarro(carro);
        }
    }
}
